using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vidly.Data;
using Vidly.Models;
using Vidly.Repository_Pattern.Implementation;
using Vidly.Repository_Pattern.Interface;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly VidlyDBContext _vidlyDB;
        private readonly IUnitOfWork _work;

        public CustomerController(IUnitOfWork work)
        {
            _work = work;
        }
        public IActionResult Index()
        {
            var customerList = _work.Customer.GetAll(includeProperties: "MembershipType").ToList();
            return View(customerList);
        }

        public IActionResult Create(int? id)
        {

            CustomerVM customerVM = new()
            {
                MembershipTypeList = _work.MembershipType.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                Customer = new Customer()
            };
            if (id == null || id == 0)
            {
                return View(customerVM);
            }
            else
            {
                customerVM.Customer = _work.Customer.Get(u => u.Id == id);
                return View(customerVM);
            }
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _vidlyDB.Customers.Add(customer);
            _vidlyDB.SaveChanges();
            return View();
        }
    }
}

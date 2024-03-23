using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly VidlyDBContext _vidlyDB;

        public CustomerController(VidlyDBContext vidlyDB)
        {
            _vidlyDB = vidlyDB;
        }
        public IActionResult Index()
        {
            var customerList = _vidlyDB.Customers.Include(c => c.MembershipType).ToList();
            return View(customerList);
        }

        public IActionResult Create()
        {

            return View();
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

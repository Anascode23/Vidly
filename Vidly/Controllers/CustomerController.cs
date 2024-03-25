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

            //CustomerVM customerVM = new()
            //{
            //    MembershipTypeList = _work.MembershipType.GetAll()
            //    .Select(c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.Id.ToString()
            //    }),
            //    Customer = new Customer()
            //};
            //if (id == null || id == 0)
            //{
            //    return View(customerVM);
            //}
            //else
            //{
            //    customerVM.Customer = _work.Customer.Get(u => u.Id == id);
            //    return View(customerVM);
            //}
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _work.Customer.Add(customer);
                _work.Save();
                //  TempData["success"] = "Category was created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var customerFromDb = _work.Customer.Get(u => u.Id == id);

            if (customerFromDb == null)
            {
                return NotFound();
            }
            return View(customerFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _work.Customer.Update(customer);
                _work.Save();
                //  TempData["success"] = "Category was created successfully";
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var customerFromDb = _work.Customer.Get(u => u.Id == id);

            if (customerFromDb == null)
            {
                return NotFound();
            }
            return View(customerFromDb);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var customerFromDb = _work.Customer.Get(u => u.Id == id);
            if (customerFromDb == null)
            {
                return NotFound();
            }
            _work.Customer.Delete(customerFromDb);
            _work.Save();
            //TempData["success"] = "Category was deleted successfully";
            return RedirectToAction("Index");



        }
    }
}

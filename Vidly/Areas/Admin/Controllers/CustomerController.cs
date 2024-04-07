// Ignore Spelling: Upsert Admin Vidly

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vidly.Models;
using Vidly.Repository_Pattern.Interface;
using Vidly.Utility;
using Vidly.ViewModels;

namespace Vidly.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CustomerController : Controller
    {
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

        public IActionResult Upsert(int? id)
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
        public IActionResult Upsert(CustomerVM obj)
        {
            if (ModelState.IsValid)
            {



                if (obj.Customer.Id == 0)
                {
                    _work.Customer.Add(obj.Customer);
                }

                else
                {
                    _work.Customer.Update(obj.Customer);
                }

                _work.Save();
                TempData["success"] = "Customer was created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.MembershipTypeList = _work.MembershipType.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()

                });
                return View(obj);
            }
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var customerList = _work.Customer.GetAll(includeProperties: "MembershipType").ToList();
            return Json(new { data = customerList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var customerToBeDelted = _work.Customer.Get(u => u.Id == id);
            if (customerToBeDelted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _work.Customer.Delete(customerToBeDelted);
            _work.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}

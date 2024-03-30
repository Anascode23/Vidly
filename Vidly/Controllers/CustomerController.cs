// Ignore Spelling: Upsert

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

        #region API CALLS
        public IActionResult GetAll()
        {
            var customerList = _work.Customer.GetAll(includeProperties: "MembershipType").ToList();
            return Json(new { data = customerList });
        }
        #endregion
    }
}

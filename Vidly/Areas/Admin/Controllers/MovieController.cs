// Ignore Spelling: Admin Vidly Upsert

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vidly.Access.Data;
using Vidly.Models;
using Vidly.Repository_Pattern.Interface;
using Vidly.ViewModels;

namespace Vidly.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _work;

        public MovieController(VidlyDBContext vidlyDB, IUnitOfWork work)
        {
            _work = work;
        }
        public IActionResult Index()
        {
            var moiveList = _work.Movie.GetAll(includeProperties: "Genre").ToList();
            return View(moiveList);
        }

        public IActionResult Upsert(int? id)
        {

            MovieVM movieVM = new()
            {
                GenreList = _work.Genre.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                Movie = new Movie()
            };
            if (id == null || id == 0)
            {
                return View(movieVM);
            }
            else
            {
                movieVM.Movie = _work.Movie.Get(u => u.Id == id);
                return View(movieVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(MovieVM obj)
        {
            if (ModelState.IsValid)
            {



                if (obj.Movie.Id == 0)
                {
                    _work.Movie.Add(obj.Movie);
                }

                else
                {
                    _work.Movie.Update(obj.Movie);
                }

                _work.Save();
                TempData["success"] = "Movie was created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.GenreList = _work.Genre.GetAll()
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
            var moiveList = _work.Movie.GetAll(includeProperties: "Genre").ToList();
            return Json(new { data = moiveList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var movieToBeDelted = _work.Movie.Get(u => u.Id == id);
            if (movieToBeDelted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _work.Movie.Delete(movieToBeDelted);
            _work.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}

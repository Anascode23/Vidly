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

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var MovieFromDb = _work.Movie.Get(u => u.Id == id);

            if (MovieFromDb == null)
            {
                return NotFound();
            }
            return View(MovieFromDb);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var MovieFromDb = _work.Movie.Get(u => u.Id == id);
            if (MovieFromDb == null)
            {
                return NotFound();
            }
            _work.Movie.Delete(MovieFromDb);
            _work.Save();
            //TempData["success"] = "Category was deleted successfully";
            return RedirectToAction("Index");



        }
        #region API CALLS
        public IActionResult GetAll()
        {
            var moiveList = _work.Movie.GetAll(includeProperties: "Genre").ToList();         
            return Json(new { data = moiveList });
        }
        #endregion
    }
}

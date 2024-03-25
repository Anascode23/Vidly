using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vidly.Data;
using Vidly.Models;
using Vidly.Repository_Pattern.Interface;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly VidlyDBContext _vidlyDB;
        private readonly IUnitOfWork _work;

        public MovieController(VidlyDBContext vidlyDB, IUnitOfWork work)
        {
            _vidlyDB = vidlyDB;
            _work = work;
        }
        public IActionResult Index()
        {
            var moiveList = _work.Movie.GetAll(includeProperties: "Genre").ToList();
            return View(moiveList);
        }

        public IActionResult Create(int? id)
        {

            //MovieVM MovieVM = new()
            //{
            //    MembershipTypeList = _work.MembershipType.GetAll()
            //    .Select(c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.Id.ToString()
            //    }),
            //    Movie = new Movie()
            //};
            //if (id == null || id == 0)
            //{
            //    return View(MovieVM);
            //}
            //else
            //{
            //    MovieVM.Movie = _work.Movie.Get(u => u.Id == id);
            //    return View(MovieVM);
            //}
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _work.Movie.Add(movie);
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
            var MovieFromDb = _work.Movie.Get(u => u.Id == id);

            if (MovieFromDb == null)
            {
                return NotFound();
            }
            return View(MovieFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Movie Movie)
        {
            if (ModelState.IsValid)
            {
                _work.Movie.Update(Movie);
                _work.Save();
                //  TempData["success"] = "Category was created successfully";
                return RedirectToAction("Index");
            }
            return View(Movie);
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
    }
}

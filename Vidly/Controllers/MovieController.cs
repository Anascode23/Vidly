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
        public IActionResult Create(Movie movie)
        {
            _vidlyDB.Movies.Add(movie);
            _vidlyDB.SaveChanges();
            return View();
        }
    }
}

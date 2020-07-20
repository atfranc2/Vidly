using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public IEnumerable<Movie> getMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Name = "Shrek", Id = 1 },
                new Movie { Name = "Holes", Id = 2 },
                new Movie { Name = "Super Dark Times", Id = 3 }
            };
            return movies; 
        }

        // GET: Movies/Random
        public ActionResult Index()
        {
            var movies = getMovies();

            return View(movies);
        }

        [Route("/Movies/Details/{id}")]
        public ActionResult Details(int Id)
        {
            var movie = getMovies().SingleOrDefault(m => m.Id == Id);

            if (movie == null)
            {
                return HttpNotFound(); 
            }
            
            return View(movie); 
        }
    }
}
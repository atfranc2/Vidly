using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Dtos;
using Vidly.HelperMethods;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {

        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rentals
        public ActionResult Index(int customerId)
        {

            var rentalDto = new RentalDto
            {
                CustomerId = customerId,
                MovieId = 0
            };

            var viewModel = new RentalFormViewModel
            {
                RentalDto = rentalDto, 
                Movies = _context.Movies.ToList()
            };

            return View("RentalForm", viewModel);
        }

        public ActionResult Save(RentalFormViewModel rental)
        {
            if (!ModelState.IsValid)
            {
                return View("RentalForm", rental);
            }

            new MovieAPI().decrementMovieStock(rental.RentalDto.MovieId);
            new RentalApi().CreateRental(rental.RentalDto);


            return RedirectToAction("Details", "Customers", new { id = rental.RentalDto.CustomerId });
        }
    }
}
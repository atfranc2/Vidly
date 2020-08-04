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
                CustomerId = customerId
            };

            var viewModel = new RentalFormViewModel
            {
                RentalDto = rentalDto, 
                Movies = _context.Movies.ToList()
            };

            return View("RentalForm", viewModel);
        }

        public ActionResult Save(Rental rental)
        {

            return View("Customers", "Details", rental.CustomerId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Data.Entity; 
using Vidly.Models;
using Vidly.ViewModels;
using System.Net.Http;
using Vidly.Dtos;
using System.Web.UI;
using Vidly.HelperMethods;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        private MovieAPI movieApiHelper = new MovieAPI();
        private RentalApi rentalApiHelper = new RentalApi(); 

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var updateCustomerDb = _context.Customers.Single(m => m.Id == customer.Id);
                updateCustomerDb.FirstName = customer.FirstName;
                updateCustomerDb.LastName = customer.LastName;
                updateCustomerDb.BirthDate = customer.BirthDate;
                updateCustomerDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
                updateCustomerDb.MembershipTypeId = customer.MembershipTypeId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("/Customers/Details/{id}")]
        public ActionResult Details(int Id)
        {

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            ViewBag.Customer = customer;

            if (customer == null)
            {
                return HttpNotFound();
            }

            var rentals = rentalApiHelper.GetRentalDtos(Id);
            var movieIds = GetCustomerMovieIds(rentals);
            var movies = new MovieDto[movieIds.Length];
            var cnt = 0; 
            foreach (var id in movieIds)
            {
                movies[cnt++] = movieApiHelper.GetMovieDto(id); 
            }

            return View("Details", movies);
            // return View(customer);
        }

        private int[] GetCustomerMovieIds(IEnumerable<RentalDto> rentalDtos)
        {
            var movieIds = new int[rentalDtos.Count()];
            var cnt = 0; 
            foreach (var dto in rentalDtos)
                movieIds[cnt++] = dto.MovieId;

            return movieIds; 
        }
    }
}
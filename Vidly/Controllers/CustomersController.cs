using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Data.Entity; 
using Vidly.Models;
using Vidly.ViewModels; 

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; 

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
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel); 
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
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
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();  

            return View(customers);
        }

        [Route("/Customers/Details/{id}")]
        public ActionResult Details(int Id)
        {

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                return HttpNotFound(); 
            }

            return View(customer);
        }
    }
}
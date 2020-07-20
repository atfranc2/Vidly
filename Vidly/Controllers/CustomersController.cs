using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModels; 

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public IEnumerable<Customer> getCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { FirstName = "Bill", LastName = "Bobberson", Id = 1 },
                new Customer { FirstName = "Jill", LastName = "Jillerson", Id = 2 },
                new Customer { FirstName = "Moby", LastName = "Dick", Id = 3 }
            };
            return customers; 
        }

        public ActionResult Index()
        {
            var customers = getCustomers(); 

            return View(customers);
        }

        [Route("/Customers/Details/{id}")]
        public ActionResult Details(int Id)
        {

            var customer = getCustomers().SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                return HttpNotFound(); 
            }

            return View(customer);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<Movie> Movies { get; set; }

        public IEnumerable<int> MovieIds { get; set; }
    }
}
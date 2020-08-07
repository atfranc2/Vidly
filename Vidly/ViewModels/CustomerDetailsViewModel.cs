using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}
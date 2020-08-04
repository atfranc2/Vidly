using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RentalFormViewModel
    {
        public RentalDto RentalDto { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public CustomerDto Customer { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<MovieDto> Movies { get; set; }

        public IEnumerable<int> MovieIds { get; set; }
    }
}
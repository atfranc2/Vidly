﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Movie Rented")]
        [MovieInStock]
        public int MovieId { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Movie Rented")]
        public int MovieId { get; set; }
    }
}
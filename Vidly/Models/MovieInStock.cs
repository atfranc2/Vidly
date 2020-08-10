using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.HelperMethods;

namespace Vidly.Models
{
    public class MovieInStock : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rental = (Rental)validationContext.ObjectInstance;

            var movieRented = new MovieAPI().GetMovieDto(rental.MovieId);
            if (movieRented == null || movieRented.NumberInStock == 0)
                return new ValidationResult("Movie Not Available");

            return ValidationResult.Success; 

        }
    }
}
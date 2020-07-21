using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [System.Runtime.InteropServices.Guid("575BB4A2-BBDE-459C-8EBA-B7868D15EE75")]
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
       
        public DateTime DateAdded { get; set; }
        
        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }
        
        public MovieGenre MovieGenre { get; set; }

        [Required]
        [Display(Name = "Movie Genre")]
        public int MovieGenreId { get; set; }

    }
}
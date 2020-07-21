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
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        public MovieGenre MovieGenre { get; set; }

    }
}
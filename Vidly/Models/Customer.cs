using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public Nullable<DateTime> BirthDate { get; set; }
        
        public int Id { get; set; }
        
        public bool isSubscribedToNewsLetter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }


    }
}
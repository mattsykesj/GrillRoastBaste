using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GrillRoastBaste2.Models
{
    public enum Status
    {
        New,
        Replied,
        Secured,
        Done
    }

    public class CustomerSubmition
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Name field can only contain letters, no spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter your surname")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Name field can only contain letters, no spaces")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your email phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter the location of event")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter the details of  the event")]
        public string EventDescription { get; set; }

        public DateTime DateOfBooking { get; set; }

        [CustomRange(ErrorMessage ="The date must be in the future!")]
        [Required(ErrorMessage = "A date must be entered")]
        public DateTime DateOfEvent { get; set;}

        public Status Status { get; set; }

        public string Notes { get; set; }


    }
}
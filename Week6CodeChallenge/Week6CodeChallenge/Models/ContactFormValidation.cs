using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Week6CodeChallenge.Models
{
    [MetadataType(typeof(ContactFormValidation))]

    public partial class ContactForm
    {
    }

    public class ContactFormValidation
    {
        [Required(ErrorMessage = "Please enter your first name."), Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name."), Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name="Phone Number:")]
        public string PhoneNumber { get; set; }
        [Display(Name="Company Name:")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter your project description."),Display(Name="Project Description:")]
        public string ProjectDescription { get; set; }
        [Required(ErrorMessage = "Please enter your email."), Display(Name = "Email:"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please say hello!"), Display(Name = "What do you want to say?")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParallaxPortfolio.Models
{
    [MetadataType(typeof(ContactFormValidation))]

    public partial class ContactForm
    {
        //the only reason we're doing this
    }

    public class ContactFormValidation
    {
        [Required(ErrorMessage="Please enter your name."), Display(Name="Your Name:")]
        //write out the properties we want to define
        public string Name { get; set; }

        [Required(ErrorMessage="Please enter your email."), Display(Name="Your Email:"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage="Please say hello!"), Display(Name="What do you want to say?")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
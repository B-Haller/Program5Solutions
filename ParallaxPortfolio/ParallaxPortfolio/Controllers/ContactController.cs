using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParallaxPortfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            Models.ContactForm contactForm = new Models.ContactForm();
            return View(contactForm);
        }

        [HttpPost]
        public ActionResult Index(Models.ContactForm contactForm)
        {
            Models.sp5BrandonEntities db = new Models.sp5BrandonEntities();
            contactForm.DateCreated = DateTime.Now;
            db.ContactForms.Add(contactForm);
            db.SaveChanges();
            return View("ThankYou");
        }
    }
}
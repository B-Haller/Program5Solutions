using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week6CodeChallenge.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            Models.ContactForm contactForm = new Models.ContactForm();
            return PartialView(contactForm);
        }

        [HttpPost]
        public ActionResult Index(Models.ContactForm contactForm)
        {
            Models.ContactFormEntities db = new Models.ContactFormEntities();
            db.ContactForms.Add(contactForm);
            db.SaveChanges();
            return View("ThankYou");
        }
    }
}
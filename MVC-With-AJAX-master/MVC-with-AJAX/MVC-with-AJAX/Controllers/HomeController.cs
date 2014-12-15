using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_with_AJAX.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        public ActionResult Contact()
        {
            return PartialView(new Models.ContactForm());
        }
        [HttpPost]
        public ActionResult Contact(Models.ContactForm contactForm)
        {
            return Content("Thanks!");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoNotLike()
        {

            //fun program logic can go here
            ViewBag.PageTitle = "Music I Don't Like";
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView();
        }

        public ActionResult ContentTest()
        {
            return Content("I am some content.");
        }
    }
}
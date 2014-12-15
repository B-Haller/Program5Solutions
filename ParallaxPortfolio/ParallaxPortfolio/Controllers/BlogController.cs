using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParallaxPortfolio.Controllers
{
    public class BlogController : Controller
    {
        Models.sp5BrandonEntities db = new Models.sp5BrandonEntities();

        // GET: Blog
        public ActionResult Index()
        {
            return View(db.BlogPosts);
        }
    }
}
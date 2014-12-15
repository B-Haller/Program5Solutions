using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week6CodeChallenge.Controllers
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
            else {
            return View();
            } 
        }
        public ActionResult Careers()
        {
            return PartialView();
        }
        public ActionResult About()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return PartialView("Who");
            } 
        }
        public ActionResult Work()
        {
            return PartialView();
        }
        public ActionResult Who()
        {
            return PartialView();
        }
        public ActionResult What()
        {
            return PartialView();
        }
        public ActionResult Why()
        {
            return PartialView();
        }
        public ActionResult How()
        {
            return PartialView();
        }
        public ActionResult Where()
        {
            return PartialView();
        }
    }
}
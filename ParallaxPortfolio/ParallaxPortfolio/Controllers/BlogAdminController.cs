using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParallaxPortfolio.Controllers
{
    public class BlogAdminController : Controller
    {
        //set up our database gateway
        Models.sp5BrandonEntities db = new Models.sp5BrandonEntities();

        // GET: BlogAdmin
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.BlogPosts);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Models.BlogPost());
        }
        [HttpPost]
        public ActionResult Create(Models.BlogPost post)
        {
            db.BlogPosts.Add(post);
            post.DateCreated = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index", "BlogAdmin");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //get the post to edit
            Models.BlogPost blogToEdit = db.BlogPosts.Find(id);
            //pass our model to view
            return View(blogToEdit);
        }
        [HttpPost]
        public ActionResult Edit(int id, Models.BlogPost editedBlogPost)
        {
            //first method: get from database and update
            Models.BlogPost databaseBlogPost = db.BlogPosts.Find(id);
            databaseBlogPost.Title = editedBlogPost.Title;
            databaseBlogPost.Body = editedBlogPost.Body;
            databaseBlogPost.ImageURL = editedBlogPost.ImageURL;
            db.SaveChanges();

            //kick user back to screen

            return RedirectToAction("Index", "BlogAdmin");


            //second method: tell the db that this objject belongs to it
            //db.Entry(editedBlogPost).State = System.Data.Entity.EntityState.Modified
            //db.SaveChanges();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Models.BlogPost postToDelete = db.BlogPosts.Find(id);
            return View(postToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Models.BlogPost postToDelete = db.BlogPosts.Find(id);
            db.Entry(postToDelete).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index", "BlogAdmin");
        }
    }
}

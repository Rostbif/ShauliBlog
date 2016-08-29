using ShauliBlogMvc.DAL;
using ShauliBlogMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlogMvc.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Blog
        public ActionResult Index()
        {

            return View(db.Posts.ToList());
        }

        public ActionResult addComment(int postId,string title, string authorName, string website, string content)
        {
            var comment = new Comment()
            {
                PostID = postId,
                Title = title,
                AuthorName = authorName,
                SiteOfAuthor = website,
                Content = content
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
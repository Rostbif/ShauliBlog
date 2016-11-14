using ShauliBlogMvc.DAL;
using ShauliBlogMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ShauliBlogMvc.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Blog
        public ActionResult Index(string title, DateTime? publishDate, string authorName, string siteOfAuthor,
            string wordsFromPost, int? minimalComments)
        {
            // eager loading of the comments . uses join
            IQueryable<Post> posts = db.Set<Post>().Include(p => p.Comments);
            IQueryable<Fan> fans = db.Set<Fan>();

            if (!string.IsNullOrEmpty(title))
            {
                posts = posts.Where(p => p.Title == title);
            }

            if (publishDate != null)
            {
                posts = posts.Where(p => p.PublishDate == publishDate);
            }

            if (!string.IsNullOrEmpty(authorName))
            {
                posts = posts.Where(p => p.Author == authorName);
            }

            if (!string.IsNullOrEmpty(siteOfAuthor))
            {
                posts = posts.Where(p => p.SiteOfAuthor == authorName);
            }

            if (!string.IsNullOrEmpty(wordsFromPost))
            {
                posts = posts.Where(p => p.Content.Contains(wordsFromPost));
            }

            if (minimalComments.HasValue)
            {
                // join between posts and comments
                posts = posts.Where(p => p.Comments.Count >= minimalComments);
            }

            // Return a tuple -2 views in one model for displaying posts and fans.
            var model = new Tuple<List<Post>, List<Fan>>(posts.OrderByDescending(p => p.PublishDate).ToList(), fans.ToList());
            return View(model);

        }

        public ActionResult addComment(int postId,string title, int authorID, string website, string commentText)
        {
            Fan author = db.Fans.Find(authorID);
            var comment = new Comment()
            {
                PostID = postId,
                Title = title,
                Author = author,
                Content = commentText
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
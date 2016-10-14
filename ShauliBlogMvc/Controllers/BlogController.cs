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
        public ActionResult Index(string title, DateTime? publishDate, string authorName, string siteOfAuthor,
            string wordsFromPost, int? minimalComments)
        {
            IQueryable<Post> posts = db.Set<Post>();

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


            return View(posts.OrderByDescending(p => p.PublishDate).ToList());
        }

        public ActionResult addComment(int postId,string title, string authorName, string website, string commentText)
        {
            var comment = new Comment()
            {
                PostID = postId,
                Title = title,
                //AuthorName = authorName,
                //SiteOfAuthor = website,
                Content = commentText
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
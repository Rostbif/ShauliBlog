using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShauliBlogMvc.DAL;
using ShauliBlogMvc.Models;

namespace ShauliBlogMvc.Controllers
{
    public class PostsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Posts
        public ActionResult Index()
        {
            // Check if the admin needs to login before accessing this page
            if(Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View(db.Posts.OrderByDescending(p => p.PublishDate).ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddComment([Bind(Include = "name, email, website, comment")] Comment comment)
        {
            var postId = 1;

            var postToUpdate = db.Posts.First(p => p.ID == postId);

            comment.Post = postToUpdate;

            db.Comments.Add(comment);

            db.SaveChanges();

            postToUpdate.Comments.Add(comment);

            db.SaveChanges();

            return (View(db.Posts.ToList()));
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Author,SiteOfAuthor,Content")] Post post,
            HttpPostedFileBase image ,
            HttpPostedFileBase video
            )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if( image != null && image.ContentLength > 0)
                    {
                        byte[] imageFile;

                        using (var reader = new System.IO.BinaryReader(image.InputStream))
                        {
                            imageFile = reader.ReadBytes(image.ContentLength);
                        }

                        post.Image = imageFile;
                    }

                    if (video != null && video.ContentLength > 0)
                    {
                        byte[] videoFile;

                        using (var reader = new System.IO.BinaryReader(video.InputStream))
                        {
                            videoFile = reader.ReadBytes(video.ContentLength);
                        }

                        post.Video = videoFile;
                    }

                    // set the publish date
                    post.PublishDate = DateTime.Now;

                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,SiteOfAuthor,Content")] Post post,
            HttpPostedFileBase image,
            HttpPostedFileBase video)
        {
            if (ModelState.IsValid)
            {
                // get the relevant post
                var postToUpdate = db.Posts.First(p => p.ID == post.ID);

                // update the changes 
                postToUpdate.Title = post.Title;
                postToUpdate.Author = post.Author;
                postToUpdate.SiteOfAuthor = post.SiteOfAuthor;
                postToUpdate.Content = post.Content;

                if (image != null && image.ContentLength > 0)
                {
                    byte[] imageFile;

                    using (var reader = new System.IO.BinaryReader(image.InputStream))
                    {
                        imageFile = reader.ReadBytes(image.ContentLength);
                    }

                    post.Image = imageFile;
                }

                if (video != null && video.ContentLength > 0)
                {
                    byte[] videoFile;

                    using (var reader = new System.IO.BinaryReader(video.InputStream))
                    {
                        videoFile = reader.ReadBytes(video.ContentLength);
                    }

                    post.Video = videoFile;
                }


                db.Entry(postToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult ManageComments(int id)
        {
            // Find the right post to open comments of that view
            Post post = db.Posts.Find(id);
            return View(post);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

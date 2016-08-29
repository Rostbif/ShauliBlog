using ShauliBlogMvc.DAL;
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
    }
}
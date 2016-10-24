using ShauliBlogMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlogMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            if("admin".Equals(name) && "123456".Equals(password))
            {
                Session["user"] = new User() {Login = name, Name = "Administrator" };
                return RedirectToAction("Index", "Posts");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "The user name or password is incorrect");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Blog");
        }
    }
}
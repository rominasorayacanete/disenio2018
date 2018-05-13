using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpPrevio.Models;

namespace TpPrevio.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lg)
        {
            if (ModelState.IsValid)
            {
                using (LoginDataBaseEntities ldbe = new LoginDataBaseEntities())
                {
                    var log = ldbe.Users.Where(a => a.UserName.Equals(lg.UserName) && a.Password.Equals(lg.Password)).FirstOrDefault();
                    if (log != null)
                    {
                        
                        return RedirectToAction("UsersHome", "Account");
                    }
                    else
                    {
                        Response.Write("<script> alert ('Invalid password')</script>");
                    }
                }
            }
            return View();

        }

        public ActionResult UsersHome()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            //Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login","Account");
        }

    }
}
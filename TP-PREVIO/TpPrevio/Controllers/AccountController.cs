using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TpPrevio.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;



namespace TpPrevio.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        { 
 
            return View();
        }

        public ActionResult Country()
        {
            {
                Country_Load();
                Country_Select();
            }
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

        private List<Country> paises;

        public void Country_Load()
        {
            string sUrlRequest = "https://api.mercadolibre.com/classified_locations/countries";
            var json = new WebClient().DownloadString(sUrlRequest);
            paises = JsonConvert.DeserializeObject<List<Country>>(json);
            Response.Write(paises[0].Name);
            ViewData["paises"] = new SelectList(paises, "Name", "Name", paises[0]);
            
            //ViewData["paises"] = new SelectList(paises, "Name", "Name", paises[0]);
            //ViewData["paises"] = new SelectList(new List<Country>());
        }

        public void Country_Select()
        {
            ViewData["countryRequest"] = Request.Form["paises"];
            if (User.Identity.IsAuthenticated && Request.Form["paises"] != "")
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();
                string query = "UPDATE dbo.LoginDataBaseEntities SET Country = '" + Request.Form["paises"] + "' WHERE UserName = '" + User.Identity.Name + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }

    }
}
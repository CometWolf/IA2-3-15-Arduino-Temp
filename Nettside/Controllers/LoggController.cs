using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Classes;

namespace WebApplication6.Controllers
{
    public class LoggController : Controller
    {
        Database database = new Database("");
        // GET: Logg
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) { //Check if user is logged in
                //Not logged in, redirect to login page
                //Response.Redirect("~/Account/Login");
            }
            ViewBag.Title = "Logg";
            ViewBag.Message = "Alarm og temperatur logg";
            return View();
        }

        //public void GetLogg(string date) {
            //database.
        //}
    }
}
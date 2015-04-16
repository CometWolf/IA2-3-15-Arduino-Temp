using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers {
    public class HomeController : Controller {
        //path to database
        private Database database = new Database("C:\\Users\\Haakon\\Desktop\\IA2-3-15-Arduino-Temp\\Nettside\\ArduinoTemperaturmåling.accdb");

        [HttpPost]
        public JsonResult GetTemp() { //get latest logged temp, used to dynamically update temp display
            string[,] temp = database.GetTemperatureLast();
            return Json(new { result = temp[0,2] }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void UpdateAlarmLimits(string upperLimit, string lowerLimit, string updateInterval) { //Stores the given alarm settings in the database
            database.UpdateSetting(upperLimit, 1, 0);
            database.UpdateSetting(lowerLimit, 3, 0);
            database.UpdateSetting(updateInterval, 5, 0);
            Response.Redirect("~/");
        }

        [HttpPost]
        public void UpdateFurnaceLimits(string upperLimit, string lowerLimit) { //Stores the given furnace settings in the database
            database.UpdateSetting(upperLimit, 2, 0);
            database.UpdateSetting(lowerLimit, 4, 0);
            Response.Redirect("~/");
        }
        
        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) { //Check if user is logged in
                //Not logged in, redirect to login page
                Response.Redirect("~/Account/Login");
            }
            ViewBag.Title = "Hovedside";
            //initial temperature get
            ViewBag.temperature = database.GetTemperatureLast()[0,2];
            //settings
            string[] setting = database.GetSettings(0);
            ViewBag.highAlarm = setting[1];
            ViewBag.lowAlarm = setting[3];
            ViewBag.furnaceHigh = setting[2];
            ViewBag.furnaceLow = setting[4];
            ViewBag.updateInterval = setting[5];
            //alarm
            string[,] alarm = database.GetAlarmLast(1);
            if (alarm[0, 6] == "0") { //alarm not signed
                ViewBag.alarm = "\n" + alarm[0,4];
            } //else no unsigned alarm */
            return View();
        }
    }
}
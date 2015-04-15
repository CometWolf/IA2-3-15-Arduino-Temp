using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers {
    public class HomeController : Controller {
        private Database database = new Database("C:\\Users\\Haakon\\Documents\\Database5.accdb");
        private void CheckLogin() { //Check if user is logged in
            if (!User.Identity.IsAuthenticated) {
                //Not logged in, redirect to login page
                //Response.Redirect("~/Account/Login");
            }
        }

        [HttpPost]
        public JsonResult GetTemp() {
            return Json(new { result = "22" }, JsonRequestBehavior.AllowGet);//database.GetTemperatureLast(1);
        }
        public string GetTemp(bool stringReturn) {
            return "25";//database.GetTemperatureLast(1);
        }

        [HttpPost]
        public void UpdateAlarmLimits(string upperLimit, string lowerLimit, string updateInterval) {
            database.UpdateSetting(upperLimit, 1, 0);
            database.UpdateSetting(lowerLimit, 3, 0);
            database.UpdateSetting(updateInterval, 5, 0);
            Response.Redirect("~/");
        }

        [HttpPost]
        public void UpdateFurnaceLimits(string upperLimit, string lowerLimit) {
            database.UpdateSetting(upperLimit, 2, 0);
            database.UpdateSetting(lowerLimit, 4, 0);
            Response.Redirect("~/");
        }
        
        public ActionResult Index() {
            CheckLogin();
            ViewBag.Title = "Hovedside";
            //temperature
            ViewBag.temperature = GetTemp(true);
            //settings
            string[] setting = database.GetSettings();
            ViewBag.highAlarm = setting[1];
            ViewBag.lowAlarm = setting[3];
            ViewBag.furnaceHigh = setting[2];
            ViewBag.furnaceLow = setting[4];
            ViewBag.updateInterval = setting[5];
            //alarm
            string[,] alarm = database.GetAlarmLast(1);
            /*if (alarm[0, 6] == "0") { //alarm not signed
                ViewBag.alarm = "\n" + alarm[0,4];
            } //else no unsigned alarm */
            return View();
        }

        public ActionResult Logg() {
            CheckLogin();
            ViewBag.Title = "Logg";
            ViewBag.Message = "Alarm og temperatur logg";
            return View();
        }
    }
}
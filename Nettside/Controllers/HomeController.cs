using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Mvc;
using WebApplication6.Models;
using WebApplication6.Classes;

namespace WebApplication6.Controllers {
    public class HomeController : Controller {
        //path to database
        private Database database = new Database("C:\\Users\\Haakon\\Desktop\\IA2-3-15-Arduino-Temp\\Nettside\\ArduinoTemperaturmåling.accdb");
        
        //index view
        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) { //Check if user is logged in
                //Not logged in, redirect to login page
                Response.Redirect("~/Account/Login",true);
                return null;
            }
            ViewBag.Title = "Hovedside";
            HomeViewModel model = new HomeViewModel();
            try {
                //initial temperature get
                model.temperature = database.GetTemperatureLast()[0,1];
                //settings
                string[] setting = database.GetSettings(0);
                model.alarm.upperLimit = setting[1];
                model.alarm.lowerLimit = setting[4];
                model.updateInterval = setting[5];
                model.furnace.upperLimit = setting[2];
                model.furnace.lowerLimit = setting[3];
                //alarm
                string[,] alarm = database.GetAlarmLast(1);
                if (alarm[0, 4] == "0") { //alarm not signed
                    model.alarm.hide = false;
                    model.alarm.id = alarm[0, 1];
                    model.alarm.message = "\n" + alarm[0, 3];
                } //else no unsigned alarm
                return View(model);
            } catch (Exception e){
                Response.Redirect("~/Home/Error?e=" + e.Message);
                return null;
            }

        }

        //error view
        public ActionResult Error() {
            return View();
        }

        [HttpPost]
        //get latest logged temp, used to dynamically update temp display
        public JsonResult GetTemp() { 
            string[,] temp = database.GetTemperatureLast();
            return Json(new { result = temp[0, 1] }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SignAlarm(string id) {
            database.SignAlarm(id);
            Response.Redirect("~/");
        }

        [HttpPost]
        //upload settings to database
        public void UpdateSettings(string aUpperLimit, string aLowerLimit, string updateInterval, string fUpperLimit, string fLowerLimit) {
            database.UpdateSetting(aUpperLimit, 1, 0);
            database.UpdateSetting(aLowerLimit, 4, 0);
            database.UpdateSetting(updateInterval, 5, 0);
            database.UpdateSetting(fUpperLimit, 2, 0);
            database.UpdateSetting(fLowerLimit, 3, 0);
            Response.Redirect("~/");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Mvc;
using WebApplication6.Models;
using WebApplication6.Classes;
using WebApplication6.Properties;
using Account;

namespace WebApplication6.Controllers {
    public class HomeController : Controller {
        //path to database
        private Database database = new Database("C:\\Users\\Haakon\\Desktop\\IA2-3-15-Arduino-Temp\\Nettside\\ArduinoTemperaturmåling.accdb");
        
        //index view
        public ActionResult Index() {
            if (!Account.User.Authorized) { //Check if user is logged in
                //Not logged in, redirect to login page
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Hovedside";
            HomeViewModel model = new HomeViewModel();
            try {
                //initial temperature get
                model.temperature = database.GetTemperatureLast()[0,1];
                //settings
                string[] setting = database.GetSettings(0);
                model.AlarmUpperLimit = setting[1];
                model.AlarmLowerLimit = setting[4];
                model.LogInterval = setting[5];
                model.FurnaceUpperLimit = setting[2];
                model.FurnaceLowerLimit = setting[3];
                //alarm
                string[,] alarm = database.GetAlarmLast(1);
                if (alarm[0, 4] == "0") { //alarm not signed
                    model.alarmHide = "";
                    model.AlarmId = alarm[0, 1];
                    model.alarmMessage = "\n" + alarm[0, 3];
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
        public void SignAlarm(HomeViewModel model) {
            database.SignAlarm(model.AlarmId);
            model.alarmHide = "hidden";
            Response.Redirect("~/");
        }

        [HttpPost]
        //upload settings to database
        public void UpdateSettings(HomeViewModel model) {
            database.UpdateSetting(model.AlarmUpperLimit, 1, 0);
            database.UpdateSetting(model.AlarmLowerLimit, 4, 0);
            database.UpdateSetting(model.LogInterval, 5, 0);
            database.UpdateSetting(model.FurnaceUpperLimit, 2, 0);
            database.UpdateSetting(model.FurnaceLowerLimit, 3, 0);
            Response.Redirect("~/");
        }
    }
}
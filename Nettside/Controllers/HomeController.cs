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

        [HttpPost]
        public JsonResult GetTemp() { //get latest logged temp, used to dynamically update temp display
            string[,] temp = database.GetTemperatureLast();
            return Json(new { result = temp[0,2] }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void UpdateSettings(string aUpperLimit, string aLowerLimit, string updateInterval, string fUpperLimit, string fLowerLimit) {
            //updates database settings
            database.UpdateSetting(aUpperLimit, 1, 0);
            database.UpdateSetting(aLowerLimit, 3, 0);
            database.UpdateSetting(updateInterval, 5, 0);
            database.UpdateSetting(fUpperLimit, 2, 0);
            database.UpdateSetting(fLowerLimit, 4, 0);
            Response.Redirect("~/");
        }
        
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
                model.temperature = database.GetTemperatureLast()[0,2];
                //settings
                string[] setting = database.GetSettings(0);
                model.alarm.upperLimit = setting[1];
                model.alarm.lowerLimit = setting[3];
                model.furnace.upperLimit = setting[2];
                model.furnace.lowerLimit = setting[4];
                model.updateInterval = setting[5];
                //alarm
                string[,] alarm = database.GetAlarmLast(1);
                if (alarm[0, 5] == "0") { //alarm not signed
                    model.alarm.message = "\n" + alarm[0, 4] +
@"<form id='alarm' action='@Url.Action('SignAlarm', 'Home')' method='post'>
    <input type='submit' value='Signer alarm' />                    
</form>";
                } //else no unsigned alarm
                return View(model);
            } catch (ExecutionEngineException e){
                Response.Redirect("~/Home/Error?e=" + e.Message);
                return null;
            }

        }

        public ActionResult Error() {
            return View();
        }
    }
}
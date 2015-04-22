using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Classes;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class LoggController : Controller
    {
        Database database = new Database("C:\\Users\\Gustav\\Documents\\GitHub\\IA2-3-15-Arduino-Temp\\Nettside\\ArduinoTemperaturmåling.accdb");
        static LoggModel model = new LoggModel();
       
        // GET: Logg
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) { //Check if user is logged in
                //Not logged in, redirect to login page
                //Response.Redirect("~/Account/Login");
            }
            ViewBag.Title = "Logg";
            ViewBag.Message = "Alarm og temperatur logg";
            return View(model);
        }

        public void GetLogg(string input, string unit, string type) 
        {
            model = new LoggModel();
            model.input = input;
            //model.unit = type;
            model.unit.entity = (unit == "entity") ? "selected" : "";
            model.unit.day = (unit == "day") ? "selected" : "";
            model.unit.month = (unit == "month") ? "selected": "";
            model.type.temperature = (type == "Temperature") ? "checked" : "";
            model.type.alarm = (type == "Alarm") ? "checked" : "";
            string[,] tempArray = new string[0,0];
            switch (unit)
            {
                case "entity":
                    if (type == "Temperature") tempArray = database.GetTemperatureLast(Convert.ToInt32(input));
                    else if (type == "Alarm") tempArray = database.GetAlarmLast(Convert.ToInt32(input));
                    break;
                case "day":
                    if(type == "Temperature") tempArray = database.GetTemperatureDays(Convert.ToInt32(input));
                    else if(type =="Alarm") tempArray = database.GetAlarmDays(Convert.ToInt32(input));
                    break;
                case "month":
                    if(type == "Temperature") tempArray = database.GetTemperatureMonths(Convert.ToInt32(input));
                    else if(type =="Alarm") tempArray = database.GetAlarmMonths(Convert.ToInt32(input));
                    break;
                default:
                    tempArray = new string[0, 0];
                    break;
            }
            for (int i = 0; i <= tempArray.GetUpperBound(0); i++)
			{
                model.data = model.data + tempArray[i, 0] + ": " + tempArray[i, 1] + "°C" + "<br />";
			}
            Response.Redirect("~/Logg/Index");
        }
    }
}
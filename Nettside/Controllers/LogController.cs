/*
  Written by: Gustav Carlsen
  Log page controller. Handles the user input from the log page, and returns the desired database logs.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Classes;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class LogController : Controller
    {
<<<<<<< HEAD:Nettside/Controllers/LoggController.cs
        Database database = new Database("C:\\Users\\Martin\\Documents\\GitHub\\IA2-3-15-Arduino-Temp\\PC\\CabinTempArduino\\bin\\debug\\ArduinoTemperaturmåling.accdb");
        static LoggModel model = new LoggModel();
=======
        //database path
        Database database = new Database("C:\\Users\\Gustav\\Documents\\GitHub\\IA2-3-15-Arduino-Temp\\Nettside\\ArduinoTemperaturmåling.accdb");
        static LogModel model = new LogModel();
>>>>>>> origin/master:Nettside/Controllers/LogController.cs
       
        // GET: Logg
        public ActionResult Index()
        {
            if (!Account.User.Authorized) { //Check if user is logged in
                //Not logged in, redirect to login page
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Logg";
            ViewBag.Message = "Alarm og temperatur logg";
            return View(model);
        }

        public ActionResult GetLogg(string input, string unit, string type) 
        {
            model = new LogModel();
            int inputInt;
            int.TryParse(input, out inputInt);
            model.input = input;
            model.unit.entity = (unit == "entity") ? "selected" : "";
            model.unit.day = (unit == "day") ? "selected" : "";
            model.unit.month = (unit == "month") ? "selected": "";
            model.type.temperature = (type == "Temperature") ? "checked" : "";
            model.type.alarm = (type == "Alarm") ? "checked" : "";
            string[,] tempArray = new string[0,0];

            if (!(input == "")) 
            {
                try
                {
                    switch (unit)
                    {
                        case "entity":
                            if (type == "Temperature") tempArray = database.GetTemperatureLast(inputInt);
                            else if (type == "Alarm") tempArray = database.GetAlarmLast(inputInt);
                            break;
                        case "day":
                            if (type == "Temperature") tempArray = database.GetTemperatureDays(inputInt);
                            else if (type == "Alarm") tempArray = database.GetAlarmDays(inputInt);
                            break;
                        case "month":
                            if (type == "Temperature") tempArray = database.GetTemperatureMonths(inputInt);
                            else if (type == "Alarm") tempArray = database.GetAlarmMonths(inputInt);
                            break;
                    }
                    for (int i = 0; i <= tempArray.GetUpperBound(0); i++)
                    {
                        model.data = model.data + tempArray[i, 0] + ": " + tempArray[i, 1] + "°C" + "<br />";
                    }
                }
                catch (Exception e)
                {
                    Response.Redirect("~/Home/Error?e=" + e.Message);
                    return null;
                }


            } 
            return RedirectToAction("Index","Log");
        }
    }
}
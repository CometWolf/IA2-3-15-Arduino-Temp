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
            string[,] tempArray;
            switch (unit)
            {
                case "entity":
                        if (type == "Temperature") tempArray = database.GetTemperatureLast(Convert.ToInt32(input));
                        else if (type == "Alarm") tempArray = database.GetAlarmLast(Convert.ToInt32(input));
                    break;
                case "day":
                        if(type == "Temperature")
                        {
                            tempArray = database.GetTemperatureDays(input);
                        }
                        else if(type =="Alarm")
                        {
                            tempArray = database.GetAlarmDays(Convert.ToInt32(input));
                        }
                    break;
                case "week":
                        if(type == "Temperature")
                        {
                            tempArray = database.GetTemperatureWeeks(Convert.ToInt32(input));
                        }
                        else if(type =="Alarm")
                        {
                            tempArray = database.GetAlarmWeeks(Convert.ToInt32(input));
                        }
                    break;
                default:
                    tempArray = new string[0, 0];
                    break;
            }
            for (int i = 0; i < tempArray.GetUpperBound(0); i++)
			{
			    for (int j = 0; j < tempArray.GetUpperBound(1); j++)
			    {
			            model.data = model.data + tempArray[i,j] + "\n";
			    }
			}
            Response.Redirect("~/Logg/Index");
        }
    }
}
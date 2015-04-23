using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using WebApplication6.Classes;
using Account;

namespace WebApplication6.Controllers
{
    [Authorize]
    public class AccountController : Controller {
        //Login database
        private Database database = new Database("C:\\Users\\Martin\\Documents\\GitHub\\IA2-3-15-Arduino-Temp\\PC\\CabinTempArduino\\bin\\debug\\ArduinoTemperaturmåling.accdb");

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl) {
            if (ModelState.IsValid) //login format valid
            {
                try {
                    if (Account.User.Login(model.Email,model.Password)) {
                        return RedirectToAction("Index", "Home");
                    }
                } catch (Exception e) {
                    Response.Redirect("~/Home/Error?e=" + e.Message);
                    return null;
                }
                //login failed
                ModelState.AddModelError("", "Feil brukernavn eller passord.");
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff() {
            Account.User.Logoff();
            return RedirectToAction("Login", "Account");
        }
    }

}
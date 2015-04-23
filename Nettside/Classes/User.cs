using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication6;
using WebApplication6.Classes;

namespace Account {
    public static class User {
        private static Database database = new Database("C:\\Users\\Martin\\Documents\\GitHub\\IA2-3-15-Arduino-Temp\\PC\\CabinTempArduino\\bin\\debug\\ArduinoTemperaturmåling.accdb");
        private static string username;
        public static string Username { get {return User.username;} }
        private static string password;
        private static string email;
        public static string Email { get {return User.email;} }
        private static bool authorized;
        public static bool Authorized { get {return User.authorized;} }
        public static bool Login(string email, string password) {
            username = database.SearchUsername(email, password);
            if (username != null) { //Login sucessfull
                User.email = email;
                User.password = password;
                authorized = true;
                return true;
            }
            return false;
        }
        public static void Logoff() {
            authorized = false;
            username = null;
            email = null;
            password = null;
        }
    }
}
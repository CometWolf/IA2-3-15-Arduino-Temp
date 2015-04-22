using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class LoggModel
    {
        public string data;
        public string input;
        public class Unit
        {
            public string entity;
            public string day;
            public string month;
            
        }
        public Unit unit = new Unit();
        public class Type
        {
            public string temperature = "checked";
            public string alarm;
        }
        public Type type = new Type();
    }
}
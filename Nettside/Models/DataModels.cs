using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models {
    public class MainViewModel {
        public string temperature;
        public string updateInterval;
        public class Furnace {
            public string upperLimit;
            public string lowerLimit;
        }
        public Furnace furnace = new Furnace();
        public class Alarm {
            public string upperLimit;
            public string lowerLimit;
            public string message;
        }
        public Alarm alarm = new Alarm();
    }
}
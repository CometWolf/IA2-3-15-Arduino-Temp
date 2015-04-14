using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinTempArduino
{
    class FurnaceController  : Arduino
    {
        public FurnaceController(double alarmUp, double alarmLow, 
            double furnaceUp, double furnaceLow, int baudrate, 
            string portname) : base(baudrate, portname)
        {
            alarmUpperLimit = alarmUp;
            alarmLowerLimit = alarmLow;
            furnaceUpperlimit = furnaceUp;
            furnaceLowerLimit = furnaceLow;
        }


        #region Fields
        private double alarmLowerLimit;
        private double alarmUpperLimit;
        private double furnaceLowerLimit;
        private double furnaceUpperlimit;
        private string temp;
        private double tempValue;
        private bool furnaceActive;
        private bool alarm;
        #endregion

        #region Properties
        public bool Alarm
        {
            get { return alarm; }
        }
        public double TempValue
        {
            get { return tempValue; }
        }
        public double AlarmLowerLimit
        {
            get { return alarmLowerLimit; }
            set { alarmLowerLimit = value; }
        }
        public double AlarmUpperLimit
        {
            get { return alarmUpperLimit; }
            set { alarmUpperLimit = value; }
        }
        public double FurnaceLowerLimit
        {
            get { return furnaceLowerLimit; }
            set { furnaceLowerLimit = value; }
        }
        public double FurnaceUpperLimit
        {
            get { return furnaceUpperlimit; }
            set { furnaceUpperlimit = value; }
        }
        #endregion

        public string GetTemp()
        {
            Send("temp");
            temp = Received();
            return temp;
        }

        public bool CheckAlarm()
        {
            if ((Received() == "aupp")||(Received() == "alow"))
            {
                alarm = true;
            }
            return alarm;
        }

        public string AlarmUpper()
        {
            string alarmUpper;
            alarmUpper = "aupper" + alarmUpperLimit;
            return alarmUpper;
            
        }
    }
}

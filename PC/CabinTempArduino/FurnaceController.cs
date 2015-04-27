using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CabinTempArduino
{
     /*
     * Written by: Øystein Lorentzen Rød
     * 
     * This class uses the Arduino class as its base. 
     * This class is for fetching the temperature readings from the arduino,
     * checking the alarm status and setting upper and lower limits for 
     * alarm and furnace.
     */
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
        private string alarmStatus;
        #endregion  

        #region Properties
        public double AlarmLowerLimit
        {
            get { return alarmLowerLimit; }
            set
            {
                alarmLowerLimit = value;
                Send("ALLO" + alarmLowerLimit);
            }
        }
        public double AlarmUpperLimit
        {
            get { return alarmUpperLimit; }
            set
            {
                alarmUpperLimit = value;
                Send("ALUP" + alarmUpperLimit);
            }
        }
        public double FurnaceLowerLimit
        {
            get { return furnaceLowerLimit; }
            set 
            { 
                furnaceLowerLimit = value;
                Send("FULO" + furnaceLowerLimit);
            } 
        }
        public double FurnaceUpperLimit
        {
            get { return furnaceUpperlimit; }
            set 
            { 
                furnaceUpperlimit = value;
                Send("FUUP" + furnaceUpperlimit);
            }
        }
        public string Temp 
        {
            get { return temp; }
        }
        public string AlarmStatus
        {
            get { return alarmStatus; }
        }
        #endregion

        #region Methods
        public string GetTemp()
        {
            try
            {
                Send("TEMP");
                Thread.Sleep(50);
                temp = Received();
                temp = temp.Replace("\r", "");
                if (temp.Substring(0, 1) == " ")
                {
                    temp = temp.Replace(" ", "");
                }
                return temp;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string CheckAlarm()
        {
                Send("CHAL");
                Thread.Sleep(50);
                alarmStatus = Received();
                alarmStatus = alarmStatus.Replace("\r", "");
                return alarmStatus;
        }
        #endregion
    }
}


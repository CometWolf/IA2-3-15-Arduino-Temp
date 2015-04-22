using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private bool furnaceActive;
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
        #endregion

        #region Methods
        public string GetTemp()
        {
            string temp;
            Send("TEMP");
            Thread.Sleep(50);
            temp = Received();
            temp = temp.Replace("\r", "");
            return temp;
        }
        public void AlarmReceived()
        {
            Send("ALOK");
        }

        public string CheckAlarm()
        {
            string message;
            Send("CHAL");
            Thread.Sleep(50);
            message = Received();
            message = message.Replace("\r", "");
            return message;
        }
        //public void SetAlarmUpper(string alarmName)
        //{
        //    Send(alarmName + alarmUpperLimit);
        //}
        //public void SetAlarmLower(string alarmName)
        //{
        //    Send(alarmName + alarmLowerLimit);
        //}
        //public void SetFurnaceUpper(string alarmName)
        //{
        //    Send(alarmName + furnaceUpperlimit);
        //}
        //public void SetFurnaceLower(string alarmName)
        //{
        //    Send(alarmName + furnaceLowerLimit);
        //}
        #endregion
    }
}


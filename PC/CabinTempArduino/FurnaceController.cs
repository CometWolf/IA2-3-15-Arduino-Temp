using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinTempArduino
{
    class FurnaceController // : Arduino
    {
        public FurnaceController(double alarmUp, double alarmLow, double furnaceUp, double furnaceLow)
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
        private string temp = "";
        private double tempValue;
        private bool furnaceActive;
        private bool alarm;
        #endregion
            
        #region Properties
        public double AlarmLowerLimit
        {
            get
            {
                return alarmLowerLimit;
            }
            set
            {
                alarmLowerLimit = value;
            }

        }
        public bool Alarm
        {
            get
            {
                return alarm; 
            }
        }
        public double TempValue
        {
            get
            {
                return tempValue;
            }
        }
        public double AlaramUpperLimit
        {
            get
            {
                return alarmUpperLimit;
            }
            set
            {
                alarmUpperLimit = value;
            }
        }
        public double FurnaceLowerLimit
        {
            get
            {
                return furnaceLowerLimit;
            }
            set
            {
                furnaceLowerLimit = value;
            }
        }
        public double FurnaceUpperLimit
        {
            get
            {
                return furnaceUpperlimit;
            }
            set
            {
                furnaceUpperlimit = value;
            }
        }
        #endregion

        #region Methods
        public bool CheckAlarm()
        {
            //if ((Receive() == "ALARM_UPPER")||(Receive() == "ALARM_LOWER"))
            //{
            //    alarm = true;
            //}
            return alarm;
        }
        public double GetTemp()
        {
            //if (Double.TryParse(Receive(), out tempValue))
            //{
            //}
            //else
            //{
            //    if(temp != "")
            //    {
            //        tempValue = Convert.ToDouble(temp);
            //    }
            //}
            return tempValue;
        #endregion
        }
    }
}

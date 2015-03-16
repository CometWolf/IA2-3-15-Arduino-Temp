using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinTempArduino
{
    class FurnaceController
    {
        #region Fields
        private double alarmLowerLimit;
        private double alarmUpperLimit;
        private double furnaceLowerLimit;
        private double furnaceUpperlimit;
        private double temp;
        private bool furnaceActive;
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
        public double Temp
        {
            get
            {
                return temp;
            }
            set
            {
                temp = value;
            }
        }
        #endregion


    }
}

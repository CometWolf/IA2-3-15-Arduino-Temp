#ifndef TempSensor_h

#include "Arduino.h"

#define TempSensor_h

class TempSensor
{
  
  private:
	  
	  byte pin;
    int range;
    int min;
    
  public:
	  
	  float getTemp();
	  
	  TempSensor(int pin,int min, int max);

};

#endif
  

#ifndef TempSensor_h

#include "Arduino.h"

#define TempSensor_h

class TempSensor
{
  
  private:
	  
	  byte pin;
    int range;
    
  public:
	  
	  float getTemp();
	  
	  TempSensor(int pin,int min, int max);

};

#endif
  

#ifndef TempSensor_h

#include "Arduino.h"

#define TempSensor_h




class TempSensor
{
  
  private:
	  
	  byte pin;
  
  public:
	  
	  float getTemp();
	  
	  TempSensor(int pin);

};

#endif
  

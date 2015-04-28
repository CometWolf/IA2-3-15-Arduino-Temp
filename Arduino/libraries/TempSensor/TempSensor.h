/*
  Written by: Martin Terjesen
  Arudino temperature sensor class. Define the temperature measured at 5v as max, and the temperature at 0v as min in the constructor.
*/
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
	  
	  TempSensor(byte pin,int min, int max);

};

#endif
  

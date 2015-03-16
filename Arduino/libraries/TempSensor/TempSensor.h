#ifndef TempSensor_h
#include "Arduino.h"
#define TempSensor_h


class TempSensor
{
  private:
	  byte pin;
	  float resolution;
  public:
	  float getTemp();
	  TempSensor(int pin, int maxValue, int minValue);
};
#endif
  

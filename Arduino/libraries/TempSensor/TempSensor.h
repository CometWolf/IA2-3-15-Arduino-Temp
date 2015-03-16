#ifndef TempSensor
#include "Arduino.h"
#define TempSensor


class TempSensor
{
  private:
	  byte pin;
	  float factor;
  public:
	  float getTemp();
	  TempSensor(int pin, int maxValue, int minValue);
};
#endif
  

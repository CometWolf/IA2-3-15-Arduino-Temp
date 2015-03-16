#include "TempSensor.h"

TempSensor(int pin, int maxValue, int minValue)
{
  this->pin = pin;
  resolution = (maxValue - minValue)/1023;
};
public float getTemp()
{ 
    return (analogRead(pin)*resolution);
};

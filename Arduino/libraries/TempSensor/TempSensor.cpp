#include "TempSensor.h"

TempSensor::TempSensor(int pin, int maxValue, int minValue)
{
  this->pin = pin;
  resolution = 1024/(maxValue - minValue);
};
float TempSensor::getTemp()
{ 
    return (analogRead(pin)/resolution);
};

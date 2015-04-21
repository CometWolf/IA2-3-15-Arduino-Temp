#include "TempSensor.h"

TempSensor::TempSensor(int pin,int min, int max)
{
	this->pin = pin;
  this-min = min;
  this->range = max-min;
};
float TempSensor::getTemp()
{
  int analogIn = analogRead(pin);
  if (analogIn == 0) {
    return min;
  }
  int inPercentage = analogIn/1023;
  int temp = range*inPercentage+min;
	return temp;
};

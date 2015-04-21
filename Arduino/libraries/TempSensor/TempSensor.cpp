#include "TempSensor.h"

TempSensor::TempSensor(int pin,int min, int max)
{
	this->pin = pin;
  this->min = min;
  this->range = max-min;
};
float TempSensor::getTemp()
{
  int analogIn = analogRead(pin);
  float inPercentage = (float)analogIn/(float)1023;
  float temp = range*inPercentage+min;
	return temp;
	
};

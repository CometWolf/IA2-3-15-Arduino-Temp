#include "TempSensor.h"

TempSensor::TempSensor(int pin,int min, int max)
{
	this->pin = pin;
  this->range = max-min;
};
float TempSensor::getTemp()
{
  int inPercentage = analogRead(pin)/1024;
  int temp = range*inPercentage-range/2
	return temp;
};

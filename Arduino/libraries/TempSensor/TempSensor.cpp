#include "TempSensor.h"

TempSensor::TempSensor(int pin)
{
	this->pin = pin;
};
float TempSensor::getTemp()
{
	return ((((analogRead(pin)*5.0) / 1024) - 0.5) * 100);
};

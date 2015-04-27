/*
  Written by: Martin Terjesen
  Arudino temperature sensor class. Define the temperature measured at 5v as max, and the temperature at 0v as min in the constructor.
*/

#include "TempSensor.h"

TempSensor::TempSensor(byte pin,int min, int max)
{
	this->pin = pin;
  this->min = min;
  this->range = max-min;
  this->range = max-min; //temperature resolution
};

float TempSensor::getTemp()
{
  int analogIn = analogRead(pin);
  float inPercentage = (float)analogIn/(float)1023; //convert in signal to percentage
  float temp = range*inPercentage+min; //Convert from in percentage temperature based on temperature range
	return temp;
};
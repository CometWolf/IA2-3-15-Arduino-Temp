/*
  Written by: Pauline Mittag Sandersen
  Arduino relay class. Simplifies relay control operations.
*/

#include "Relay.h"
#include "Arduino.h"

byte pin; 
bool state; 

bool Relay :: getState() 
{
	return state;
}

Relay :: Relay(byte pin)
{	
	this-> pin = pin;
	pinMode(pin, OUTPUT);
}

void Relay :: setState(bool state)
{
	this-> state = state;
	if (state == true)
	{
		digitalWrite(pin,HIGH); 
	}
	else
	{
		digitalWrite(pin,LOW); 
	} 
}
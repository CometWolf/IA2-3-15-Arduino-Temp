#include "Relay.h"
#include "Arduino.h"

int pin; 
bool state; 

bool Relay :: getState() 
{
	return state;
}

Relay :: Relay(int pin)
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
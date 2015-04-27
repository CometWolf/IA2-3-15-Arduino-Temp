#ifndef Relay_h
#define Relay_h

#include "Arduino.h"

class Relay
{
	public :
	byte pin;
	bool getState();
	Relay(byte pin);
	void setState(bool state);
	

	private :
	bool state;	
};

#endif


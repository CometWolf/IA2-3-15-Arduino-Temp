#ifndef Relay_h
#define Relay_h

#include "Arduino.h"

class Relay
{
	public :
	int pin;
	bool getState();
	Relay(int pin);
	void setState(bool state);
	

	private :
	bool state;	
};

#endif


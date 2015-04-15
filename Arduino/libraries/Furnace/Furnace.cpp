#include "Furnace.h"
//Constructor
Furnace::Furnace(float upperLimit, float lowerLimit, byte pin) : Relay(pin) {
	this->upperLimit = upperLimit;
	this->lowerLimit = lowerLimit;
	active = true;
}

//Methods
void Furnace::update(float temp) { //Compares the given temperature to the upper and lower limits, and toggles the furnace accordingly
	boolean newState;
	newState = (
		active //furnace enabled
		&& (temp < lowerLimit // temperature below lower limit 
		|| getState() && temp <= upperLimit //temperature climbing towards upper limit
		)
		);
	setState(newState);
}
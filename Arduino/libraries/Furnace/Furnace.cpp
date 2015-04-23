/*
  Written by: Haakon N. Unelsrød
  Arduino class for controlling a connected furnace. Temperature limits may be changed by accessing the variables directly from the object.
  Call the update function with the current temperature to update the state  of the furnace.
*/

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
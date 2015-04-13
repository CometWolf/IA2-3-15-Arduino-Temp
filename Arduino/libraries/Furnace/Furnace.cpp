#include "Furnace.h"
//Constructor
Furnace::Furnace(double float = 25,double float = 20, byte pin = 1) : Relay(pin) {
  this->upperLimit = upperLimit;
  this->lowerLimit = lowerLimit;
  active = true;
}

//Methods
void Furnace::update(float temp) { //Compares the given temperature to the upper and lower limits, and toggles the furnace accordingly
  boolean newState;
  newState = (
    active //furnace enabled
    && (
      temp < lowerLimit // temperature below lower limit
      || getState() && temp <= upperLimit //temperature climbing towards upper limit
    )
  );
  setState(newState);
}
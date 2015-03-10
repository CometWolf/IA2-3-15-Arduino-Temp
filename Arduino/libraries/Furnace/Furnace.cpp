#include "Furnace.h"
//Constructor
Furnace::Furnace(float upperLimit = 25,float lowerLimit = 20) : Relay(byte pin) {
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
      || state && temp <= upperLimit //temperature climbing towards upper limit
    )
  );
  setState(newState);
}
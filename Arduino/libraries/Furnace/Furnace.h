/*
  Written by: Haakon N. Unelsrød
  Arduino class for controlling a connected furnace. Temperature limits may be changed by accessing the variables directly from the object.
  Call the update function with the current temperature to update the state  of the furnace.
*/

#ifndef Furnace_h
#define Furnace_h

#include "Arduino.h"
#include "Relay.h"

  class Furnace : public Relay {
  public:
    float upperLimit,lowerLimit;
    boolean active;
    Furnace(float upperLimit, float lowerLimit, byte pin);
    void update(float temp);
  };

#endif

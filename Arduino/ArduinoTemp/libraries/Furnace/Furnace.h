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

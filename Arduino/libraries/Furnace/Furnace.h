#ifndef Furnace_h
#define Furnace_h

#include "Arduino.h"
#include "Relay.h"

  class Furnace : public Relay {
  public:
    float upperLimit;
    boolean active;
    Furnace(float upperLimit) : Relay(byte pin);
    void update();
  };

#endif

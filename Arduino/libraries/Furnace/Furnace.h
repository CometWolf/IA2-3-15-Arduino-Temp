#ifndef Furnace
#define Furnace

#include "Arduino.h"
#include "Relay.h"

  class Furnace : public Relay {
  public:
    float upperLimit;
    boolean active;
    Furnace(float lowerLimit = 20, float upperLimit = 25) : Relay(byte pin);
    void update();
  };

#endif

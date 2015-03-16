#ifndef Furnace
#define Furnace

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

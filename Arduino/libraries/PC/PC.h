/*
  Written by: Haakon N. Unelsrød
  Arduino to PC serial communication class. Simplifies incoming serial communication handling, letting you receive an entire string instead of single characters.
  Call begin() in setup to start serial communication.
*/

#ifndef PC_h
#include "Arduino.h"
#define PC_h

class PC {
public:
  int baudrate;
  PC();
  void begin(int baudrate);
  void send(String message);
  String receive(char endCharacter);
};
#endif
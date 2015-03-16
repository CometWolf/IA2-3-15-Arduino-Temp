#ifndef PC_h
#include "Arduino.h"
#define PC_h

class PC {
public:
  int baudrate;
  PC();
  void begin(int baudrate);
  void send(String message);
  String receive(char endCharacter[0] = "\n");
};
#endif
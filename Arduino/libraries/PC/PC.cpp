#include "PC.h"
#include "HardwareSerial.h"
//Constructor
PC::PC() {

}

//Methods
void PC::begin(int baudrate){ //starts serial communication at the specified baudrate
  Serial.begin(baudrate);
  this->baudrate = baudrate;
}

void PC::send(String message) {
  Serial.print(message);
}

String PC::receive() {
  String message = "";
  char character;
  if (Serial.available()) { //Return empty string if no incoming serial communication
    while (true) { //Read session begins
      if (Serial.available()) { //Store incoming characters in the message string, if any.
        character = Serial.read();
        if ((String)character == (String)"\n") {//end read session on newline character
          break;
        }
        message.concat(character);
      }
    } 
  }
  return message;
}

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


String PC::receive(char endCharacter[0]) { //Receive incoming serial transmission, ending on the specified character.
  String message = "";
  char character;
  if (Serial.available()) { //Return empty string if no incoming serial communication.
    while (true) { //Read session begins.
      if (Serial.available()) { //Store incoming characters in the message string, if any.
        character = Serial.read();
        if (character == endCharacter[0]) {//End read session on endCharacter.
          break;
        }
        message.concat(character);
      }
    } 
  }
  return message;
}

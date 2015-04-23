/*
  Display.h - Library for 16 pin Liquid Crystal Dislpay.
  Arduino UNO and LCD wiring:
-LCD RS pin to digital pin 12 
-LCD Enable pin to digital pin 11 
-LCD D4 pin to digital pin 5 
-LCD D5 pin to digital pin 4 
-LCD D6 pin to digital pin 3 
-LCD D7 pin to digital pin 2    
 */
#ifndef Display_h
#define Display_h

#include "Arduino.h"
#include "LiquidCrystal.h"

class Display
{
  public:
  Display(int pin1, int pin2, int pin3, int pin4);  
  void Write(String str);
  private:
  int _pin1;
  int _pin2;
  int _pin3;
  int _pin4; 
 };
 
#endif



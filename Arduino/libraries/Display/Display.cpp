#include "Arduino.h"
#include "LiquidCrystal.h"
#include "Display.h"

Display::Display(int pin1, int pin2, int pin3, int pin4)
{
  _pin1 = pin1;
  _pin2 = pin2;
  _pin3 = pin3;
  _pin4 = pin4;  
}
void Display::Write(String str)
{
  LiquidCrystal lcd(12, 11, _pin1, _pin2, _pin3,_pin4);  //(12,11,5,4,3,2)
  lcd.begin(16, 2);
  lcd.print(str);
}


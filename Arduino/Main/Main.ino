#include<Furnace.h>
#include<Display.h>
#include<PC.h>
#include<TempSensor.h>
#include<Relay.h>
#include<stdlib.h>
#include<LiquidCrystal.h>

const byte tempPin = 9;
const byte furnacePin = 8;

String alarmUpper;
String alarmLower;
String furnaceLower;
String furnaceUpper;

float alarmUpperLimit;
float alarmLowerLimit;
float furnaceUpperLimit;
float furnaceLowerLimit;
float tempValue;
char temp[5];

PC pc = PC();
Display lcd(2,3,4,5);
TempSensor tempSensor(tempPin, alarmUpperLimit, alarmLowerLimit);
Furnace furnace(20, -10, furnacePin);

void setup() 
{
  pc.begin(9600);
}

void loop() 
{
  alarmUpperLimit = alarmUpper.toFloat();
  alarmLowerLimit = alarmLower.toFloat();
  furnaceUpperLimit = furnaceUpper.toFloat();
  furnaceLowerLimit = furnaceLower.toFloat();

  tempValue = random(-17,27);
  dtostrf(tempValue, 5, 1, temp); 
  String motatt = pc.receive('\n');
  String handling = motatt.substring(0,4);
  String value = motatt.substring(4,9);
  
    if(motatt != "")
  {
    if(handling == "TEMP")
    {
      pc.send(temp);
    }
    else if(handling == "ALUP")
    {
      alarmUpper = value;
    }
    else if(handling == "ALLO")
    {
      alarmLower = value;
    }
    else if(handling == "FUUP")
    {
      furnaceUpper = value;
    }
    else if(handling == "FULO")
    {
      furnaceLower = value;
    }
    else if(handling == "ALRM")
    {
      if(tempValue < alarmLowerLimit)
      {
        pc.send("ALARM_LOW");
      }
      else if (tempValue > alarmUpperLimit)
      {
        pc.send("ALARM_UP");
      }
    }
  }
}


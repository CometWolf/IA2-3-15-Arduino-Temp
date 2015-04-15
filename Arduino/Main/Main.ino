#include<Furnace.h>
#include<PC.h>
#include<TempSensor.h>
#include<Relay.h>
#include<stdlib.h>
#include<LiquidCrystal.h>

const int tempPin = A0; 
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
char displayChar[5];

PC pc = PC();
TempSensor tempSensor(tempPin);
Furnace furnace(20, -10, furnacePin);
LiquidCrystal lcd(12,11,5,4,3,2);

void setup() 
{
  pc.begin(9600);
  lcd.begin(16,2);
  lcd.print("Origo 2. etasje!");
  lcd.setCursor(0,1);
  lcd.print("Temp:");
  lcd.setCursor(12,1);
  lcd.print("C");
}

void loop() 
{
  
  alarmUpperLimit = alarmUpper.toFloat();
  alarmLowerLimit = alarmLower.toFloat();
  
  furnaceUpperLimit = furnaceUpper.toFloat();
  furnaceLowerLimit = furnaceLower.toFloat();
  furnace.upperLimit = furnaceUpperLimit;
  furnace.lowerLimit = furnaceLowerLimit;
  
  String motatt = pc.receive('\n');
  String handling = motatt.substring(0,4);
  String value = motatt.substring(4,9);
  
  tempValue = tempSensor.getTemp();
  dtostrf(tempValue, 5, 1, temp); 
  furnace.update(tempValue);
  
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
  
  float tempFloor = floor(tempValue);
  float rest = tempValue - tempFloor;
  
  if((rest == 0)||(rest < 0.25)){
  	tempValue = tempFloor;
  }
  else if ((rest >= 0.25)||(rest < 0.75)){
  	tempValue = tempFloor + 0.5;
  }
  else if (rest >= 0.75){
  	tempValue = ceil(tempValue);
  }
  
  dtostrf(tempValue, 5, 1, displayChar); 
  String tempDisplay(displayChar);
  lcd.setCursor(6,1);
  lcd.print(tempDisplay);
}

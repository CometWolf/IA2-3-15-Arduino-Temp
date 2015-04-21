#include<Furnace.h>
#include<PC.h>
#include<TempSensor.h>
#include<Relay.h>
#include<stdlib.h>
#include<LiquidCrystal.h>

const int tempPin = A0; 
const byte furnacePin = 3;

String alarmUpper = "50";
String alarmLower = "-1";
String furnaceLower = "4";
String furnaceUpper = "20";
String checkAlarm = "NOAL";
float alarmUpperLimit;
float alarmLowerLimit;
float furnaceUpperLimit;
float furnaceLowerLimit;
float tempValue;
char temp[5];
char displayChar[5];

PC pc = PC();
TempSensor tempSensor(tempPin,-50, 100);
Furnace furnace(0, -10, furnacePin);
LiquidCrystal lcd(5,6,9,10,11,12);

void setup() 
{
  pc.begin(9600);
  lcd.begin(16,2);
  lcd.print("IA 2-3-15");
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
  
  if (checkAlarm == "NOAL")
  {
    if (((tempValue > alarmUpperLimit)||(tempValue < alarmLowerLimit))&&(motatt == ""))
  {
    if((tempValue < alarmLowerLimit)&&(handling != "ALOK"))
      {
        pc.send("ALARM_LOW");  
      }
      else if((tempValue < alarmLowerLimit)&&(handling == "ALOK"))
      {
        checkAlarm = "ALOK";
      }
      
      else if ((tempValue > alarmUpperLimit)&&(handling != "ALOK"))
      {
        pc.send("ALARM_UP");
      }
      else if ((tempValue > alarmUpperLimit)&&(handling == "ALOK"))
      {
        checkAlarm = "ALOK";
      }
    }
  }
  else if (checkAlarm == "ALOK")
  {
    if (((tempValue > alarmUpperLimit)||(tempValue < alarmLowerLimit))&&(handling == "CHAL"))
    {
      if (tempValue > alarmUpperLimit)
      {
        pc.send("ALARM_UP");
      }
      else if (tempValue < alarmLowerLimit)
      {
        pc.send("ALARM_LOW");
      }
    }
    else if(((tempValue < alarmUpperLimit)||(tempValue > alarmLowerLimit))&&((handling == "CHAL")&&(value == "NOAL")))
    {
      checkAlarm = "NOAL";
    }
    else if(((tempValue < alarmUpperLimit)||(tempValue > alarmLowerLimit))&&((handling == "CHAL")&&(value == "")))
    {
      pc.send("NOAL");
    }
    
  }
  
  if (motatt != "")
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
  }
  
  int tempFloor = floor(tempValue);
  float rest = tempValue - tempFloor;
  
  if(rest >= 0.75)
  {
    tempValue = ceil(tempValue);
  }
  else if ((rest >= 0.25)&&(rest < 0.75)){
    tempValue = tempFloor + 0.5;
  }
  else if (rest < 0.25)
  {
    tempValue = tempFloor;
  }
  
  dtostrf(tempValue, 5, 1, displayChar); 
  String tempDisplay(displayChar);
  lcd.setCursor(6,1);
  lcd.print(tempDisplay);
}

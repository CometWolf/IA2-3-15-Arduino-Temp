/*
Written by: Øystein Lorentzen Rød
*/
#include<Furnace.h>
#include<PC.h>
#include<TempSensor.h>
#include<Relay.h>
#include<stdlib.h>
#include<LiquidCrystal.h>

const int tempPin = A0; 
const byte furnacePin = 3;

String alarmUpper = "50";
String alarmLower = "-20";
String furnaceLower = "-10";
String furnaceUpper = "0";
String received;
String action;
String value;

float currentMillis;
float alarmUpperLimit;
float alarmLowerLimit;
float furnaceUpperLimit;
float furnaceLowerLimit;
float tempValue;
float previousMillis = 0;
float interval = 1000;
float previousTemp; 

char temp[5];

PC pc = PC();
TempSensor tempSensor(tempPin);
Furnace furnace(0, -10, furnacePin);
LiquidCrystal lcd(5,6,9,10,11,12);

void setup() 
{
  pc.begin(9600);
  /*
  Sets position of the display's text.
  */
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
  currentMillis = millis();
  received = pc.receive('\n');
  action = received.substring(0,4);   //action stores the 4 first characters in the received string.
  value = received.substring(4,9);    //value stores the 5 last characters in the received string.
  tempValue = tempSensor.getTemp();
  dtostrf(tempValue, 5, 1, temp);     //the characters from tempValue is inserted to the temp array.
  furnace.update(tempValue); 
  
  /*
  If the arduino receives any type of string from the 
  pc.receive method, it reacts accordingly. It either sends
  the temperature, sets alarm or furnace limits, or 
  sends alarm status.
  */
  if (received != "")
  {
    if(action == "TEMP")
    {
      pc.send(temp);
    }
    else if(action == "ALUP")
    {
      alarmUpper = value;
    }
    else if(action == "ALLO")
    {
      alarmLower = value;
    }
    else if(action == "FUUP")
    {
      furnaceUpper = value;
    }
    else if(action == "FULO")
    {
      furnaceLower = value;
    }
    else if (action == "CHAL")
    {
      if ((tempValue > alarmUpperLimit)||(tempValue < alarmLowerLimit))
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
      else
      {
        pc.send("NO_ALARM");
      }
    }
  }
  
  String tempDisplay(temp);
  lcd.setCursor(6,1);
  /*
  Every second the lcd displays the temperature. If the 
  temperature changes are irregular, there might be a 
  problem with the temperature sensor. The furnace limits
  is set to -51 (tempValue is is never lower than -51), 
  so that the furnace does not turn on. 
  */
  if (currentMillis - previousMillis > interval)
  {
    lcd.print(tempDisplay);
    if((abs(tempValue - previousTemp) > 30)||(tempValue == -50))
    {
      furnace.update(25.0);
      furnaceLower = "-51.0";
      furnaceUpper = "-51.0";
    }
    previousMillis = currentMillis;
    previousTemp = tempValue;
  }
}

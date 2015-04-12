#include<Furnace.h>
#include<Display.h>
#include<PC.h>
#include<TempSensor.h>
#include<stdlib.h>

const byte tempPin = 9;
const byte furnacePin = 8;

float alarmUpperLimit;
float alarmLowerLimit;
float furnaceUpperLimit;
float furnaceLowerLimit;
float tempValue;

char numChar[6]
String temp = "";

void setup()
{ 
  PC pc();
 
  // Gathers upper and lower temperature limits using the PC class.
  // A character is given to get the right value from the main program.
  alarmUpperLimit = (pc.receive('U')).toFloat();
  alarmLowerLimit = (pc.receive('L')).toFloat();
  furnaceUpperLimit = (pc.receive('W')).toFloat();
  furnaceLowerLimit = (pc.receive('I')).toFloat();
   
  TempSensor tempSensor(tempPin, alarmUpperLimit, alarmLowerLimit);
  Furnace furnace(furnaceUpperLimit, furnaceLowerLimit, furnacePin);
  Display lcd(2,3,4,5);
  
  pc.begin(9600);
  Serial.begin(9600);
}  
loop()
{
  delay(1000);
  
  tempValue = tempSensor.getTemp();
  
  dtostrf(tempValue, 4, 3, numChar);      //Used to convert tempValue's digits to chars and assigns them to an array.
  
  for(int i = 0; i < sizeof(numChar); i++)    //inserts the chars into a string. 
  {
	  temp += numChar[i];
  }
  
  lcd.Write(temp); 		//Sends the temp string to the display
  Alarm(tempValue);		//Calls on alarm method
  furnace.update(tempValue); 	//Keeps the furnace updated on tempValue
  if(pc.receive == "temp")
  {
    pc.send(temp);
  }  
}

void Alarm(float temp)
{
// If the temperature goes above or under the assorted values, 
// a string of text will be sent to the main program. 	
  if (tempValue >= alarmUpperLimit)
  {
	  pc.send("ALARM_UPPER");
  }
  if else (tempValue <= alarmLowerLimit)
  {
	  pc.send("ALARM_LOWER  ");
  }
}

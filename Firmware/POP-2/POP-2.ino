#include <Arduino.h>
#include <EEPROM.h>
#include <LCD.h>
#include <LiquidCrystal_I2C.h>
#include <Wire.h>
#include "RTClib.h"
#include <Time.h>
#include "DS1307RTC.h"
#include "TimeLib.h"

#define VoltRMS "\002D00\003"
#define AmpRMS  "\002D01\003"
#define WattHour "\002D0A\003"


RTC_DS1307 rtc;
LiquidCrystal_I2C lcd(0x27, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE);  // Set the LCD I2C address

//const int DS1307 = 0x68; // Address of DS1307 
const int timeByteSize = 8;
const int batByteSize = 6;
const int wattReadingSize =12;
const int energyReadingSize = 12;
const int peakTimeStart_EEPROM_Addr = 0;
const int peakTimeStop_EEPROM_Addr = 10;
const int nonPeakTimeStart_EEPROM_Addr = 20;
const int nonPeakTimeStop_EEPROM_Addr = 30;
const int batteryHiVoltageLevel_EEPROM_Addr = 40;
const int batteryLoVoltageLevel_EEPROM_Addr = 50;
const int batteryHiCurrentLevel_EEPROM_Addr = 60;
const int batteryLoCurrentLevel_EEPROM_Addr = 70;
//const int wattmeterReading_EEPROM_Addr = 80;
const int peakRate_EEPROM_Addr = 90;
const int nonPeakRate_EEPROM_Addr = 100;
const int energyCost_EEPROM_Addr = 110;
const int wattmeterReading_EEPROM_Addr = 130;

const int BLINK = 13;
const int POWER_SOURCE_SELECT = 10;
//const int POWER_SOURCE_SELECT2 = 11;
const int BATT_USE_SELECT = 8;
const int RECT_USE_ONOFF = 9;
const int ARROW_UP = 21;
const int ARROW_DN = 22;
const byte INTERRUPT_PIN = 2;
const int MAX_COUNT = 25;



//current sensor settings
const float VCC   = 5.0;// supply voltage is from 4.5 to 5.5V. Normally 5V.
const int model = 2;   // enter the model number (see below)
int offset =5;// set the correction offset value
//float cutOffLimit = 0;// set the current which below that value, doesn't matter. Or set 0.5
const float QOV =   0.5 * VCC;// set quiescent Output voltage of 0.5V
float voltage;// internal variable for voltage
float sensitivity[] ={
          0.185,// for ACS712ELCTR-05B-T
          0.100,// for ACS712ELCTR-20A-T
          0.066// for ACS712ELCTR-30A-T
         }; 

 //analog input 2 (battery voltage level)
int battVoltageLevel = A1;
int battCurrentLevel = A0; //analog input 3 (battery current level)
float BatteryVoltageLevel;
float BatteryCurrentLevel;
float WattmeterLevel;
float InitWattmeterLevel;
int chargingState;
int presentPeriod;
int previousPeriod;
int chargeLevelCount = 0;
bool automated = true;
unsigned int previousTimeValue = 0;
char batteryHiVoltageArray[batByteSize];
char batteryLoVoltageArray[batByteSize];
char batteryHiCurrentArray[batByteSize];
char batteryLoCurrentArray[batByteSize];
char statusArray[] = "00000000";
char blinkChar = ' ';
String peakTimeStart = "06:00 AM";
String peakTimeStop = "05:59 PM";
String nonPeakTimeStart = "06:00 PM";
String nonPeakTimeStop = "05:59 AM";
String currentMonth;
String currentDay;
String currentYear;
String currentDayOfWeek;
String currentHour;
String currentMinute;
String currentSecond;
String currentAMPM;
String firstLineDisplay;
String secondLineDisplay;
String thirdLineDisplay;
String fourthLineDisplay;
float batteryHiVoltageLevel;
float batteryLoVoltageLevel;
float batteryHiCurrentLevel;
float batteryLoCurrentLevel;
float lastSavedWattmeterReading;
float lastSavedEnergyCost;
float totalRunningWattmeterReading;
float totalRunningEnergyCost;
float peakRate;
float nonPeakRate;
long debouncingTime = 200;
volatile unsigned long last_micros;
volatile int displayNum = 0;
volatile int displayCount = 0;
double delayToUpdate;
DateTime newNow;

//VOLTAGE DIVIDER
float vPow = 5;
float r1 = 100000;
float r2 = 50000;

//0-Utility or Local Power (0=Utility, 1=Local)
//1-Battery ConneCtion (1=ConneCted to Charger, 0=ConneCted to Inverter)
//2-Rectifier Status (1=ConneCted to Utility, 0=Not ConneCted to Utility)
//3-Battery Charging (1=Charging, 0=Not Charging)
//4-Battery Charging State (1=Fully Charge, 0=Not Fully Charged or Discharged)
//5-Peak, Off-Peak, Null
//6-Peak, Off-Peak, Null (00=Off-Peak, 10=Peak, 01=Null, 11=not used)
//7-Auto or Manual (0=Auto, 1=Manual)
//pin settings
//pin 10 - relay for transfer of power between utility power and local power
//pin 8 - relay for transfer of battery between Rectifier and Inverter
//pin 7 - relay for activating Rectifier

void(* resetFunc) (void) = 0;

// special characters
byte newChar0[8] = {B00000,B00000,B00000,B00000,B00000,B00000,B00000,B00000};
byte newChar1[8] = {B00000,B00000,B00000,B00100,B00000,B00000,B00000,B00000};
byte newChar2[8] = {B00000,B00000,B01110,B01010,B01110,B00000,B00000,B00000};
byte newChar3[8] = {B00000,B11111,B10001,B10001,B10001,B11111,B00000,B00000};
byte arrowUp[8] = {B00100,B01110,B10101,B00100,B00100,B00100,B00100,B00100};
byte arrowDn[8] = {B00100,B00100,B00100,B00100,B00100,B10101,B01110,B00100};

void setup() {
    //initialize digital pins
    //cli();
    //wdt_disable();
    
    pinMode(BLINK, OUTPUT);
    pinMode(POWER_SOURCE_SELECT, OUTPUT);
    //pinMode(POWER_SOURCE_SELECT2, OUTPUT);
    pinMode(BATT_USE_SELECT, OUTPUT);
    pinMode(RECT_USE_ONOFF, OUTPUT);
    pinMode(INTERRUPT_PIN, INPUT);
    transferToUtilityPower();
    redirectBatteryToCharger();
    turnOnRectifier();

    //activate external peripherals
    Serial.begin(9600);
    Serial1.begin(9600);
    Wire.begin();
    rtc.begin();
    lcd.begin(20, 4);
    
    lcd.clear();
    lcd.setCursor(8,0);
    lcd.print("****");
    lcd.setCursor(4,1);
    lcd.print("Peak Off-Peak   ");
    lcd.setCursor(3,2);
    lcd.print("System ver. 3.5 ");
    lcd.setCursor(8,3);
    lcd.print("****");
    delay(1000);
    //Introduction();

    newNow = rtc.now(); 
    currentMonth = newNow.month();
    currentDay = newNow.day();
    currentYear = newNow.year();
    currentHour = getNormalizedHour(newNow.hour());
    currentMinute = getNormalizedMinute(newNow.minute());  
    //currentSecond = getNormalizedSecond(newNow.second()); 
    //currentDayOfWeek = getWeekday(newNow.DayOfWeek());   
    currentAMPM = getAMPM(newNow.hour());
    delayToUpdate = millis();
    
    //load settings
    peakTimeStart = readFromEEPROM(peakTimeStart_EEPROM_Addr,timeByteSize);
    peakTimeStop = readFromEEPROM(peakTimeStop_EEPROM_Addr,timeByteSize);  
    nonPeakTimeStart = readFromEEPROM(nonPeakTimeStart_EEPROM_Addr,timeByteSize);
    nonPeakTimeStop = readFromEEPROM(nonPeakTimeStop_EEPROM_Addr,timeByteSize);  
    readFromEEPROM(batteryHiVoltageLevel_EEPROM_Addr,5).toCharArray(batteryHiVoltageArray,6);
    readFromEEPROM(batteryLoVoltageLevel_EEPROM_Addr,5).toCharArray(batteryLoVoltageArray,6);
    readFromEEPROM(batteryHiCurrentLevel_EEPROM_Addr,5).toCharArray(batteryHiCurrentArray,6);
    readFromEEPROM(batteryLoCurrentLevel_EEPROM_Addr,5).toCharArray(batteryLoCurrentArray,6);
    batteryHiVoltageLevel = atof(batteryHiVoltageArray);
    batteryLoVoltageLevel = atof(batteryLoVoltageArray);
    batteryHiCurrentLevel = atof(batteryHiCurrentArray);
    batteryLoCurrentLevel = atof(batteryLoCurrentArray);
    peakRate = readFromEEPROM(peakRate_EEPROM_Addr,5).toFloat();
    nonPeakRate = readFromEEPROM(nonPeakRate_EEPROM_Addr,5).toFloat();
    lastSavedWattmeterReading = readFromEEPROM(wattmeterReading_EEPROM_Addr,wattReadingSize).toFloat();
    lastSavedEnergyCost = readFromEEPROM(energyCost_EEPROM_Addr,energyReadingSize).toFloat();
   
    getWattHourMeterReading();
    InitWattmeterLevel = WattmeterLevel;
    attachInterrupt(digitalPinToInterrupt(2), checkButtonISR, FALLING);
}

void loop() {
  if (blinkChar == ' '){
    blinkChar = ':';
  }
  else if(blinkChar == ':'){
    blinkChar = ' ';
  }
  digitalWrite(BLINK,!digitalRead(BLINK));
  if (displayCount > 0){displaySettings();}
  
  //Update Battery Status
  checkBatteryStatus();
  getWattHourMeterReading();
  updateTotalWattHourMeter();

  //Check Time Period
  if ((millis() - delayToUpdate) > 30000) {
    newNow = rtc.now(); 
    currentMonth = newNow.month();
    currentDay = newNow.day();
    currentYear = newNow.year();
    currentHour = getNormalizedHour(newNow.hour());
    currentMinute = getNormalizedMinute(newNow.minute());  
    //currentSecond = getNormalizedSecond(newNow.second());   
    //currentDayOfWeek = getWeekday(newNow.Wday()); 
    currentAMPM = getAMPM(newNow.hour());
    delayToUpdate = millis();
  }

//------------------- Check Peak Off-Peak -------------------
   previousPeriod = presentPeriod;
   presentPeriod = getPeriod(timeValue(currentHour + ":" + currentMinute + " " + currentAMPM));

   if (automated == true) {    
      statusArray[7]='0';
      switch(presentPeriod){
        case 1: //Off-Peak
          updateTotalEnergyCost(nonPeakRate);
          transferToUtilityPower(); // switch power to Meralco
          redirectBatteryToCharger();
          statusArray[5]='0';
          statusArray[6]='0';
          
          if (previousPeriod != presentPeriod){chargingState = 1;}

          firstLineDisplay = "OPP  " + currentHour + blinkChar + currentMinute + " " + currentAMPM + "  A";
          if (chargingState){secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A " + "Chrgg";}
          else {secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A " + "Stdby";}
          thirdLineDisplay = (String)totalRunningWattmeterReading + " WH";
          fourthLineDisplay = "P " + (String) totalRunningEnergyCost;
          
          if (chargingState){
            turnOnRectifier();
          }
          else{
            turnOffRectifier();
          }
          break;
        case 2: //Peak        
          updateTotalEnergyCost(peakRate);
          turnOffRectifier();
          statusArray[5]='1'; //It's peak period
          statusArray[6]='0';
          
          if (previousPeriod != presentPeriod){chargingState = 0;}
           
          firstLineDisplay = "PP   " + currentHour + blinkChar + currentMinute + " " + currentAMPM + "  A";
          if (chargingState){secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A " + "Stdby";}
          else {secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A " + "Dschg";}
          thirdLineDisplay = (String)totalRunningWattmeterReading + " WH";
          fourthLineDisplay = "P " + (String) totalRunningEnergyCost;
          
          if (chargingState){
            redirectBatteryToCharger(); 
            transferToUtilityPower();
          }
          else{
            redirectBatteryToInverter();
            transferToLocalPower();  // switch power to Battery 
          }        
          break;
        case 0: //Null
          transferToUtilityPower(); // switch power to Meralco
          redirectBatteryToCharger();
          turnOffRectifier();
          statusArray[5]='0';
          statusArray[6]='1';
          firstLineDisplay = "NUL   " + currentHour + blinkChar + currentMinute + " " + currentAMPM + "  A";
          secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A ";
          thirdLineDisplay = (String)totalRunningWattmeterReading + " WH";
          fourthLineDisplay = "P " + (String) totalRunningEnergyCost;
          //go to safe option
          ///transferToUtilityPower(); // switch power to Meralco
          ///redirectBatteryToCharger();
          ///turnOffRectifier();
          break;
        default:
          statusArray[5]='1';
          statusArray[6]='1';
          break;
      }
   }
   
   else if(automated == false){ //manual mode  
     statusArray[7]='1';
     if (presentPeriod == 1) { //off-peak
        updateTotalEnergyCost(nonPeakRate);
        statusArray[5]='0';
        statusArray[6]='0';
        if (previousPeriod != presentPeriod){chargingState = 1;}
        firstLineDisplay = "OPP  " + currentHour + blinkChar + currentMinute + " " + currentAMPM + "  M";
        if (chargingState){secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A " + "Chrgg";}
        else {secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A " + "Stdby";}
        thirdLineDisplay = (String)totalRunningWattmeterReading + " WH";
        fourthLineDisplay = "P " + (String) totalRunningEnergyCost;              
     }
     else if(presentPeriod == 2){ //peak
        updateTotalEnergyCost(peakRate);
        statusArray[5]='1'; //It's peak period
        statusArray[6]='0';
        if (previousPeriod != presentPeriod){chargingState = 0;}
        firstLineDisplay = "PP   " + currentHour + blinkChar + currentMinute + " " + currentAMPM + "  M";
        if (chargingState){secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A " + "Stdby";}
        else {secondLineDisplay = (String)BatteryVoltageLevel + "V "+ (String)BatteryCurrentLevel + "A " + "Dschg";}
        thirdLineDisplay = (String)totalRunningWattmeterReading + " WH";
        fourthLineDisplay = "P " + (String) totalRunningEnergyCost;        
     }
   }
      lcd.setCursor(0,0);
      lcd.print(writeLCDLine(firstLineDisplay));
      lcd.setCursor(0,1);
      lcd.print(writeLCDLine(secondLineDisplay));
      lcd.setCursor(0,2);
      lcd.print(writeLCDLine(thirdLineDisplay));
      lcd.setCursor(0,3);
      lcd.print(writeLCDLine(fourthLineDisplay));

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
   //*** Checking Communications Interface
   String serialData = extractSerialData2();
   String commandData;
   if (serialData.length()>0){
     commandData = extractField(serialData,1);
       // Check for heartbeat
       if (commandData == "GET-SETTINGS"){
          Serial.println("SETTINGS|" + peakTimeStart + "|" + peakTimeStop + "|" + nonPeakTimeStart + "|" + nonPeakTimeStop + "|"
          + batteryHiVoltageArray + "|" + batteryLoVoltageArray + "|" + batteryHiCurrentArray + "|" + batteryLoCurrentArray + "|"
          + (String) peakRate + "|" + (String) nonPeakRate);  
       }
       if (commandData == "GET-ALL"){
          Serial.println("ALL|" + (String)statusArray + "|" + (String)BatteryVoltageLevel + "|" 
          + (String)BatteryCurrentLevel + "|" + (String)WattmeterLevel + "|" + (String)totalRunningWattmeterReading + "|" 
          + (String) totalRunningEnergyCost + "|" + currentMonth + '-' + currentDay + '-' + currentYear + ' ' + currentHour + ':' + currentMinute + ' ' + currentAMPM + "|"
          + (String) getRMSVoltageReading() + "|" + (String) getRMSCurrentReading());
          
       }
       if (commandData == "HB2"){
         Serial.println(statusArray);
         Serial.println((String)BatteryVoltageLevel);
         Serial.println((String)BatteryCurrentLevel);
       }
       else if (commandData == "HB"){
         Serial.print("STATUS|");
         Serial.println(statusArray);
       }
       else if(commandData == "RBATLVL"){
         Serial.print("BATLVL|");
         Serial.println((String)BatteryVoltageLevel);
       }
       else if(commandData == "RBATAMP"){
         Serial.print("BATAMP|");
         Serial.println((String)BatteryCurrentLevel);
       }
       else if (commandData == "RWATTHR"){
        Serial.print("WATTHR|");
        Serial.println((String)WattmeterLevel);
       }
       else if (commandData == "RVOLTRMS"){
        Serial.println("VOLTRMS|" + (String) getRMSVoltageReading());
       }
       else if (commandData == "RAMPRMS"){
        Serial.println("AMPRMS|" + (String) getRMSCurrentReading());
       }
       else if (commandData == "RTOTWATTHR"){
        Serial.print("TOTWATTHR|");
        Serial.println((String)totalRunningWattmeterReading);
       }
       else if (commandData == "RTOTCOST"){
        Serial.println("TOTCOST|" + (String)totalRunningEnergyCost);
       }
       else if(commandData == "RCLOCK"){
         Serial.print("CLOCK|");
         Serial.print(currentMonth);
         Serial.print('-');
         Serial.print(currentDay);
         Serial.print('-');
         Serial.print(currentYear);
         Serial.print(' ');
         Serial.println(currentHour + ':' + currentMinute + ' ' + currentAMPM);
       }
       else if(commandData == "RBATCHAR"){
         Serial.print("BATCHAR|");
         Serial.println(batteryHiVoltageArray);
       }
       else if(commandData == "RBATDISC"){
         Serial.print("BATDISC|");
         Serial.println(batteryLoVoltageArray);
       }
       else if(commandData == "RBATHIAMP"){
         Serial.print("BATHIAMP|");
         Serial.println(batteryHiCurrentArray);
       }
       else if(commandData == "RBATLOAMP"){
         Serial.print("BATLOAMP|");
         Serial.println(batteryLoCurrentArray);
       }
       else if(commandData == "RPTSTART"){
         Serial.print("PTSTART|");
         Serial.println(peakTimeStart);       
       }
       else if (commandData == "RPTSTOP"){
         Serial.print("PTSTOP|");
         Serial.println(peakTimeStop);
       }
       else if(commandData == "RNPTSTART"){
         Serial.print("NPTSTART|");
         Serial.println(nonPeakTimeStart);  
     }
       else if(commandData == "RNPTSTOP"){
         Serial.print("NPTSTOP|");
         Serial.println(nonPeakTimeStop);
     } 
       else if(commandData == "RPEAKRATE"){
         Serial.println("PEAKRATE|" + (String)peakRate);
       }
       else if(commandData == "RNPEAKRATE"){
         Serial.println("NPEAKRATE|" + (String)nonPeakRate);
       }
       else if(commandData == "WPTSTART"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(peakTimeStart_EEPROM_Addr,dataData);
         peakTimeStart = readFromEEPROM(peakTimeStart_EEPROM_Addr,timeByteSize);
         Serial.print("PTSTART|");
         Serial.println(peakTimeStart);
       }
       else if(commandData == "WPTSTOP"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(peakTimeStop_EEPROM_Addr,dataData);
         peakTimeStop = readFromEEPROM(peakTimeStop_EEPROM_Addr,timeByteSize); 
         Serial.print("PTSTOP|");
         Serial.println(peakTimeStop);
       }
       else if(commandData == "WNPTSTART"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(nonPeakTimeStart_EEPROM_Addr,dataData);
         nonPeakTimeStart = readFromEEPROM(nonPeakTimeStart_EEPROM_Addr,timeByteSize);
         Serial.print("NPTSTART|");
         Serial.println(nonPeakTimeStart);
       }
       else if(commandData == "WNPTSTOP"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(nonPeakTimeStop_EEPROM_Addr,dataData);
         nonPeakTimeStop = readFromEEPROM(nonPeakTimeStop_EEPROM_Addr,timeByteSize);
         Serial.print("NPTSTOP|");
         Serial.println(nonPeakTimeStop);
       }
       else if(commandData == "WPEAKRATE"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(peakRate_EEPROM_Addr,dataData);
         peakRate = readFromEEPROM(peakRate_EEPROM_Addr,5).toFloat();
         Serial.println("PEAKRATE|" + (String)peakRate);
       }
       else if(commandData == "WNPEAKRATE"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(nonPeakRate_EEPROM_Addr,dataData);
         nonPeakRate = readFromEEPROM(nonPeakRate_EEPROM_Addr,5).toFloat();
         Serial.println("NPEAKRATE|" + (String)nonPeakRate);
       }
       else if(commandData == "WBATCHAR"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(batteryHiVoltageLevel_EEPROM_Addr, dataData);
         readFromEEPROM(batteryHiVoltageLevel_EEPROM_Addr,batByteSize).toCharArray(batteryHiVoltageArray,batByteSize);
         batteryHiVoltageLevel = atof(batteryHiVoltageArray);
         Serial.print("BATCHAR|");
         Serial.println(batteryHiVoltageArray);
       }
       else if(commandData == "WBATDISC"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(batteryLoVoltageLevel_EEPROM_Addr, dataData);
         readFromEEPROM(batteryLoVoltageLevel_EEPROM_Addr,batByteSize).toCharArray(batteryLoVoltageArray,batByteSize);
         batteryLoVoltageLevel = atof(batteryLoVoltageArray);
         Serial.print("BATDISC|");
         Serial.println(batteryLoVoltageArray);
       }
       else if(commandData == "WBATHIAMP"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(batteryHiCurrentLevel_EEPROM_Addr, dataData);
         readFromEEPROM(batteryHiCurrentLevel_EEPROM_Addr,batByteSize).toCharArray(batteryHiCurrentArray,batByteSize);
         batteryHiCurrentLevel = atof(batteryHiCurrentArray);
         Serial.print("BATHIAMP|");
         Serial.println(batteryHiCurrentArray);
       }
       else if(commandData == "WBATLOAMP"){
         String dataData = extractField(serialData,2);
         saveToEEPROM(batteryLoCurrentLevel_EEPROM_Addr, dataData);
         readFromEEPROM(batteryLoCurrentLevel_EEPROM_Addr,batByteSize).toCharArray(batteryLoCurrentArray,batByteSize);
         batteryLoCurrentLevel = atof(batteryLoCurrentArray);
          Serial.print("BATLOAMP|");
         Serial.println(batteryLoCurrentArray);
       }
       else if(commandData == "WCLOCK"){
         String dataData = extractField(serialData,2);
         int dmonth = dataData.substring(0,2).toInt(); //month (01-12)
         int dday = dataData.substring(3,5).toInt();   //day (01-31)
         int dyear = dataData.substring(6,8).toInt(); //year (00-99)
         int dhour = dataData.substring(9,11).toInt(); //hour  
         int dminute = dataData.substring(12,14).toInt(); //minute
         int dsecond = dataData.substring(15,17).toInt(); //second
         rtc.adjust(DateTime(dyear,dmonth,dday,dhour,dminute,dsecond));
         DateTime newDateTime = rtc.now();
         Serial.print("CLOCK|");
         Serial.print(newDateTime.month(), DEC);
         Serial.print('-');
         Serial.print(newDateTime.day(), DEC);
         Serial.print('-');
         Serial.print(newDateTime.year(), DEC);
         Serial.print(' ');
         Serial.print(getNormalizedHour(newDateTime.hour()));
         Serial.print(':');
         Serial.print(getNormalizedMinute(newDateTime.minute()));
         Serial.print(':');
         Serial.print(getNormalizedSecond(newDateTime.second()));
         Serial.print(' ');
         Serial.println(getAMPM(newDateTime.hour()));
       }
       else if (commandData == "RST-WATTHR"){
         zeroWattHour();
         delay(500);
         getWattHourMeterReading();
         InitWattmeterLevel = WattmeterLevel;
         Serial.println("WATTHR|" + (String)WattmeterLevel);
       }
       else if (commandData == "RST-TOTWATTHR"){
         saveToEEPROM2(wattmeterReading_EEPROM_Addr,"000000000000");
         lastSavedWattmeterReading = readFromEEPROM(wattmeterReading_EEPROM_Addr,wattReadingSize).toFloat();
         Serial.println("TOTWATTHR|" + (String) lastSavedWattmeterReading); 
         if (lastSavedWattmeterReading == 0.0){
            saveToEEPROM2(energyCost_EEPROM_Addr,"000000000000");
            lastSavedEnergyCost = readFromEEPROM(energyCost_EEPROM_Addr,energyReadingSize).toFloat();
         }
       }
       
       else if (commandData == "RESET"){
         Serial.println("Resetting");
         delay(1000);
         resetFunc();
       }
       else if (commandData == "OFFRECT"){
         turnOffRectifier();
         Serial.println("Rectifier Off");
       }
       else if (commandData == "ONRECT"){
         turnOnRectifier();
         Serial.println("Rectifier On");
       }
       else if (commandData == "BATTOCHARGER"){
         redirectBatteryToCharger(); 
         Serial.println("Battery is connected to Charger");        
       }
       else if (commandData == "BATTOINVERTER"){
         redirectBatteryToInverter(); 
         Serial.println("Battery is connected to Inverter");        
       }
       else if (commandData == "TRANSTOUTIL"){
        transferToUtilityPower();
        Serial.println("Load is connected to Utility");
       }
       else if (commandData == "TRANSTOLOCAL"){
        transferToLocalPower();
        Serial.println("Load is connected to Local Power");
       

       }
       else if (commandData == "AUTO"){
        automated = true;
        Serial.println("System is in auto mode.");
       }
        else if (commandData == "MANUAL"){
        automated = false;
        Serial.println("System is in manual mode.");
       }
   }
}

//***** Below this line are the subroutines *****
void displayHiLoVolt(){
  lcd.setCursor(0,0);
  lcd.print("HiVolt:");
  lcd.print(batteryHiVoltageArray);
  lcd.print(" V  ");
  lcd.setCursor(0,1);
  lcd.print("LoVolt:");
  lcd.print(batteryLoVoltageArray);
  lcd.print(" V  ");
}
void displayHiLoAmp(){
  lcd.setCursor(0,0);
  lcd.print("HiAmp:");
  lcd.print(batteryHiCurrentArray);
  lcd.print(" A   ");
  lcd.setCursor(0,1);
  lcd.print("LoAmp:");
  lcd.print(batteryLoCurrentArray);
  lcd.print(" A   ");
}
void displayPeakPeriod(){
   lcd.setCursor(0,0);
   lcd.print("PkStr:");
   lcd.print(peakTimeStart);
   lcd.print("  ");
   lcd.setCursor(0,1);
   lcd.print("PkStp:");
   lcd.print(peakTimeStop);
   lcd.print("  ");
}
void displayOffPeakPeriod(){
   lcd.setCursor(0,0);
   lcd.print("OPStr:");
   lcd.print(nonPeakTimeStart);
   lcd.print("  ");
   lcd.setCursor(0,1);
   lcd.print("OPStp:");
   lcd.print(nonPeakTimeStop);
   lcd.print("  ");
}

String extractSerialData(){
  char inData[30]="";
  char inChar=0;
  byte numBytesAvailable;

  numBytesAvailable= Serial.available();
  int i=0;
  if (numBytesAvailable > 0){
    for (i;i<numBytesAvailable;i++){
      inChar= Serial.read();
      inData[i] = inChar;
    }
    inData[i] = '\0';
  }
  if (i > 0){
    return inData;
  }
  else{
    return "";
  }
}  

String extractSerialData2(){
  Serial.setTimeout(10);
  return Serial.readStringUntil('\n');
}

String extractField(String rawString, int fieldNum){
   char dataArray[30];
   char fieldArrayC[25];   
   char fieldArrayD[25];  
   char inChar;
   
   rawString.toCharArray(dataArray,rawString.length()+1);
   
   if (fieldNum == 1){
     int i=0;
     for(i;i<rawString.length();i++){
       inChar = dataArray[i];
       if (inChar == '|'){
         break;
       }
       fieldArrayC[i] = inChar;
     } 
     fieldArrayC[i]='\0';
     return fieldArrayC;
   }
   else if (fieldNum == 2) {
     //i=i+1;
     int i = rawString.indexOf('|')+1;
     int j=i;
     for(i;i<rawString.length();i++){
       inChar = dataArray[i];
       fieldArrayD[i-j] = inChar;
     }
     fieldArrayD[i-j]='\0';
     return fieldArrayD;
   }
   return "";
}

void saveToEEPROM(int memAddress, String dataString){
   char dataArray[9]; 
   
   dataString.toCharArray(dataArray,dataString.length()+1);
   for (int i=memAddress; i <= (dataString.length()-1+memAddress); i++){
      EEPROM.write(i,dataArray[i-memAddress]);
   } 
   return;   
}

void saveToEEPROM2(int memAddress, String dataString){
   char dataArray[13]; 
   
   dataString.toCharArray(dataArray,dataString.length()+1);
   for (int i=memAddress; i <= (dataString.length()-1+memAddress); i++){
      EEPROM.write(i,dataArray[i-memAddress]);
   } 
   return;   
}

String readFromEEPROM(int memAddress, int memSize){
  String dataString = ""; 

  for (int i=memAddress; i < (memAddress+memSize); i++){
    dataString=dataString+char(EEPROM.read(i));
  }
  return dataString;
}

//int getPeriod(String trackTime){
int getPeriod(unsigned int presentTimeValue){    
      if ((presentTimeValue >= timeValue(nonPeakTimeStart)) && (presentTimeValue <= timeValue("11:59 PM"))){ //"11:59 PM"
       return 1;//presentPeriod = 1;
      }
      else if ((presentTimeValue >= timeValue("00:00 AM")) && (presentTimeValue <= timeValue(nonPeakTimeStop))){ //"00:00 AM"
       return 1;//presentPeriod = 1;
      }
      else if ((presentTimeValue >= timeValue(peakTimeStart)) && (presentTimeValue <= timeValue(peakTimeStop))){
       return 2;//presentPeriod = 2;
      }
      else {
        return 0;
      }
}  

void transferToUtilityPower(){  //Switch to Meralco
    digitalWrite(POWER_SOURCE_SELECT, HIGH); //switch power relay to meco
    //digitalWrite(POWER_SOURCE_SELECT2, LOW); //switch power relay to meco
    statusArray[0]='0'; //Load is connected to Utility Power
    delay(500);
}
void transferToLocalPower(){  //Switch to Battery Power
    digitalWrite(POWER_SOURCE_SELECT, LOW); //switch power relay to Battery
    //digitalWrite(POWER_SOURCE_SELECT2, HIGH); //for additional relay
    statusArray[0]='1'; //Load is connected to Local Power
    delay(500);
}
void redirectBatteryToCharger(){
    digitalWrite(BATT_USE_SELECT, LOW);  //redireCt battery to Charger
    statusArray[1]='1'; //Battery is connected to Charger
    delay(500);
}
void redirectBatteryToInverter(){
    digitalWrite(BATT_USE_SELECT, HIGH);  //redireCt battery to Inverter
    statusArray[1]='0'; //Battery is connected to Inverter
    delay(500);
}

void turnOnRectifier(){
    digitalWrite(RECT_USE_ONOFF, LOW);  //turn on reCtifier
    statusArray[2]='1'; //Rectifier is ON
    statusArray[3]='1'; //Battery is charging
    delay(500);
}
void turnOffRectifier(){
    digitalWrite(RECT_USE_ONOFF, HIGH);  //turn off reCtifier
    statusArray[2]='0'; //Rectifier is OFF
    statusArray[3]='0'; //Battery is not charging
    delay(500);
}

float checkBatteryVoltageLevel(){
  float batLevel = 0;
  float batLevelSample;
  for (int i = 0; i < 10; i++){
    batLevelSample =analogRead(battVoltageLevel);
    batLevel = batLevel + batLevelSample/10;
    batLevel = batLevelSample;
    delay (10);
  }
  float v = (batLevelSample * vPow) / 1024.0;
   float v2 = v / (r2 / (r1 + r2));
  return (v2);
}

float checkBatteryCurrentLevel(){
     float batLevel = 0;
        float reading;
        for (int i = 0; i < 20; i++){
          reading =analogRead(battCurrentLevel);
          batLevel = batLevel + reading/20;
          delay (10);
        }
         float voltage_raw =   (5.0 / 1023.0)* batLevel;// Read the voltage from sensor
        voltage =  voltage_raw - QOV + 0.005 ;// 0.000 is a value to make voltage zero when there is no current
        float current = voltage / sensitivity[model];
       return (current);
    }


int checkBatteryStatus(){
  BatteryVoltageLevel = checkBatteryVoltageLevel();
  BatteryCurrentLevel = checkBatteryCurrentLevel();
  
  if (((BatteryVoltageLevel >= batteryHiVoltageLevel) && (BatteryCurrentLevel < batteryLoCurrentLevel)) && chargingState){
  //if ((batteryVoltageLevel*batteryCurrentLevel < batteryHiVoltageLevel*batteryLoCurrentLevel) && chargingState){
    if (++chargeLevelCount > MAX_COUNT){
       chargeLevelCount = 0;
       chargingState = 0;
       return 1;
     }
   }
  else if((BatteryVoltageLevel < batteryLoVoltageLevel) && !chargingState) {
    if (++chargeLevelCount > MAX_COUNT){
       chargeLevelCount = 0;
       chargingState = 1;
       return 0;
     }   
  }
  else if(chargeLevelCount > 0){
    --chargeLevelCount;
  }
  else {
    chargeLevelCount = 0;
  }
  return !chargingState;
}

String getWeekday (int dayNumber){
  String Weekday;  
  switch (dayNumber) {
      case 0:
        Weekday = "Sun";
        break;
      case 1:
        Weekday = "Mon";
        break;
      case 2:
        Weekday = "Tues";
        break;
      case 3:
        Weekday = "Wed";
        break;
      case 4:
        Weekday = "Thurs";
        break;
      case 5:
        Weekday = "Fri";
        break;
      case 6:
        Weekday = "Sat";
        break;
      default:
        break;
  }
  return Weekday;
}
String getAMPM(int hourNumber){
  if (hourNumber < 12)
  {
      return "AM";
  }
  else
  {
      return "PM";
  }
}
String getNormalizedHour(int hourNumber){
  String hourString;
 
  if (hourNumber < 13)
  {
    hourString = String(hourNumber); 
  }
  else
  {
    hourString = String(hourNumber-12); 
  }
  if (hourString.length()==1)
  {
      return "0"+hourString;
  }
  else
  {
      return hourString;
  }
}

String getNormalizedMinute(int minuteNumber){
  String minuteString;
 
  minuteString = String(minuteNumber);
  if (minuteString.length()==1)
  {
      return "0"+minuteString;
  }
  else
  {
      return minuteString;
  }
}

String getNormalizedSecond(int secondNumber){
  String secondString;
 
  secondString = String(secondNumber);
  if (secondString.length()==1)
  {
      return "0"+secondString;
  }
  else
  {
      return secondString;
  }
}

unsigned int timeValue(String timeString){

   int AMPMAddress = timeString.length()-2;
   //return timeString.substring(3,5).toInt();

   if (timeString.substring(AMPMAddress)=="AM"){
     return 60*timeString.substring(0,2).toInt()+timeString.substring(3,5).toInt();
   }
   else{
     if (timeString.substring(0,2).toInt()==12){
       return 60*12+timeString.substring(3,5).toInt();
     }
     else{
       return 60*(12+timeString.substring(0,2).toInt())+timeString.substring(3,5).toInt();
     }
   }
}

void checkButtonISR(){
  //delayMicroseconds(1000);
  if((long)(micros()-last_micros) >= debouncingTime*1000){
    displayCount = 25;
    ++displayNum;
    if (displayNum == 4) {
      displayCount = 0;
      displayNum = 0;
    }
    last_micros = micros();
  }
}

String getVoltRMS(){
  int i;
  String tempString1 = "";
  String tempString2 = getPAParameter(VoltRMS);
 // Serial.println(tempString2);
  char tempCharArray[tempString2.length()];
  tempString2.toCharArray(tempCharArray,tempString2.length());
  for (i=0; i < tempString2.length(); i++){
    if (tempCharArray[i] == ','){
      break;
    }
  }
  for (i=i+1; i < tempString2.length()-4; i++){
    tempString1 +=  tempCharArray[i];
  }
  //return (String)  (((float) round(1000*tempString1.toFloat()))/1000.000);
  return tempString1;
}

String getAmpRMS(){
  int i;
  String tempString1 = "";
  String tempString2 = getPAParameter(AmpRMS);
  char tempCharArray[tempString2.length()];
  tempString2.toCharArray(tempCharArray,tempString2.length());
  for (i=0; i < tempString2.length(); i++){
    if (tempCharArray[i] == ','){
      break;
    }
  }
  for (i=i+1; i < tempString2.length()-2; i++){
    tempString1 +=  tempCharArray[i];
  }
  return tempString1;
}

void getWattHourMeterReading(){
  //serial1flush();
  Serial1.print(WattHour);
  delay(200);
  WattmeterLevel = Serial1.readString().substring(3).toFloat();
}

float getRMSVoltageReading(){
  //serial1flush();
  Serial1.print(VoltRMS);
  delay(200);
  return(Serial1.readString().substring(3).toFloat());
}

float getRMSCurrentReading(){
  //serial1flush();
  Serial1.print(AmpRMS);
  delay(200);
  return(Serial1.readString().substring(3).toFloat());
}

void zeroWattHour(){
  Serial1.print("\002R\003");
}

String getPAParameter(String request){
  String serialString = "";
  Serial1.write(0x02); // correct way to send [STX]
  Serial1.print(request); // send request
  Serial1.write(0x03); // [ETX] marker
  delay(1000);
  if (Serial1.available()){
    delay(10);
    while (Serial1.available()) {
        serialString = serialString + (char)Serial1.read();
        delay(1);
    }
 }
 return serialString;
}

String writeLCDLine(String stringToWrite){
  int i = 0;
  int spaceBefore;
  int spaceAfter;
  String outputString;
  int stringToWriteLength;
  stringToWriteLength = stringToWrite.length();
  spaceBefore =(20-stringToWriteLength)/2;
  spaceAfter = 20-stringToWriteLength-spaceBefore;
  for(i=0;i<spaceBefore;i++){
    outputString.concat(' ');
  }
  outputString.concat(stringToWrite);
  for(i=0;i<spaceAfter;i++){
    outputString.concat(' ');
  }
  return outputString;
}

void updateTotalWattHourMeter(){
  float diff;
  diff = WattmeterLevel - InitWattmeterLevel;
  if (diff > 0.02){
    totalRunningWattmeterReading = lastSavedWattmeterReading + diff;
    saveToEEPROM2(wattmeterReading_EEPROM_Addr,(String)totalRunningWattmeterReading);
    delay(20);
    lastSavedWattmeterReading = totalRunningWattmeterReading;
  }
}

void updateTotalEnergyCost(float rate){
  float diff;
  diff = WattmeterLevel - InitWattmeterLevel;
  if (diff > 0.02){
    totalRunningEnergyCost = lastSavedEnergyCost + ((diff)/1000)*rate;
    saveToEEPROM2(energyCost_EEPROM_Addr,(String)totalRunningEnergyCost);
    delay(20);
    lastSavedEnergyCost = totalRunningEnergyCost;
    InitWattmeterLevel = WattmeterLevel;
  }
}

void displaySettings(){
   while (displayCount-- > 0){
    lcd.clear();
    switch (displayNum){
       case 1:
         lcd.setCursor(0,0);
         lcd.print("Pk Strt: " + peakTimeStart);
         lcd.setCursor(0,1);
         lcd.print("Pk Stop: " + peakTimeStop);
         lcd.setCursor(0,2);
         lcd.print("NPk Strt: " + nonPeakTimeStart);
         lcd.setCursor(0,3);
         lcd.print("NPk Stop: " + nonPeakTimeStop);
         break;
       case 2:
         lcd.setCursor(0,0);
         lcd.print("Chrg Volt: " + (String) batteryHiVoltageArray + " V");
         lcd.setCursor(0,1);
         lcd.print("Dschg Volt: " + (String) batteryLoVoltageArray + " V");
         lcd.setCursor(0,2);
         lcd.print("Chrg Amp: " + (String) batteryHiCurrentArray + " A");
         lcd.setCursor(0,3);
         lcd.print("Dschg Amp: " + (String) batteryLoCurrentArray + " A");
         break;
       case 3:
         lcd.setCursor(0,0);
         lcd.print("Peak Rate: P " + (String) peakRate);
         lcd.setCursor(0,1);
         lcd.print("NPeak Rate: P " + (String) nonPeakRate);
         break;
       default:
         break;
    }
    delay(500);
   }
}

void Introduction(){
  lcd.clear();
  char ascii = 220;
  lcd.setCursor(0,0);
  lcd.print(ascii);
  delay(1000);
}

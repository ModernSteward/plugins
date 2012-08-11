/*
Sends and receives IR signals with commands:
Receive: RECORDIR
Send: SENDIR <protocol> <command> <bitrate>
  Format exception for UNKNOWN protocol:
    SENDIR UNKNOWN <unknown_array_lenght> <array>
      where:
        1. uknown_array_lenght is the number of elements contained in array
        2. array is the raw code of the signal without the first number. Example:
          1200, 1238, 500, 650, etc.
          
For example:
IRSEND RC5 820 12

Built for Arduino Duemilanove
with the IRremote library under Arduino 1.0 IDE

Author: Lyubomir Yanchev
Credits: Ivaylo Dimov (Arduino PIN's theory help) & Simeon Yanchev (Arduino Duemilanove)
*/

#include <IRremoteOLD.h>
#include <stdlib.h>

#define IRRECVPIN 7 // receiver's pin
#define SUSPENDED 0
#define RECORDING 1
#define SENDING 2

#define INDATALEN 50

#define UNKNOWN 0
#define NEC 1
#define SONY 2
#define RC5 3
#define RC6 4

#define MASTERCOMMAND 0
#define IRCOMMANDPROTOCOL 1
#define IRCOMMANDCODE 2
#define IRCOMMANDBITRATE 3

IRrecv irRecorder(IRRECVPIN);
decode_results results;
IRsend irSender;

char inData[INDATALEN];

void setup(){
   Serial.begin(9600);
   irRecorder.enableIRIn();
   
   pinMode(9, OUTPUT); 
   digitalWrite(9, LOW);
   
   pinMode(7, INPUT);
}

bool readingData = false;
bool readingDataFinished = false;

int mode = SUSPENDED;
int irCommandProtocol = UNKNOWN;
char irCommandCode[16];
char irCommandBitRate[4];

char commands[5][64];

void loop()
{
	ReadDataFromTheCOM();
	if(readingDataFinished){
		readingDataFinished = false;
		ParseReadData();
	}
	if(mode!= SUSPENDED){
		switch(mode){
			case RECORDING:
      			      if (irRecorder.decode(&results)) {
      			        RecordAndSendDataThroughCOM(&results);
      			      }
			      break;
			case SENDING:
				SendIRSignal(irCommandProtocol, irCommandCode, irCommandBitRate);
				break;
		}
	}
	DeleteReadData();
}


unsigned int array[100];
int arrayLenght = 0;

//unsigned int array2[75] = {8750, 4400, 650, 1750, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 1700, 650, 550, 650, 1750, 650, 1750, 650, 1750, 650, 550, 650, 550, 600, 600, 600, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 600, 600, 600, 600, 600, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650, 550, 650};

void SendIRSignal(int protocol, char commandCode[], char bitrate[]){
	long int commandCodeInUInt = strtoul(commandCode,NULL,16);
	int bitrateInInt = atoi(bitrate);
        
       
        if(protocol == UNKNOWN){
                irSender.sendRaw(array, arrayLenght, 38);
                Serial.println(arrayLenght);
        }
	else if(protocol == NEC){
		irSender.sendNEC(commandCodeInUInt, bitrateInInt);
	}
	else if(protocol == SONY){
		irSender.sendSony(commandCodeInUInt, bitrateInInt);
	}
	else if(protocol == RC5){
		irSender.sendRC5(commandCodeInUInt, bitrateInInt);
	}
	else if(protocol == RC6){
		irSender.sendRC6(commandCodeInUInt, bitrateInInt);
	}
	mode = SUSPENDED;
}

char * pch;
void ParseReadData(){
	int i = 0;
	pch = strtok (inData, " ");

        for(int i = 0; i < 5; i++){
         for(int j = 0; j < 5; j++){
          commands[i][j] = ' '; 
         }
        }

	while (pch != NULL){
		strcpy(commands[i], pch);
		i++;
		pch = strtok (NULL, " ");
	}

	if(!strcmp(commands[MASTERCOMMAND], "RECORDIR")){
                irRecorder.enableIRIn();
		mode = RECORDING;
	}
	else if(!strcmp(commands[MASTERCOMMAND], "SENDIR")){
		mode = SENDING;
		if(!strcmp(commands[IRCOMMANDPROTOCOL], "UNKNOWN")){
			irCommandProtocol = UNKNOWN;
                        int beg = atoi(commands[IRCOMMANDPROTOCOL+1]);
                        arrayLenght = 0;
                        for(int i = 0; i < beg;i++){
                          array[i] = atoi(commands[i+beg+1]);
                          arrayLenght++;
                        }
                        Serial.println(arrayLenght);
		}
		else if(!strcmp(commands[IRCOMMANDPROTOCOL], "NEC")){
			irCommandProtocol = NEC;
		}
		else if(!strcmp(commands[IRCOMMANDPROTOCOL], "SONY")){
			irCommandProtocol = SONY;
		}
		else if(!strcmp(commands[IRCOMMANDPROTOCOL], "RC5")){
			irCommandProtocol = RC5;
		}
		else if(!strcmp(commands[IRCOMMANDPROTOCOL], "RC6")){
			irCommandProtocol = RC6;
		}
		strcpy(irCommandCode, commands[IRCOMMANDCODE]);
		strcpy(irCommandBitRate, commands[IRCOMMANDBITRATE]);
	}
}

int index = 0;

void ReadDataFromTheCOM(){
  while(Serial.available()){
    readingData = true;
    inData[index] = Serial.read();
    index++;
    delay(50);
  }
  if(readingData && !Serial.available()){
   readingDataFinished = true; 
   readingData = false;
  }
}

void DeleteReadData(){
     for(int i = 0; i < INDATALEN; i++){
      inData[i] = 0; 
     }
     index = 0;
}

void RecordAndSendDataThroughCOM(decode_results *results) {
	if (results->decode_type == UNKNOWN) {
	Serial.print("Unknown ");
	} 
	else if (results->decode_type == NEC) {
	Serial.print("NEC ");
	} 
	else if (results->decode_type == SONY) {
	Serial.print("SONY ");
	} 
	else if (results->decode_type == RC5) {
	Serial.print("RC5 ");
	} 
	else if (results->decode_type == RC6) {
	Serial.print("RC6 ");
	}
	Serial.print(results->value, HEX);
	Serial.print(" ");
	Serial.println(results->bits, DEC);
	mode = SUSPENDED;
}


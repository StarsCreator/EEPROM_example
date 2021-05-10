#include <EEPROM.h>

//количество байтов которые будем принимать, записывать в память и отправлять.
#define EEPROM_BYTES_COUNT        5

//адрес куда будем записывать
#define EEPROM_ADDRESS          100

//наш массив байтов который будем принимать, записывать в память и отправлять.
byte body[EEPROM_BYTES_COUNT];

void setup() {
  Serial.begin(115200); 
}

//общаться с ардуиной будем по протоколу, где самый первый байт будет указывать ЧТО внешняя программа от ардуины хочет


void loop() {
  if (Serial.available() > 0)
  {
    switch (Serial.read())
    {
      //нас ищут чтобы понять что это мы и работать с нами в дальнейшем
      case 0xA0:
        //отвечаем понятным для внешней программы байтом
        Serial.write(0xAA);
        break;

      //записать 5 байтов в EEPROM
      case 0xA1:
        {       
          Serial.readBytes(body, EEPROM_BYTES_COUNT);
          EEPROM.put(EEPROM_ADDRESS, body);          
        }
        break;

      //считать 5 байтов из EEPROM
       case 0xA2:
        {
          EEPROM.get(EEPROM_ADDRESS, body);
          Serial.write(body,sizeof(body));          
        }       

      //остальное нам сейчас не важно
      default:
        break;
    }
  }
}

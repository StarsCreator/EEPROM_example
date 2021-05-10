using System;
using System.IO.Ports;
using System.Threading;

namespace Eeprom_example
{
  class Program
  {
    static void Main(string[] args)
    {
      //ищем все доступные порты
      string[] ports = SerialPort.GetPortNames();
      Console.WriteLine("Поиск устройства...");

      //находим нужный нам порт, который ответит нам AA на наше 0A
      var port = FindPort(ports);

      //Если нашли формируем отправку для записи в порт
      if (port != null)
      {
        Console.WriteLine("Устройство найдено - " + port.PortName);

        //наше сообщение
        var bufferOut = new byte[] 
        { 
          0xA1, //байт говорящий устройству что ему стоит работать с EEPROM
          0x12, //набор из 5 рандомных байтов. Важно, что количество байтов здесь и на Arduino указано вручную, а именно 5
          0xA2,
          0xAA,
          0xF8,
          0x50 
        };

        //выводим на экран что будем отправлять
        Console.WriteLine("Отправляю переменные для EEPROM:");
        foreach (var b in bufferOut)
        {
          Console.WriteLine(b.ToString("x"));
        }

        //отправляем
        try
        {
          port.Open();
          port.Write(bufferOut, 0, bufferOut.Length);
          port.Close();
          Console.WriteLine("Отправлено успешно!"+"\n");
        }
        catch (Exception e)
        {

        }


        //запрашиваем данные
        Console.WriteLine("Запрашиваю данные из EEPROM");
        try
        {
          //знаем что будет 5 байтов
          var bufferIn = new byte[5];

          port.Open();
          port.Write(new byte[] { 0xA2 }, 0, 1);

          //чтобы arduino успела обратиться к EEPROM
          Thread.Sleep(300);

          //считываем что нам прислали
          port.Read(bufferIn, 0, bufferIn.Length);
          port.Close();

          //выводим на экран
          Console.WriteLine("Принято:");
          foreach (var b in bufferIn)
          {
            Console.WriteLine(b.ToString("x"));
          }
        }
        catch (Exception e)
        {

        }

      }

      else Console.WriteLine("Устройство не найдено!");
      Console.ReadLine();
    }


    //функция поиска нужного нам порта. static здесь нужен только потому что работаем через консоль.
    static SerialPort FindPort(string[] ports)
    {
      SerialPort serial;

      //наш позывной, чтобы устройство откликнулось
      var buffer = new byte[]{ 0xA0 };


      //переберираем все которые сейчпс подключены на скорости 115200
      foreach (string port in ports)
      {
        serial = new SerialPort(port, 115200);
        serial.DtrEnable = true;
        //время ожидания ответа  в мс
        serial.ReadTimeout = 500;

        try
        {
          //пробуем общаться и смотрим - ответил ли и что ответил
          serial.Open();
          serial.Write(buffer, 0, buffer.Length);
          serial.Read(buffer, 0, buffer.Length);
          serial.Close();
          //если наш клиент, то начинаем с ним взаимодействовать...
          if (buffer[0] == 0xAA) return serial;
        }
        catch (Exception e)
        {

        }
      }

      //никого не нашли
      return null;
    }
  }
}

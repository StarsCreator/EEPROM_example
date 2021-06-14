using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace EEPROM
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      downloadLabel.Text = "";
    }

    private SerialPort port;

    private void Form1_Load(object sender, EventArgs e)
    {
      //ищем все доступные порты
      string[] ports = SerialPort.GetPortNames();
      //Console.WriteLine("Поиск устройства...");

      //находим нужный нам порт, который ответит нам AA на наше 0A
      port = FindPort(ports);

      //Если нашли формируем отправку для записи в порт
      if (port != null)
      {
        statusLabel.Text = "Устройство найдено - " + port.PortName;

      }

      else statusLabel.Text = "Устройство не найдено!";
    }


    //функция поиска нужного нам порта. static здесь нужен только потому что работаем через консоль.
    private SerialPort FindPort(string[] ports)
    {
      SerialPort serial;

      //наш позывной, чтобы устройство откликнулось
      var buffer = new byte[] { 128 }; // коды в МИДИ до 127 не использовать для идентификации


      //переберираем все которые сейчпс подключены на скорости 115200
      foreach (string port in ports)
      {
        serial = new SerialPort(port, 9600);
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
          if (buffer[0] == 129) return serial;
        }
        catch (Exception e)
        {

        }
      }

      //никого не нашли
      return null;
    }

    //отправка
    private void btnUpload_Click(object sender, EventArgs e)
    {
      if (port != null)
      {
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

        //отправляем
        try
        {
          //выводим на экран что будем отправлять
          statusLabel.Text = "Отправляю переменные для EEPROM";
          port.Open();
          port.Write(bufferOut, 0, bufferOut.Length);
          port.Close();
          statusLabel.Text = "Отправлено успешно!";
        }
        catch (Exception) { }
      }

    }

    //считывание
    private void btnDownload_Click(object sender, EventArgs e)
    {
      if (port != null)
      {
        downloadLabel.Text = "";

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
          statusLabel.Text = "Успешно принято";
          foreach (var b in bufferIn)
          {
            downloadLabel.Text += b.ToString()+" ";
          }
        }
        catch (Exception) { }
      }
    }

    //поиск устройства
    private void btnConnect_Click(object sender, EventArgs e)
    {
      if (port != null && port.IsOpen) port.Close();

      string[] ports = SerialPort.GetPortNames();
      statusLabel.Text = "Поиск устройства...";

      //находим нужный нам порт, который ответит нам AA на наше 0A
      port = FindPort(ports);

      //Если нашли формируем отправку для записи в порт
      if (port != null)
      {
        statusLabel.Text = "Устройство найдено - " + port.PortName;

      }

      else statusLabel.Text = "Устройство не найдено!";
    }

  }
}


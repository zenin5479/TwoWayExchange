using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

namespace SyncClient
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("Клиент запущен. Попытка подключения к серверу...");

         using (var client = new NamedPipeClientStream(".", "mypipe", PipeDirection.InOut, PipeOptions.None))
         {
            try
            {
               // Подключаемся к серверу (таймаут 5 секунд)
               client.Connect(5000);
               client.ReadMode = PipeTransmissionMode.Message;
               Console.WriteLine("Подключено к серверу.");

               // Отправляем сообщение серверу
               string message = "Привет от консольного клиента!";
               byte[] messageBytes = Encoding.UTF8.GetBytes(message);
               client.Write(messageBytes, 0, messageBytes.Length);
               Console.WriteLine($"Отправлено: {message}");

               // Читаем ответ
               byte[] buffer = new byte[1024];
               int bytesRead = client.Read(buffer, 0, buffer.Length);
               string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
               Console.WriteLine($"Получен ответ: {response}");
            }
            catch (Exception ex)
            {
               Console.WriteLine($"Ошибка: {ex.Message}");
            }
         }

         Console.WriteLine("Клиент завершил работу. Нажмите Enter для выхода.");
         Console.ReadLine();
      }
   }
}
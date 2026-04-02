using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace SyncClient
{
   internal class Program
   {
      static void Main()
      {
         using (var pipeClient = new NamedPipeClientStream(".", "my_named_pipe", PipeDirection.InOut))
         {
            Console.WriteLine("Подключение к серверу...");
            pipeClient.Connect(); // Блокирующий вызов до подключения сервера
            Console.WriteLine("Подключено!");

            var reader = new StreamReader(pipeClient, Encoding.UTF8);
            var writer = new StreamWriter(pipeClient, Encoding.UTF8) { AutoFlush = true };

            while (true)
            {
               Console.Write("Введите сообщение для отправки (или 'exit' для выхода): ");
               string message = Console.ReadLine();

               if (message.ToLower() == "exit")
                  break;

               // Отправляем сообщение серверу
               writer.WriteLine(message);
               Console.WriteLine($"Отправлено: {message}");

               // Получаем ответ от сервера
               string response = reader.ReadLine();
               Console.WriteLine($"Получено от сервера: {response}");
            }
         }
      }
   }
}
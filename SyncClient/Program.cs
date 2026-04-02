using System;
using System.IO;
using System.IO.Pipes;

namespace SyncClient
{
   internal class Program
   {
      static void Main()
      {
         // Имя канала должно совпадать с именем, используемым в WinForms
         using (NamedPipeClientStream client = new NamedPipeClientStream(".", "twoWayPipe", PipeDirection.InOut))
         {
            Console.WriteLine("Клиент: подключение к каналу...");
            client.Connect(); // Синхронное подключение

            // Чтение сообщения от WinForms
            var reader = new StreamReader(client);
            var writer = new StreamWriter(client) { AutoFlush = true };

            string received = reader.ReadLine();
            Console.WriteLine($"Клиент получил: {received}");

            // Формирование ответа
            string response = $"Ответ на '{received}'";
            writer.WriteLine(response);
            Console.WriteLine($"Клиент отправил: {response}");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
         }
      }
   }
}
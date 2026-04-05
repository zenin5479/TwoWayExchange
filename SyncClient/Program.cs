using System;
using System.IO;
using System.IO.Pipes;

namespace SyncClient
{
   internal class Program
   {
      static void Main()
      {
         // Имя канала
         string pipeName = "twoWayPipe";
         using (NamedPipeClientStream client = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut))
         {
            Console.WriteLine("Клиент: подключение к каналу...");
            // Синхронное подключение
            client.Connect();

            // Чтение сообщения от WinForms
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);
            writer.AutoFlush = true;

            string received = reader.ReadLine();
            Console.WriteLine("Клиент получил: {0}", received);

            // Формирование ответа
            string response = string.Format("Ответ на '{0}'", received);
            writer.WriteLine(response);
            Console.WriteLine("Клиент отправил: {0}", response);

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
         }
      }
   }
}
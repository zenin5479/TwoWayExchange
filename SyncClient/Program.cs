using System;
using System.IO;
using System.IO.Pipes;

namespace SyncClient
{
   internal class Program
   {
      static void Main()
      {
         using (NamedPipeClientStream client = new NamedPipeClientStream(".", "myPipe", PipeDirection.InOut))
         {
            Console.WriteLine("Подключение к серверу...");
            // Синхронное подключение
            client.Connect();
            Console.WriteLine("Подключено!");

            using (StreamWriter writer = new StreamWriter(client))
            {
               writer.AutoFlush = true;
               using (StreamReader reader = new StreamReader(client))
               {
                  while (true)
                  {
                     Console.Write("Введите команду (или 'exit'): ");
                     string input = Console.ReadLine();
                     if (string.IsNullOrEmpty(input))
                     {
                        continue;
                     }

                     writer.WriteLine(input);

                     if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                     {
                        break;
                     }

                     string response = reader.ReadLine();
                     Console.WriteLine("Ответ сервера: {0}", response);
                  }
               }
            }
         }
      }
   }
}
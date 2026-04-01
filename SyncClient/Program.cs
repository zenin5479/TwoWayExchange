using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

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
                  int counter = 0;
                  while (counter < 100)
                  {
                     // Имитация длительных вычислений
                     Thread.Sleep(100); // можно заменить на реальные расчёты
                     double result = Math.Sqrt(counter * 1000);
                     // Отправляем результат в stdout
                     Console.WriteLine("Результат: {0:F2}", result);
                     writer.WriteLine(result);
                     counter++;
                     string response = reader.ReadLine();
                     Console.WriteLine("Ответ сервера: {0}", response);
                  }
               }
            }
         }
      }
   }
}
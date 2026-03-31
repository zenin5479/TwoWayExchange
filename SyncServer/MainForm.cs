using System;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;

namespace SyncServer
{
   public partial class MainForm : Form
   {
      private NamedPipeServerStream _server;
      private StreamReader reader;
      private StreamWriter writer;

      public MainForm()
      {
         InitializeComponent();
      }

      private void Log(string message)
      {
         textBoxLog.AppendText(string.Format("{0:HH:mm:ss} - {1}{2}", DateTime.Now, message, Environment.NewLine));
      }

      private void buttonStart_Click(object sender, EventArgs e)
      {
         buttonStart.Enabled = false;
         buttonStop.Enabled = true;
         Log("Сервер запущен, ожидание подключения...");

         // Всё выполняется синхронно в потоке UI – форма замрёт до завершения
         _server = new NamedPipeServerStream("myPipe", PipeDirection.InOut);
         _server.WaitForConnection(); // блокирует UI, но форма уже видима
         Log("Клиент подключился");

         reader = new StreamReader(_server);
         writer = new StreamWriter(_server) { AutoFlush = true };

         while (true)
         {
            Log("Ожидание команды...");
            string command = reader.ReadLine();
            if (command == null) break;

            Log($"Получено: {command}");
            if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
               Log("Завершение по команде exit");
               break;
            }

            string response = command.ToUpperInvariant();
            writer.WriteLine(response);
            Log($"Отправлено: {response}");
         }

         // Очистка ресурсов
         reader?.Dispose();
         writer?.Dispose();
         _server?.Disconnect();
         _server?.Dispose();

         Log("Сервер остановлен");
         buttonStart.Enabled = true;
         buttonStop.Enabled = false;
      }

      private void buttonStop_Click(object sender, EventArgs e)
      {
         // Принудительное закрытие (клиент получит исключение, но это единственный способ)
         _server?.Close();
         Log("Остановка сервера (принудительно)");
      }
   }
}
using System.IO.Pipes;
using System.IO;
using System;
using System.Windows.Forms;

namespace SyncServer
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();

         Load += MainForm_Load;
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // Серверный канал с фиксированным именем
         using (var server = new NamedPipeServerStream("myPipe", PipeDirection.InOut))
         {
            Log("Сервер ожидает подключения...");
            // Синхронное ожидание подключения клиента — блокирует UI
            server.WaitForConnection();
            Log("Клиент подключился");

            using (var reader = new StreamReader(server))
            using (var writer = new StreamWriter(server) { AutoFlush = true })
            {
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

                  // Формируем ответ
                  string response = command.ToUpperInvariant();
                  writer.WriteLine(response);
                  Log($"Отправлено: {response}");
               }
            }

            server.Disconnect();
            Log("Канал закрыт");
         }

         Log("Сервер завершил работу");
         // Закрываем форму после завершения
         Close();
      }

      private void Log(string message)
      {
         textBoxLog.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
      }
   }
}
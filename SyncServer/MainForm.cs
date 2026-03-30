using System;
using System.IO;
using System.IO.Pipes;
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

      private void MainForm_Load(object sender, EventArgs e)
      {
         // Серверный канал с фиксированным именем
         using (NamedPipeServerStream server = new NamedPipeServerStream("myPipe", PipeDirection.InOut))
         {
            Log("Сервер ожидает подключения...");
            // Синхронное ожидание подключения клиента — блокирует UI
            server.WaitForConnection();
            Log("Клиент подключился");

            using (StreamReader reader = new StreamReader(server))
            using (StreamWriter writer = new StreamWriter(server))
            {
               writer.AutoFlush = true;
               while (true)
               {
                  Log("Ожидание команды...");
                  string command = reader.ReadLine();
                  if (command == null)
                  {
                     break;
                  }

                  Log($"Получено: {command}");

                  if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                  {
                     Log("Завершение по команде exit");
                     break;
                  }

                  // Формируем ответ
                  string response = command.ToUpperInvariant();
                  writer.WriteLine(response);
                  Log(string.Format("Отправлено: {0}", response));
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
         textBoxLog.AppendText(string.Format("{0:HH:mm:ss} - {1}{2}", DateTime.Now, message, Environment.NewLine));
      }
   }
}
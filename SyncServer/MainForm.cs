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
      }

      private void ButtonStart_Click(object sender, EventArgs e)
      {

      }

      private void ButtonSend_Click(object sender, EventArgs e)
      {
         // Создаём сервер канала (именованный канал)
         using (NamedPipeServerStream server = new NamedPipeServerStream("twoWayPipe",
                   PipeDirection.InOut,
                   1,// максимум 1 подключение
                   PipeTransmissionMode.Message,
                   PipeOptions.None)) // синхронный режим
         {
            // Ожидаем подключения консольного приложения
            // ВНИМАНИЕ: блокирует UI поток
            server.WaitForConnection();
            using (var reader = new StreamReader(server))
            using (var writer = new StreamWriter(server) { AutoFlush = true })
            {
               // Отправляем текст из TextBox
               string request = txtMessage.Text;
               writer.WriteLine(request);
               Text = "Ожидание ответа...";

               // Синхронно читаем ответ (блокировка)
               string response = reader.ReadLine();
               txtLog.Text = string.Format("Ответ клиента: {0}", response);
               Text = "WinForms + Named Pipe (синхронно)";
            }
            // Канал закрывается автоматически (using)
         }

      }

      private void ButtonReceive_Click(object sender, EventArgs e)
      {

      }

      private void ButtonStop_Click(object sender, EventArgs e)
      {

      }
   }
}
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
         string pipeName = "twoWayPipe";
         using (NamedPipeServerStream server = new NamedPipeServerStream(pipeName, PipeDirection.InOut,
                   1, PipeTransmissionMode.Message, PipeOptions.None))
         {
            // Ожидаем подключения консольного приложения
            // ВНИМАНИЕ: блокирует UI поток
            server.WaitForConnection();
            using (StreamReader reader = new StreamReader(server))
            {
               using (StreamWriter writer = new StreamWriter(server))
               {
                  writer.AutoFlush = true;
                  // Отправляем текст из TextBox
                  string request = txtMessage.Text;
                  writer.WriteLine(request);
                  // Теперь pipeName доступен в вашем коде
                  txtLog.Text = string.Format("Имя канала: {0}", pipeName);
                  txtLog.Text = "Ожидание ответа...";

                  // Синхронно читаем ответ (блокировка)
                  string response = reader.ReadLine();
                  txtLog.Text = string.Format("Ответ клиента: {0}", response);
               }
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
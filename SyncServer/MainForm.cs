using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Windows.Forms;

namespace SyncServer
{
   public partial class MainForm : Form
   {
      private NamedPipeServerStream _pipeServer;
      private StreamReader reader;
      private StreamWriter writer;

      public MainForm()
      {
         InitializeComponent();
      }

      private void buttonStart_Click(object sender, EventArgs e)
      {
         // Создаём сервер именованного канала
         _pipeServer = new NamedPipeServerStream("my_named_pipe", PipeDirection.InOut);

         // Ожидание подключения клиента (блокирующий вызов)
         _pipeServer.WaitForConnection();

         reader = new StreamReader(_pipeServer, Encoding.UTF8);
         writer = new StreamWriter(_pipeServer, Encoding.UTF8) { AutoFlush = true };

         MessageBox.Show("Клиент подключился!");
      }

      private void buttonStop_Click(object sender, EventArgs e)
      {
         // Принудительное закрытие (клиент получит исключение, но это единственный способ)
         //_server.Close();
         //Log("Остановка сервера (принудительно)");
      }

      private void Log(string message)
      {
         txtLog.AppendText(string.Format("{0:HH:mm:ss:fff} - {1}{2}", DateTime.Now, message, Environment.NewLine));
      }

      private void btnSend_Click(object sender, EventArgs e)
      {
         string message = txtMessage.Text;
         SendMessageToClient(message);
         txtLog.AppendText($"Отправлено: {message}\r\n");
      }

      private void btnReceive_Click(object sender, EventArgs e)
      {
         string received = ReceiveMessageFromClient();
         if (!string.IsNullOrEmpty(received))
         {
            txtLog.AppendText($"Получено: {received}\r\n");
         }
      }

      // Отправка сообщения клиенту
      private void SendMessageToClient(string message)
      {
         if (_pipeServer.IsConnected)
         {
            writer.WriteLine(message);
         }
      }

      // Приём сообщения от клиента
      private string ReceiveMessageFromClient()
      {
         if (_pipeServer.IsConnected)
         {
            return reader.ReadLine();
         }
         return null;
      }
   }
}
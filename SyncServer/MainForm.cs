using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Windows.Forms;

namespace SyncServer
{
   public partial class MainForm : Form
   {
      private NamedPipeServerStream pipeServer;
      private StreamReader reader;
      private StreamWriter writer;

      public MainForm()
      {
         InitializeComponent();
      }

      private void buttonStart_Click(object sender, EventArgs e)
      {
         // Создаём сервер именованного канала
         pipeServer = new NamedPipeServerStream("my_named_pipe", PipeDirection.InOut);

         // Ожидание подключения клиента (блокирующий вызов)
         pipeServer.WaitForConnection();

         reader = new StreamReader(pipeServer, Encoding.UTF8);
         writer = new StreamWriter(pipeServer, Encoding.UTF8) { AutoFlush = true };

         MessageBox.Show("Клиент подключился!");
      }

      private void buttonStop_Click(object sender, EventArgs e)
      {
         // Принудительное закрытие (клиент получит исключение, но это единственный способ)
         //_server.Close();
         Log("Остановка сервера (принудительно)");
      }

      private void Log(string message)
      {
         textBoxLog.AppendText(string.Format("{0:HH:mm:ss:fff} - {1}{2}", DateTime.Now, message, Environment.NewLine));
      }
   }
}
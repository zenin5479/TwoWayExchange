using System;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;

namespace SyncServer
{
   public partial class MainForm : Form
   {
      private NamedPipeServerStream pipeServer;
      private StreamReader reader;
      private StreamWriter writer;
      private Timer pipeTimer;
      private bool isConnected = false;

      public MainForm()
      {
         InitializeComponent();
      }

      private void buttonStart_Click(object sender, EventArgs e)
      {
         pipeServer = new NamedPipeServerStream("my_named_pipe", PipeDirection.InOut);

         SetupTimer();
      }

      private void SetupTimer()
      {
         pipeTimer = new Timer();
         pipeTimer.Interval = 100; // Проверка каждые 100 мс
         pipeTimer.Tick += PipeTimer_Tick;
         pipeTimer.Start();
         AppendLog("Сервер запущен. Ожидание подключения...");
      }

      // Безопасное обновление UI
      private void AppendLog(string message)
      {
         if (txtLog.InvokeRequired)
         {
            txtLog.Invoke(new Action<string>(AppendLog), message);
         }
         else
         {
            txtLog.AppendText($"{message}\r\n");
            txtLog.ScrollToCaret(); // Автопрокрутка вниз
         }
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
         string message = txtMessage.Text.Trim();
         if (!string.IsNullOrEmpty(message))
         {
            SendMessageToClient(message);
            txtMessage.Clear();
         }
      }



      private void btnReceive_Click(object sender, EventArgs e)
      {

      }

      // Обработчик закрытия формы
      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         pipeTimer?.Stop();
         DisconnectClient();
         base.OnFormClosing(e);
      }

   }
}
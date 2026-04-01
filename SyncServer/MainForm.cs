using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Windows.Forms;

namespace SyncServer
{
   public partial class MainForm : Form
   {
      private StreamWriter _writer;

      public MainForm()
      {
         InitializeComponent();
      }

      private void buttonStart_Click(object sender, EventArgs e)
      {
         // Блокируем кнопку на время работы сервера
         buttonStart.Enabled = false;
         textBoxLog.Clear();

         Log("Сервер запущен, ожидание подключения...");

         // Создаём серверный канал (одно подключение, режим сообщений)
         using (var server = new NamedPipeServerStream("mypipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message))
         {
            try
            {
               // Синхронное ожидание подключения – UI блокируется до подключения клиента
               server.WaitForConnection();
               Log("Клиент подключён.");

               // Чтение сообщения от клиента
               byte[] buffer = new byte[1024];
               int bytesRead = server.Read(buffer, 0, buffer.Length);
               string clientMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
               Log($"Получено от клиента: {clientMessage}");

               // Отправка ответа клиенту
               string reply = $"Сервер получил: \"{clientMessage}\"";
               byte[] replyBytes = Encoding.UTF8.GetBytes(reply);
               server.Write(replyBytes, 0, replyBytes.Length);
               Log($"Отправлено клиенту: {reply}");

               // (Опционально) можно прочитать подтверждение от клиента, если нужно
               // Здесь для простоты обмен завершён.
            }
            catch (Exception ex)
            {
               Log($"Ошибка: {ex.Message}");
            }
            finally
            {
               server.Disconnect();
               Log("Канал закрыт.");
            }
         }

         Log("Сервер завершил работу.");
         buttonStart.Enabled = true;
      }

      private void buttonStop_Click(object sender, EventArgs e)
      {
         // Принудительное закрытие (клиент получит исключение, но это единственный способ)
         _server.Close();
         Log("Остановка сервера (принудительно)");
      }

      private void Log(string message)
      {
         textBoxLog.AppendText(string.Format("{0:HH:mm:ss} - {1}{2}", DateTime.Now, message, Environment.NewLine));
      }
   }
}
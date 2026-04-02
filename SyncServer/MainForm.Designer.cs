namespace SyncServer
{
   partial class MainForm
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         txtLog = new System.Windows.Forms.TextBox();
         Label = new System.Windows.Forms.Label();
         ButtonStart = new System.Windows.Forms.Button();
         buttonStop = new System.Windows.Forms.Button();
         txtMessage = new System.Windows.Forms.TextBox();
         btnSend = new System.Windows.Forms.Button();
         btnReceive = new System.Windows.Forms.Button();
         SuspendLayout();
         // 
         // txtLog
         // 
         txtLog.Location = new System.Drawing.Point(12, 159);
         txtLog.Multiline = true;
         txtLog.Name = "txtLog";
         txtLog.ReadOnly = true;
         txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         txtLog.Size = new System.Drawing.Size(422, 124);
         txtLog.TabIndex = 3;
         // 
         // Label
         // 
         Label.AutoSize = true;
         Label.Location = new System.Drawing.Point(12, 45);
         Label.Name = "Label";
         Label.Size = new System.Drawing.Size(247, 15);
         Label.TabIndex = 2;
         Label.Text = "Сервер запущен, ожидание подключения...";
         // 
         // ButtonStart
         // 
         ButtonStart.Location = new System.Drawing.Point(12, 12);
         ButtonStart.Name = "ButtonStart";
         ButtonStart.Size = new System.Drawing.Size(120, 23);
         ButtonStart.TabIndex = 4;
         ButtonStart.Text = "Запустить сервер";
         ButtonStart.UseVisualStyleBackColor = true;
         ButtonStart.Click += ButtonStart_Click;
         // 
         // buttonStop
         // 
         buttonStop.Enabled = false;
         buttonStop.Location = new System.Drawing.Point(349, 12);
         buttonStop.Name = "buttonStop";
         buttonStop.Size = new System.Drawing.Size(85, 23);
         buttonStop.TabIndex = 5;
         buttonStop.Text = "Остановить";
         buttonStop.UseVisualStyleBackColor = true;
         buttonStop.Click += ButtonStop_Click;
         // 
         // txtMessage
         // 
         txtMessage.Location = new System.Drawing.Point(12, 63);
         txtMessage.Multiline = true;
         txtMessage.Name = "txtMessage";
         txtMessage.Size = new System.Drawing.Size(100, 23);
         txtMessage.TabIndex = 6;
         // 
         // btnSend
         // 
         btnSend.Location = new System.Drawing.Point(12, 107);
         btnSend.Name = "btnSend";
         btnSend.Size = new System.Drawing.Size(182, 23);
         btnSend.TabIndex = 7;
         btnSend.Text = "кнопка отправки сообщения";
         btnSend.UseVisualStyleBackColor = true;
         btnSend.Click += ButtonSend_Click;
         // 
         // btnReceive
         // 
         btnReceive.Location = new System.Drawing.Point(200, 107);
         btnReceive.Name = "btnReceive";
         btnReceive.Size = new System.Drawing.Size(234, 23);
         btnReceive.TabIndex = 8;
         btnReceive.Text = "кнопка приёма сообщения";
         btnReceive.UseVisualStyleBackColor = true;
         btnReceive.Click += ButtonReceive_Click;
         // 
         // MainForm
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(446, 295);
         Controls.Add(btnReceive);
         Controls.Add(btnSend);
         Controls.Add(txtMessage);
         Controls.Add(buttonStop);
         Controls.Add(ButtonStart);
         Controls.Add(txtLog);
         Controls.Add(Label);
         Name = "MainForm";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Двусторонний обмен между Windows Forms и консолью";
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.TextBox txtLog;
      private System.Windows.Forms.Label Label;
      private System.Windows.Forms.Button ButtonStart;
      private System.Windows.Forms.Button buttonStop;
      private System.Windows.Forms.TextBox txtMessage;
      private System.Windows.Forms.Button btnSend;
      private System.Windows.Forms.Button btnReceive;
   }
}
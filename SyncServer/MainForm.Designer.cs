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
         ButtonStart = new System.Windows.Forms.Button();
         ButtonStop = new System.Windows.Forms.Button();
         txtMessage = new System.Windows.Forms.TextBox();
         ButtonSend = new System.Windows.Forms.Button();
         ButtonReceive = new System.Windows.Forms.Button();
         SuspendLayout();
         // 
         // txtLog
         // 
         txtLog.Location = new System.Drawing.Point(252, 70);
         txtLog.Multiline = true;
         txtLog.Name = "txtLog";
         txtLog.ReadOnly = true;
         txtLog.Size = new System.Drawing.Size(234, 76);
         txtLog.TabIndex = 3;
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
         // ButtonStop
         // 
         ButtonStop.Enabled = false;
         ButtonStop.Location = new System.Drawing.Point(401, 12);
         ButtonStop.Name = "ButtonStop";
         ButtonStop.Size = new System.Drawing.Size(85, 23);
         ButtonStop.TabIndex = 5;
         ButtonStop.Text = "Остановить";
         ButtonStop.UseVisualStyleBackColor = true;
         ButtonStop.Click += ButtonStop_Click;
         // 
         // txtMessage
         // 
         txtMessage.Location = new System.Drawing.Point(12, 70);
         txtMessage.Multiline = true;
         txtMessage.Name = "txtMessage";
         txtMessage.Size = new System.Drawing.Size(234, 76);
         txtMessage.TabIndex = 6;
         // 
         // ButtonSend
         // 
         ButtonSend.Location = new System.Drawing.Point(12, 41);
         ButtonSend.Name = "ButtonSend";
         ButtonSend.Size = new System.Drawing.Size(234, 23);
         ButtonSend.TabIndex = 7;
         ButtonSend.Text = "кнопка отправки сообщения";
         ButtonSend.UseVisualStyleBackColor = true;
         ButtonSend.Click += ButtonSend_Click;
         // 
         // ButtonReceive
         // 
         ButtonReceive.Location = new System.Drawing.Point(252, 41);
         ButtonReceive.Name = "ButtonReceive";
         ButtonReceive.Size = new System.Drawing.Size(234, 23);
         ButtonReceive.TabIndex = 8;
         ButtonReceive.Text = "кнопка приёма сообщения";
         ButtonReceive.UseVisualStyleBackColor = true;
         ButtonReceive.Click += ButtonReceive_Click;
         // 
         // MainForm
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(498, 164);
         Controls.Add(ButtonReceive);
         Controls.Add(ButtonSend);
         Controls.Add(txtMessage);
         Controls.Add(ButtonStop);
         Controls.Add(ButtonStart);
         Controls.Add(txtLog);
         Name = "MainForm";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Двусторонний обмен между Windows Forms и консолью";
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.TextBox txtLog;
      private System.Windows.Forms.Button ButtonStart;
      private System.Windows.Forms.Button ButtonStop;
      private System.Windows.Forms.TextBox txtMessage;
      private System.Windows.Forms.Button ButtonSend;
      private System.Windows.Forms.Button ButtonReceive;
   }
}
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
         txtMessage = new System.Windows.Forms.TextBox();
         ButtonSend = new System.Windows.Forms.Button();
         LabelReceive = new System.Windows.Forms.Label();
         SuspendLayout();
         // 
         // txtLog
         // 
         txtLog.Location = new System.Drawing.Point(252, 42);
         txtLog.Multiline = true;
         txtLog.Name = "txtLog";
         txtLog.ReadOnly = true;
         txtLog.Size = new System.Drawing.Size(234, 76);
         txtLog.TabIndex = 3;
         // 
         // txtMessage
         // 
         txtMessage.Location = new System.Drawing.Point(12, 42);
         txtMessage.Multiline = true;
         txtMessage.Name = "txtMessage";
         txtMessage.Size = new System.Drawing.Size(234, 76);
         txtMessage.TabIndex = 6;
         // 
         // ButtonSend
         // 
         ButtonSend.Location = new System.Drawing.Point(12, 12);
         ButtonSend.Name = "ButtonSend";
         ButtonSend.Size = new System.Drawing.Size(234, 23);
         ButtonSend.TabIndex = 7;
         ButtonSend.Text = "Кнопка отправки сообщения";
         ButtonSend.UseVisualStyleBackColor = true;
         ButtonSend.Click += ButtonSend_Click;
         // 
         // LabelReceive
         // 
         LabelReceive.AutoSize = true;
         LabelReceive.Location = new System.Drawing.Point(252, 16);
         LabelReceive.Name = "LabelReceive";
         LabelReceive.Size = new System.Drawing.Size(113, 15);
         LabelReceive.TabIndex = 9;
         LabelReceive.Text = "Приём сообщений";
         // 
         // MainForm
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(498, 131);
         Controls.Add(LabelReceive);
         Controls.Add(ButtonSend);
         Controls.Add(txtMessage);
         Controls.Add(txtLog);
         Name = "MainForm";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Двусторонний обмен между Windows Forms и консолью";
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.TextBox txtLog;
      private System.Windows.Forms.TextBox txtMessage;
      private System.Windows.Forms.Button ButtonSend;
      private System.Windows.Forms.Label LabelReceive;
   }
}
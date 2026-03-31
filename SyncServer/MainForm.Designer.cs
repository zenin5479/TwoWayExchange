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
         textBoxLog = new System.Windows.Forms.TextBox();
         Label = new System.Windows.Forms.Label();
         buttonStart = new System.Windows.Forms.Button();
         buttonStop = new System.Windows.Forms.Button();
         SuspendLayout();
         // 
         // textBoxLog
         // 
         textBoxLog.Location = new System.Drawing.Point(12, 27);
         textBoxLog.Multiline = true;
         textBoxLog.Name = "textBoxLog";
         textBoxLog.ReadOnly = true;
         textBoxLog.Size = new System.Drawing.Size(100, 23);
         textBoxLog.TabIndex = 3;
         // 
         // Label
         // 
         Label.AutoSize = true;
         Label.Location = new System.Drawing.Point(12, 9);
         Label.Name = "Label";
         Label.Size = new System.Drawing.Size(247, 15);
         Label.TabIndex = 2;
         Label.Text = "Сервер запущен, ожидание подключения...";
         // 
         // buttonStart
         // 
         buttonStart.Location = new System.Drawing.Point(50, 71);
         buttonStart.Name = "buttonStart";
         buttonStart.Size = new System.Drawing.Size(142, 23);
         buttonStart.TabIndex = 4;
         buttonStart.Text = "Запустить сервер";
         buttonStart.UseVisualStyleBackColor = true;
         // 
         // buttonStop
         // 
         buttonStop.Enabled = false;
         buttonStop.Location = new System.Drawing.Point(316, 81);
         buttonStop.Name = "buttonStop";
         buttonStop.Size = new System.Drawing.Size(85, 23);
         buttonStop.TabIndex = 5;
         buttonStop.Text = "Остановить";
         buttonStop.UseVisualStyleBackColor = true;
         // 
         // MainForm
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(472, 132);
         Controls.Add(buttonStop);
         Controls.Add(buttonStart);
         Controls.Add(textBoxLog);
         Controls.Add(Label);
         Name = "MainForm";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Двусторонний обмен между Windows Forms и консолью";
         Load += MainForm_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.TextBox textBoxLog;
      private System.Windows.Forms.Label Label;
      private System.Windows.Forms.Button buttonStart;
      private System.Windows.Forms.Button buttonStop;
   }
}
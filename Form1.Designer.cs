
namespace EEPROM
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      this.btnUpload = new System.Windows.Forms.Button();
      this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.btnDownload = new System.Windows.Forms.Button();
      this.downloadLabel = new System.Windows.Forms.Label();
      this.btnConnect = new System.Windows.Forms.Button();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnUpload
      // 
      this.btnUpload.Location = new System.Drawing.Point(12, 47);
      this.btnUpload.Name = "btnUpload";
      this.btnUpload.Size = new System.Drawing.Size(75, 23);
      this.btnUpload.TabIndex = 0;
      this.btnUpload.Text = "Upload";
      this.btnUpload.UseVisualStyleBackColor = true;
      this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
      // 
      // serialPort1
      // 
      this.serialPort1.PortName = "COM39";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.statusStrip1.Location = new System.Drawing.Point(0, 428);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(800, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(104, 17);
      this.statusLabel.Text = "Готово к работе...";
      // 
      // btnDownload
      // 
      this.btnDownload.Location = new System.Drawing.Point(12, 76);
      this.btnDownload.Name = "btnDownload";
      this.btnDownload.Size = new System.Drawing.Size(75, 23);
      this.btnDownload.TabIndex = 2;
      this.btnDownload.Text = "Download";
      this.btnDownload.UseVisualStyleBackColor = true;
      this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
      // 
      // downloadLabel
      // 
      this.downloadLabel.AutoSize = true;
      this.downloadLabel.Location = new System.Drawing.Point(93, 81);
      this.downloadLabel.Name = "downloadLabel";
      this.downloadLabel.Size = new System.Drawing.Size(35, 13);
      this.downloadLabel.TabIndex = 3;
      this.downloadLabel.Text = "label1";
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(12, 18);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(75, 23);
      this.btnConnect.TabIndex = 4;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.downloadLabel);
      this.Controls.Add(this.btnDownload);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.btnUpload);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Button btnConnect;
    }
}


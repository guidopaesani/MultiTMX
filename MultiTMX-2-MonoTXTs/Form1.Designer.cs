namespace MultiTMX_2_MonoTXTs
{
    partial class MultiTMX2MonoTXTs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiTMX2MonoTXTs));
            this.TxBxInputFile = new System.Windows.Forms.TextBox();
            this.startAsyncButton = new System.Windows.Forms.Button();
            this.BkGdWorker = new System.ComponentModel.BackgroundWorker();
            this.cancelAsyncButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.DescLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxBxInputFile
            // 
            this.TxBxInputFile.Location = new System.Drawing.Point(97, 34);
            this.TxBxInputFile.Name = "TxBxInputFile";
            this.TxBxInputFile.Size = new System.Drawing.Size(422, 20);
            this.TxBxInputFile.TabIndex = 0;
            this.TxBxInputFile.Text = "C:\\_WORK\\_Customers\\Amazon\\AWS\\AWS_TM.tmx";
            this.TxBxInputFile.TextChanged += new System.EventHandler(this.TxBxInputFile_TextChanged);
            // 
            // startAsyncButton
            // 
            this.startAsyncButton.Location = new System.Drawing.Point(363, 63);
            this.startAsyncButton.Name = "startAsyncButton";
            this.startAsyncButton.Size = new System.Drawing.Size(75, 23);
            this.startAsyncButton.TabIndex = 1;
            this.startAsyncButton.Text = "Start";
            this.startAsyncButton.UseVisualStyleBackColor = true;
            this.startAsyncButton.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // BkGdWorker
            // 
            this.BkGdWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkGdWorker_DoWork);
            this.BkGdWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkGdWorker_ProgressChanged);
            this.BkGdWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkGdWorker_RunWorkerCompleted);
            // 
            // cancelAsyncButton
            // 
            this.cancelAsyncButton.Location = new System.Drawing.Point(444, 63);
            this.cancelAsyncButton.Name = "cancelAsyncButton";
            this.cancelAsyncButton.Size = new System.Drawing.Size(75, 23);
            this.cancelAsyncButton.TabIndex = 2;
            this.cancelAsyncButton.Text = "Cancel";
            this.cancelAsyncButton.UseVisualStyleBackColor = true;
            this.cancelAsyncButton.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(157, 96);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(35, 13);
            this.resultLabel.TabIndex = 3;
            this.resultLabel.Text = "status";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 92);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(139, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(13, 34);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(75, 23);
            this.btnInputFile.TabIndex = 5;
            this.btnInputFile.Text = "Input file...";
            this.btnInputFile.UseVisualStyleBackColor = true;
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(12, 9);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(298, 13);
            this.DescLabel.TabIndex = 6;
            this.DescLabel.Text = "Extraction of multilingual TMX segments to individual TXT files";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Label1";
            // 
            // MultiTMX2MonoTXTs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 118);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.btnInputFile);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.cancelAsyncButton);
            this.Controls.Add(this.startAsyncButton);
            this.Controls.Add(this.TxBxInputFile);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultiTMX2MonoTXTs";
            this.Text = "TMX to Monolingual TXTs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxBxInputFile;
        private System.Windows.Forms.Button startAsyncButton;
        private System.ComponentModel.BackgroundWorker BkGdWorker;
        private System.Windows.Forms.Button cancelAsyncButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.Label label1;
    }
}


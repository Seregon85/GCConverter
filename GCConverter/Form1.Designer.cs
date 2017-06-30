namespace GCConverter
{
    partial class GCConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GCConverter));
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdPAL = new System.Windows.Forms.RadioButton();
            this.rdNTSCJ = new System.Windows.Forms.RadioButton();
            this.rdNTSCU = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(247, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(25, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(12, 12);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(229, 20);
            this.txtFilename.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(197, 144);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "&Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(12, 173);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(260, 90);
            this.txtStatus.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.rdPAL);
            this.groupBox1.Controls.Add(this.rdNTSCJ);
            this.groupBox1.Controls.Add(this.rdNTSCU);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Convert to region:";
            // 
            // rdPAL
            // 
            this.rdPAL.AutoSize = true;
            this.rdPAL.Enabled = false;
            this.rdPAL.Location = new System.Drawing.Point(6, 65);
            this.rdPAL.Name = "rdPAL";
            this.rdPAL.Size = new System.Drawing.Size(45, 17);
            this.rdPAL.TabIndex = 5;
            this.rdPAL.Text = "PAL";
            this.rdPAL.UseVisualStyleBackColor = true;
            // 
            // rdNTSCJ
            // 
            this.rdNTSCJ.AutoSize = true;
            this.rdNTSCJ.Enabled = false;
            this.rdNTSCJ.Location = new System.Drawing.Point(6, 42);
            this.rdNTSCJ.Name = "rdNTSCJ";
            this.rdNTSCJ.Size = new System.Drawing.Size(62, 17);
            this.rdNTSCJ.TabIndex = 4;
            this.rdNTSCJ.Text = "NTSC-J";
            this.rdNTSCJ.UseVisualStyleBackColor = true;
            // 
            // rdNTSCU
            // 
            this.rdNTSCU.AutoSize = true;
            this.rdNTSCU.Enabled = false;
            this.rdNTSCU.Location = new System.Drawing.Point(6, 19);
            this.rdNTSCU.Name = "rdNTSCU";
            this.rdNTSCU.Size = new System.Drawing.Size(65, 17);
            this.rdNTSCU.TabIndex = 3;
            this.rdNTSCU.Text = "NTSC-U";
            this.rdNTSCU.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(159, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // GCConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 275);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GCConverter";
            this.Text = "Gamecube Save Converter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdPAL;
        private System.Windows.Forms.RadioButton rdNTSCJ;
        private System.Windows.Forms.RadioButton rdNTSCU;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


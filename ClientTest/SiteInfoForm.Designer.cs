namespace DuoMall.IISClientTest
{
    partial class SiteInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteInfoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtPhysicalPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(117, 3);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(153, 21);
            this.txtSiteName.TabIndex = 2;
            this.txtSiteName.Text = "Test Site";
            // 
            // txtPhysicalPath
            // 
            this.txtPhysicalPath.Location = new System.Drawing.Point(108, 69);
            this.txtPhysicalPath.Name = "txtPhysicalPath";
            this.txtPhysicalPath.Size = new System.Drawing.Size(265, 21);
            this.txtPhysicalPath.TabIndex = 3;
            this.txtPhysicalPath.Text = "D:\\Work\\Project\\EmitTest\\WebApplication1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(117, 31);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "8500";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 148);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(508, 300);
            this.textBox1.TabIndex = 6;
            // 
            // SiteInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 460);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPhysicalPath);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SiteInfoForm";
            this.Text = "IIS站点切换工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.SiteInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox  txtPhysicalPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox textBox1;
    }
}
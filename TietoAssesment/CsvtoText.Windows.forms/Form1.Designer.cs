
namespace CsvtoText.Windows.forms
{
    partial class Form1
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
            this.SelectCSVFileLbl = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SelectReportDIrectoryLbl = new System.Windows.Forms.Label();
            this.GetCSVFileBtn = new System.Windows.Forms.Button();
            this.GetReportDirectoryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectCSVFileLbl
            // 
            this.SelectCSVFileLbl.AutoSize = true;
            this.SelectCSVFileLbl.Location = new System.Drawing.Point(18, 14);
            this.SelectCSVFileLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectCSVFileLbl.Name = "SelectCSVFileLbl";
            this.SelectCSVFileLbl.Size = new System.Drawing.Size(398, 20);
            this.SelectCSVFileLbl.TabIndex = 0;
            this.SelectCSVFileLbl.Text = "Please Select the CSV File with the Persons Particulars";
            this.SelectCSVFileLbl.Click += new System.EventHandler(this.SelectCSVFileLbl_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // SelectReportDIrectoryLbl
            // 
            this.SelectReportDIrectoryLbl.AutoSize = true;
            this.SelectReportDIrectoryLbl.Location = new System.Drawing.Point(18, 112);
            this.SelectReportDIrectoryLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectReportDIrectoryLbl.Name = "SelectReportDIrectoryLbl";
            this.SelectReportDIrectoryLbl.Size = new System.Drawing.Size(353, 20);
            this.SelectReportDIrectoryLbl.TabIndex = 1;
            this.SelectReportDIrectoryLbl.Text = "Please Select the Ddirectory for the Report Files.";
            this.SelectReportDIrectoryLbl.Click += new System.EventHandler(this.SelectReportDIrectoryLbl_Click);
            // 
            // GetCSVFileBtn
            // 
            this.GetCSVFileBtn.Location = new System.Drawing.Point(22, 38);
            this.GetCSVFileBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetCSVFileBtn.Name = "GetCSVFileBtn";
            this.GetCSVFileBtn.Size = new System.Drawing.Size(182, 35);
            this.GetCSVFileBtn.TabIndex = 2;
            this.GetCSVFileBtn.Text = "Select CSV File";
            this.GetCSVFileBtn.UseVisualStyleBackColor = true;
            this.GetCSVFileBtn.Click += new System.EventHandler(this.GetCSVFileBtn_Click);
            // 
            // GetReportDirectoryBtn
            // 
            this.GetReportDirectoryBtn.Location = new System.Drawing.Point(22, 137);
            this.GetReportDirectoryBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetReportDirectoryBtn.Name = "GetReportDirectoryBtn";
            this.GetReportDirectoryBtn.Size = new System.Drawing.Size(182, 35);
            this.GetReportDirectoryBtn.TabIndex = 3;
            this.GetReportDirectoryBtn.Text = "Select Report Directory";
            this.GetReportDirectoryBtn.UseVisualStyleBackColor = true;
            this.GetReportDirectoryBtn.Click += new System.EventHandler(this.GetReportDirectoryBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 228);
            this.Controls.Add(this.GetReportDirectoryBtn);
            this.Controls.Add(this.GetCSVFileBtn);
            this.Controls.Add(this.SelectReportDIrectoryLbl);
            this.Controls.Add(this.SelectCSVFileLbl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "CsvText Test Assessment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectCSVFileLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label SelectReportDIrectoryLbl;
        private System.Windows.Forms.Button GetCSVFileBtn;
        private System.Windows.Forms.Button GetReportDirectoryBtn;
    }
}


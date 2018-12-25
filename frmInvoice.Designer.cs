namespace RAJAS
{
    partial class frmInvoice
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
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.btnProcessData = new System.Windows.Forms.Button();
            this.dtpImportDate = new System.Windows.Forms.DateTimePicker();
            this.lblImportDate = new System.Windows.Forms.Label();
            this.lblSheet = new System.Windows.Forms.Label();
            this.cmbSheet = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog_ = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_ = new System.Windows.Forms.SaveFileDialog();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.btnPreviewReport = new System.Windows.Forms.Button();
            this.txtReportFromToDate = new System.Windows.Forms.TextBox();
            this.lblReportFromToDate = new System.Windows.Forms.Label();
            this.dgvProcess = new System.Windows.Forms.DataGridView();
            this.btnGenerateInvoice = new System.Windows.Forms.Button();
            this.gbInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.btnProcessData);
            this.gbInput.Controls.Add(this.dtpImportDate);
            this.gbInput.Controls.Add(this.lblImportDate);
            this.gbInput.Controls.Add(this.lblSheet);
            this.gbInput.Controls.Add(this.cmbSheet);
            this.gbInput.Controls.Add(this.btnBrowse);
            this.gbInput.Controls.Add(this.lblFilePath);
            this.gbInput.Controls.Add(this.txtFilePath);
            this.gbInput.Location = new System.Drawing.Point(6, 12);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(1274, 73);
            this.gbInput.TabIndex = 2;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Input";
            // 
            // btnProcessData
            // 
            this.btnProcessData.Location = new System.Drawing.Point(835, 32);
            this.btnProcessData.Name = "btnProcessData";
            this.btnProcessData.Size = new System.Drawing.Size(75, 23);
            this.btnProcessData.TabIndex = 9;
            this.btnProcessData.Text = "Process file";
            this.btnProcessData.UseVisualStyleBackColor = true;
            this.btnProcessData.Click += new System.EventHandler(this.btnProcessData_Click);
            // 
            // dtpImportDate
            // 
            this.dtpImportDate.Location = new System.Drawing.Point(22, 37);
            this.dtpImportDate.Name = "dtpImportDate";
            this.dtpImportDate.Size = new System.Drawing.Size(200, 20);
            this.dtpImportDate.TabIndex = 1;
            // 
            // lblImportDate
            // 
            this.lblImportDate.AutoSize = true;
            this.lblImportDate.Location = new System.Drawing.Point(19, 16);
            this.lblImportDate.Name = "lblImportDate";
            this.lblImportDate.Size = new System.Drawing.Size(65, 13);
            this.lblImportDate.TabIndex = 8;
            this.lblImportDate.Text = "Import Date:";
            // 
            // lblSheet
            // 
            this.lblSheet.AutoSize = true;
            this.lblSheet.Location = new System.Drawing.Point(685, 16);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(41, 13);
            this.lblSheet.TabIndex = 5;
            this.lblSheet.Text = "Sheet :";
            // 
            // cmbSheet
            // 
            this.cmbSheet.FormattingEnabled = true;
            this.cmbSheet.Location = new System.Drawing.Point(688, 37);
            this.cmbSheet.Name = "cmbSheet";
            this.cmbSheet.Size = new System.Drawing.Size(134, 21);
            this.cmbSheet.TabIndex = 4;
            this.cmbSheet.DropDown += new System.EventHandler(this.cmbSheet_DropDown);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(608, 32);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(69, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(236, 16);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(54, 13);
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.Text = "File Path :";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(239, 35);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(363, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // openFileDialog_
            // 
            this.openFileDialog_.Filter = "Office Files|*.docx;*.xlsx|Comma Saparetate|*.CSV";
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.btnPreviewReport);
            this.gbOutput.Controls.Add(this.txtReportFromToDate);
            this.gbOutput.Controls.Add(this.lblReportFromToDate);
            this.gbOutput.Controls.Add(this.dgvProcess);
            this.gbOutput.Controls.Add(this.btnGenerateInvoice);
            this.gbOutput.Location = new System.Drawing.Point(6, 91);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(1274, 571);
            this.gbOutput.TabIndex = 3;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // btnPreviewReport
            // 
            this.btnPreviewReport.Enabled = false;
            this.btnPreviewReport.Location = new System.Drawing.Point(679, 19);
            this.btnPreviewReport.Name = "btnPreviewReport";
            this.btnPreviewReport.Size = new System.Drawing.Size(75, 23);
            this.btnPreviewReport.TabIndex = 6;
            this.btnPreviewReport.Text = "Preview Report";
            this.btnPreviewReport.UseVisualStyleBackColor = true;
            this.btnPreviewReport.Click += new System.EventHandler(this.btnPreviewReport_Click);
            // 
            // txtReportFromToDate
            // 
            this.txtReportFromToDate.Enabled = false;
            this.txtReportFromToDate.Location = new System.Drawing.Point(395, 21);
            this.txtReportFromToDate.Name = "txtReportFromToDate";
            this.txtReportFromToDate.Size = new System.Drawing.Size(278, 20);
            this.txtReportFromToDate.TabIndex = 8;
            // 
            // lblReportFromToDate
            // 
            this.lblReportFromToDate.AutoSize = true;
            this.lblReportFromToDate.Location = new System.Drawing.Point(255, 24);
            this.lblReportFromToDate.Name = "lblReportFromToDate";
            this.lblReportFromToDate.Size = new System.Drawing.Size(134, 13);
            this.lblReportFromToDate.TabIndex = 7;
            this.lblReportFromToDate.Text = "Report From and To  Date:";
            // 
            // dgvProcess
            // 
            this.dgvProcess.AllowUserToAddRows = false;
            this.dgvProcess.AllowUserToDeleteRows = false;
            this.dgvProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcess.Location = new System.Drawing.Point(9, 57);
            this.dgvProcess.Name = "dgvProcess";
            this.dgvProcess.ReadOnly = true;
            this.dgvProcess.Size = new System.Drawing.Size(1248, 494);
            this.dgvProcess.TabIndex = 2;
            // 
            // btnGenerateInvoice
            // 
            this.btnGenerateInvoice.Location = new System.Drawing.Point(15, 19);
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Size = new System.Drawing.Size(114, 23);
            this.btnGenerateInvoice.TabIndex = 5;
            this.btnGenerateInvoice.Text = "Generate Invoice";
            this.btnGenerateInvoice.UseVisualStyleBackColor = true;
            this.btnGenerateInvoice.Click += new System.EventHandler(this.btnGenerateInvoice_Click);
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 673);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.Name = "frmInvoice";
            this.Text = "R A J A S";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Button btnProcessData;
        private System.Windows.Forms.DateTimePicker dtpImportDate;
        private System.Windows.Forms.Label lblImportDate;
        private System.Windows.Forms.Label lblSheet;
        private System.Windows.Forms.ComboBox cmbSheet;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog_;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.DataGridView dgvProcess;
        private System.Windows.Forms.Button btnGenerateInvoice;
        private System.Windows.Forms.Button btnPreviewReport;
        private System.Windows.Forms.TextBox txtReportFromToDate;
        private System.Windows.Forms.Label lblReportFromToDate;
    }
}


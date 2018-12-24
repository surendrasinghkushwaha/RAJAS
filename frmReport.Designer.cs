namespace RAJAS
{
    partial class frmReport
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
            this.gbSalesReportPreview = new System.Windows.Forms.GroupBox();
            this.rptvSalesReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbSalesReportPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSalesReportPreview
            // 
            this.gbSalesReportPreview.Controls.Add(this.rptvSalesReport);
            this.gbSalesReportPreview.Location = new System.Drawing.Point(12, 12);
            this.gbSalesReportPreview.Name = "gbSalesReportPreview";
            this.gbSalesReportPreview.Size = new System.Drawing.Size(1268, 649);
            this.gbSalesReportPreview.TabIndex = 15;
            this.gbSalesReportPreview.TabStop = false;
            this.gbSalesReportPreview.Text = "Sales Report Preview";
            // 
            // rptvSalesReport
            // 
            this.rptvSalesReport.Location = new System.Drawing.Point(6, 19);
            this.rptvSalesReport.Name = "rptvSalesReport";
            this.rptvSalesReport.Size = new System.Drawing.Size(1256, 624);
            this.rptvSalesReport.TabIndex = 3;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 673);
            this.Controls.Add(this.gbSalesReportPreview);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.gbSalesReportPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSalesReportPreview;
        private Microsoft.Reporting.WinForms.ReportViewer rptvSalesReport;
    }
}
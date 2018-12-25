using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAJAS
{
    public partial class frmReport : Form
    {
        DataSet dsInvoiceData_ = null; string dateFromTo_ = null;
        public frmReport(DataSet dsInvoiceData,string dateFromTo)
        {
            InitializeComponent();
            dsInvoiceData_ = dsInvoiceData; dateFromTo_ = dateFromTo;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            try { 
            ReportParameter[] rps = new ReportParameter[1];
            rps[0] = new ReportParameter("ReportDate", dateFromTo_);
            //rps[1] = new ReportParameter("ReportTitle", " Invoice");
            //rps[2] = new ReportParameter("Description", " ");//sbDescription.ToString());

            rptvSalesReport.LocalReport.DataSources.Clear(); //clear report
            Microsoft.Reporting.WinForms.ReportDataSource reportdatasource1 = null;
            Microsoft.Reporting.WinForms.ReportDataSource reportdatasource2 = null;
            rptvSalesReport.LocalReport.ReportEmbeddedResource = "RAJAS.rpt_Invoice.rdlc"; // bind reportviewer with .rdlc
            reportdatasource1 = new Microsoft.Reporting.WinForms.ReportDataSource("ClientAddress", dsInvoiceData_.Tables["dtClientAddress"]); // set the datasource
            reportdatasource2 = new Microsoft.Reporting.WinForms.ReportDataSource("InvoiceData", dsInvoiceData_.Tables["dtInvoiceData"]); // set the datasource
            rptvSalesReport.LocalReport.SetParameters(rps);
            rptvSalesReport.LocalReport.DataSources.Add(reportdatasource1);
            rptvSalesReport.LocalReport.DataSources.Add(reportdatasource2);
            // dataset.Value = list;

            rptvSalesReport.LocalReport.Refresh();
            rptvSalesReport.RefreshReport(); // refresh report
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + " Detail:" + ex.StackTrace, "Error"); }
        }
    }
}

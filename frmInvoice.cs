using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCommonSRV = RAJAS.Common_SRV;
namespace RAJAS
{
    public partial class frmInvoice : Form
    {
        public frmInvoice()
        {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog_.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog_.FileName;

                DataTable dt = MyCommonSRV.GetExcelFileSchemaData(new FileInfo(txtFilePath.Text));
                cmbSheet.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = Convert.ToString(dr["TABLE_NAME"]);
                    item.Value = Convert.ToString(dr["TABLE_NAME"]);
                    cmbSheet.Items.Add(item);
                }
            }
        }
        private void cmbSheet_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (ComboboxItem s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s.Text, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void btnProcessData_Click(object sender, EventArgs e)
        {
            if (cmbSheet.SelectedItem != null)
            {
                ComboboxItem item = (ComboboxItem)cmbSheet.SelectedItem;
                DataTable dt = MyCommonSRV.GetExcelCSVFileData(new FileInfo(txtFilePath.Text), item.Text);
                dgvProcess.DataSource = dt.AsDataView();
                dgvProcess.Tag = dt.Copy();

            }
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            if (dgvProcess.Tag != null)
            {
                DataTable dt = (DataTable)dgvProcess.Tag;
                DataSet dsInvoiceReport = GetFinalReportStructureDataSet();
                DataTable dtClientAddress = dsInvoiceReport.Tables["dtClientAddress"];
                DataTable dtInvoiceData = dsInvoiceReport.Tables["dtInvoiceData"];

                foreach (DataRow dr_ in dt.Rows)
                {

                    if (Convert.ToString(dr_["Party Name"]).ToUpper() == "DATE")
                    {
                        break;
                    }
                    DataRow dr = dtClientAddress.NewRow();
                    dr["Address"] = dr_["Party Name"];
                    dtClientAddress.Rows.Add(dr);
                }
                bool IsInvoiceDataFound = false;
                foreach (DataRow dr_ in dt.Rows)
                {

                    if (Convert.ToString(dr_["F2"]).ToUpper() == "TO" && Convert.ToString(dr_["F3"]).ToUpper() == "OPENING BALANCE")
                    {
                        IsInvoiceDataFound = true;
                    }
                    if (IsInvoiceDataFound)
                    {
                        DataRow dr = dtInvoiceData.NewRow();
                        dr["Date"] = dr_["Party Name"];
                        dr["ToBy"] = dr_["F2"];
                        dr["Particulars"] = dr_["F3"];
                        dr["Vch_Type"] = dr_["F4"];
                        dr["Vch_No"] = dr_["F5"];
                        dr["Debit"] = dr_["F6"];
                        dr["Credit"] = dr_["F7"];
                        dtInvoiceData.Rows.Add(dr);
                    }
                }
                // dsInvoiceReport.WriteXmlSchema(@"D:\dsInvoiceReport.xsd");
                btnGenerateInvoice.Tag = dsInvoiceReport.Copy();

            }
        }
        private DataSet GetFinalReportStructureDataSet()
        {
            DataSet dsInvoiceReport = new DataSet("dsInvoiceReport");
            DataTable dt = new DataTable("dtClientAddress");
            dt.Columns.Add("Address", Type.GetType("System.String"));
            dsInvoiceReport.Tables.Add(dt);
            dt = new DataTable("dtInvoiceData");
            dt.Columns.Add("Date", Type.GetType("System.String"));
            dt.Columns.Add("ToBy", Type.GetType("System.String"));
            dt.Columns.Add("Particulars", Type.GetType("System.String"));
            dt.Columns.Add("Vch_Type", Type.GetType("System.String"));
            dt.Columns.Add("Vch_No", Type.GetType("System.String"));
            dt.Columns.Add("Debit", Type.GetType("System.Decimal"));
            dt.Columns.Add("Credit", Type.GetType("System.Decimal"));
            dsInvoiceReport.Tables.Add(dt);
            return dsInvoiceReport;
        }

        private void btnPreviewReport_Click(object sender, EventArgs e)
        {
            DataSet dsInvoiceData = (DataSet)btnGenerateInvoice.Tag;
            if (dsInvoiceData != null)
            {
                frmReport objreport = new frmReport(dsInvoiceData,txtReportFromToDate.Text);
                objreport.Show();
            }
        }
    }
}

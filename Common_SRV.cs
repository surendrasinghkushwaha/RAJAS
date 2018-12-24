using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RAJAS
{
  public  class Common_SRV
    {
        internal static List<DataSet> SplitTable(DataSet originalDataSet, int batchSize = 500)
        {
            List<DataSet> datasets = new List<DataSet>();


            foreach (DataTable dt in originalDataSet.Tables)
            {
                List<DataTable> tables = new List<DataTable>();

                DataTable originalTable = dt.Copy();
                DataTable new_table = new DataTable();
                new_table = originalTable.Clone();
                int j = 0;
                int k = 0;

                if (originalTable.Rows.Count <= batchSize)
                {
                    new_table.TableName = originalTable.TableName;
                    new_table = originalTable.Copy();
                    if (new_table.Rows.Count > 0)
                        tables.Add(new_table.Copy());
                }//if
                else
                {
                    for (int i = 0; i < originalTable.Rows.Count; i++)
                    {
                        new_table.NewRow();
                        new_table.ImportRow(originalTable.Rows[i]);
                        if ((i + 1) == originalTable.Rows.Count)
                        {
                            new_table.TableName = originalTable.TableName;
                            if (new_table.Rows.Count > 0)
                                tables.Add(new_table.Copy());
                            new_table.Rows.Clear();
                            k++;
                        }
                        else if (++j == batchSize)
                        {
                            new_table.TableName = originalTable.TableName;
                            if (new_table.Rows.Count > 0)
                                tables.Add(new_table.Copy());
                            new_table.Rows.Clear();
                            k++;
                            j = 0;
                        }
                    }
                }//else
                foreach (DataTable dt_ in tables)
                {
                    if (dt_.Rows.Count > 0)
                    {
                        DataSet ds_ = originalDataSet.Clone();
                        ds_.Tables.Remove(dt_.TableName);

                        ds_.Tables.Add(dt_.Copy());
                        datasets.Add(ds_);
                    }
                }
            }//loop ds

            return datasets;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public static DataTable GetExcelFileSchemaData(FileInfo file)
        {
            DataTable dt = new DataTable();
            try
            {
                // need to pass relative path after deploying on server
                string path = file.FullName, connectionString = "";
                /* connection string  to work with excel file. HDR=Yes - indicates 
                   that the first row contains columnnames, not data. HDR=No - indicates 
                   the opposite. "IMEX=1;" tells the driver to always read "intermixed" 
                   (numbers, dates, strings etc) data columns as text. 
                Note that this option might affect excel sheet write access negative. */
                switch (Path.GetExtension(path).ToUpper())
                {
                    case ".XLS":
                        {
                            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        break;
                    case ".XLSX":
                        {
                            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;  Data Source=" + path + "; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
                        } break;
                    case ".CSV":
                        {
                            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + file.DirectoryName + "\";  Extended Properties='text;HDR=Yes;FMT=Delimited(,)';";
                            //sheetname = file.Name;
                            dt.Columns.Add("TABLE_NAME", Type.GetType("System.String"));
                            dt.Columns.Add("TABLE_TYPE", Type.GetType("System.String"));
                            DataRow dr = dt.NewRow();
                            dr["TABLE_NAME"] = file.Name;
                            dr["TABLE_TYPE"] = "TABLE";
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        } break;
                }
                if (dt.Columns.Count == 0)
                    using (var oledbConn = new System.Data.OleDb.OleDbConnection(connectionString))
                    {
                        oledbConn.Open();

                        dt = oledbConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    }
            }
            // need to catch possible exceptions
            catch (Exception ex)
            {
                throw ex;
                // MessageBox.Show(ex.ToString(), "GSI-Schema Reading Error");
            }
            return dt;

        }// close of method GemerateExceLData
        public static DataTable GetExcelCSVFileData(FileInfo file, string sheetname)
        {
            DataTable dt = new DataTable("dtData");
            try
            {
                // need to pass relative path after deploying on server
                string path = file.FullName, connectionString = "";
                /* connection string  to work with excel file. HDR=Yes - indicates 
                   that the first row contains columnnames, not data. HDR=No - indicates 
                   the opposite. "IMEX=1;" tells the driver to always read "intermixed" 
                   (numbers, dates, strings etc) data columns as text. 
                Note that this option might affect excel sheet write access negative. */
                switch (Path.GetExtension(path).ToUpper())
                {
                    case ".XLS":
                        {
                            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        break;
                    case ".XLSX":
                        {
                            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;  Data Source=" + path + "; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
                        } break;
                    case ".CSV":
                        {
                            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + file.DirectoryName + "\";  Extended Properties='text;HDR=Yes;FMT=Delimited(,)';";
                            sheetname = file.Name;
                        } break;
                }
                using (var oledbConn = new System.Data.OleDb.OleDbConnection(connectionString))
                {
                    using (var cmd = oledbConn.CreateCommand())
                    {
                        cmd.CommandText = string.Format("SELECT * FROM [{0}]", sheetname);

                        var adapter = new System.Data.OleDb.OleDbDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            // need to catch possible exceptions
            catch (Exception ex)
            {
                throw ex;
                //  MessageBox.Show(ex.ToString(), "GSI-Error in sheet reading");
            }
            return dt;

        }
        #region Create word file with html Content
       public static void ExportDSToExcel(DataSet ds, FileInfo fi)
        {

            using (var workbook = SpreadsheetDocument.Create(fi.FullName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                uint sheetId = 1;

                foreach (DataTable table in ds.Tables)
                {
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                    List<String> columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }
                }
            }

        }
       
        #endregion
        public static String ChangeNumericToWords(double numb)
        {
            String num = numb.ToString();
            return ChangeToWords(num, false);
        }
        public static String ChangeCurrencyToWords(String numb)
        {
            return ChangeToWords(numb, true);
        }
        public static String ChangeNumericToWords(String numb)
        {
            return ChangeToWords(numb, false);
        }
        public static String ChangeCurrencyToWords(double numb)
        {
            return ChangeToWords(numb.ToString(), true);
        }
        private static String ChangeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("point") : ("rupees and");// just to separate whole numbers from points/cents
                        endStr = (isCurrency) ? ("Cents " + endStr) : (" Paise only");
                        pointStr = TranslateCents(points);
                    }
                }
                val = String.Format("{0} {1} {2} {3}", TranslateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }
        private static String TranslateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = Ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = Tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        word = TranslateWholeNumber(number.Substring(0, pos)) + place + TranslateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { ;}
            return word.Trim();
        }
        private static String Tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = Tens(digit.Substring(0, 1) + "0") + " " + Ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static String Ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private static String TranslateCents(String cents)
        {
            return Tens(cents);
            //String cts = "", digit = "", engOne = "";
            //for (int i = 0; i < cents.Length; i++)
            //{
            //    digit = cents[i].ToString();
            //    if (digit.Equals("0"))
            //    {
            //        engOne = "Zero";
            //    }
            //    else
            //    {
            //        engOne = Ones(digit);
            //    }
            //    cts += " " + engOne;
            //}
            //return cts;
        }

    }
  public class ComboboxItem
  {
      public ComboboxItem()
      {

      }
      public ComboboxItem(string text, object value)
      {
          this.Text = text;
          this.Value = value;
      }
      public string Text { get; set; }
      public object Value { get; set; }

      public override string ToString()
      {
          return Text;
      }
  }

}

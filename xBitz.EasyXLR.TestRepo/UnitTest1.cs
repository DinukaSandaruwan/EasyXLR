using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xBitz.EasyXLR.TestRepo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             
             public partial class MyCustomTypesSheet
{
    [Cached]
    public BindingList<MyCustomType> MyCustomTypesDataSource { get; set; }

    private void OnStartup(object sender, System.EventArgs e)
    {
        ExcelTools.ListObject myCustomTypeTable = this.MyCustomTypeData;

        if (this.MyCustomTypesDataSource == null)
        {
            this.MyCustomTypesDataSource = new BindingList<MyCustomType>();
            this.MyCustomTypesDataSource.Add(new MyCustomType());
        }

        myCustomTypeTable.SetDataBinding(this.MyCustomTypesDataSource);
    }

    private void InternalStartup()
    {
        this.Startup += new System.EventHandler(OnStartup);
    }
}
             
             
             */


            //Code section 2 
        /*

            /// <summary>
        /// Submits Report and populates Excel with the results.
        /// All parameters should have been validated prior to calling this method.
        /// </summary>
        private void SubmitReport()
        {
            try
            {
                ReportService.ASGReportsServiceClient sc = new ExcelReportPlugin.ReportService.ASGReportsServiceClient();
                ReportService.ReturnCode oReturn = new ExcelReportPlugin.ReportService.ReturnCode();
                DataSet ds = sc.ExecuteReport(ut, SelReport, ref oReturn);
                if (oReturn.Result == ExcelReportPlugin.ReportService.Code.cSuccess)
                {
                    //Bind Dataset to the Active Excel Sheet.
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
                    worksheet.UsedRange.Clear();
                    Microsoft.Office.Interop.Excel.Range rng = AddData(ds.Tables[0], worksheet);
                    Addtable(rng, "ThisIsMyTable");                    
                }
                else
                {
                    throw new Exception(oReturn.Description, oReturn.Exception);
                }
            }
            catch (Exception e) { ExceptionHandler(e); }
        }
        /// <summary>
        /// Add data to the sheets, with the columns names at the top 
        /// </summary>
        /// <param name="dataTable">The data to be added to the sheet</param>
        /// <param name="sheetToAddTo">The worksheet to add the data to</param>
        /// <returns>The range of the data that has been added</returns>
        private Microsoft.Office.Interop.Excel.Range AddData(System.Data.DataTable dataTable, Microsoft.Office.Interop.Excel.Worksheet sheetToAddTo)
        {
            //create the object to store the column names
            object[,] columnNames;
            columnNames = new object[1, dataTable.Columns.Count];
            //add the columns names from the datatable
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                columnNames[0, i] = dataTable.Columns[i].ColumnName;
            }
 
            //get a range object that the columns will be added to
            Microsoft.Office.Interop.Excel.Range columnsNamesRange = (Microsoft.Office.Interop.Excel.Range)sheetToAddTo.get_Range(sheetToAddTo.Cells[1, 1]
           , sheetToAddTo.Cells[1, dataTable.Columns.Count]);
 
            //a simple assignement allows the data to be transferred quickly
            columnsNamesRange.Value2 = columnNames;
 
            //release the columsn range object now it is finished with
            columnsNamesRange = null;
 
            //create the object to store the dataTable data
            object[,] rowData;
            rowData = new object[dataTable.Rows.Count, dataTable.Columns.Count];
 
            //insert the data into the object[,]
            for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
            {
                for (int iCol = 0; iCol < dataTable.Columns.Count; iCol++)
                {
                    rowData[iRow, iCol] = dataTable.Rows[iRow][iCol];
                }
            }
 
            //get a range to add the table data into 
            //it is one row down to avoid the previously added columns
            Microsoft.Office.Interop.Excel.Range dataCells = (Microsoft.Office.Interop.Excel.Range)sheetToAddTo.get_Range(sheetToAddTo.Cells[2, 1],
            sheetToAddTo.Cells[dataTable.Rows.Count + 1, dataTable.Columns.Count]);
 
            //assign data to worksheet
            dataCells.Value2 = rowData;
            
            //release range
            dataCells = null;
            
            //return the range to the new data
            return sheetToAddTo.get_Range(sheetToAddTo.Cells[1, 1],
           sheetToAddTo.Cells[dataTable.Rows.Count + 1, dataTable.Columns.Count]);
        }
        /// <summary>
        /// This function adds a new Excel table 
        /// (with nice formatting and filtering etc) 
        /// to the tableRange passed in. It names the range tableName. 
        /// This will error if tableName is already used.
        /// This function uses XlYesNoGuess.xlYes to 
        /// automatically make the first row the headings.
        /// </summary>
        /// <param name="tableRange">Range to convert to a table</param>
        /// <param name="tableName">Name of new table</param>
        private void Addtable(Microsoft.Office.Interop.Excel.Range tableRange, string tableName)
        {
            Microsoft.Office.Interop.Excel.Worksheet activeSheet = (Microsoft.Office.Interop.Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
            Microsoft.Office.Interop.Excel.ListObject newList = tableRange.Worksheet.ListObjects.Add(Microsoft.Office.Interop.Excel.XlListObjectSourceType.xlSrcRange, 
                                                                    tableRange,null, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, tableRange);
            newList.Name = tableName;
        }

        */

        }
    }
}

using Microsoft.VisualStudio.Tools.Applications.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Excel;


namespace xBitz.EasyXLR.ExcelAddin
{
    public class XLRDataSource
    {
        public DataTable dt;

        public Microsoft.Office.Tools.Excel.ListObject cListObject { get; set; }
        public Microsoft.Office.Interop.Excel.Range cell { get; set; }
        public string ListName { get; set; } 
        public string StartCell { get; set; }

        public XLRDataSource(string startCell, DataTable dt, string ListName)
        {   
            Worksheet worksheet = Globals.Factory.GetVstoObject(
            Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[1]);
            this.cell = worksheet.Range[startCell];
            cListObject = worksheet.Controls.AddListObject(cell, ListName);
            cListObject.AutoSetDataBoundColumnHeaders = true;
            cListObject.DataSource = dt; 
        }

        private void BindDataSource(DataTable dt)
        {           
            Worksheet worksheet = Globals.Factory.GetVstoObject(
            Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[1]);
            Microsoft.Office.Tools.Excel.ListObject list1;
            Microsoft.Office.Interop.Excel.Range cell = worksheet.Range["A1"];
            list1 = worksheet.Controls.AddListObject(cell, "Customers");
            list1.AutoSetDataBoundColumnHeaders = true;
            list1.DataSource = dt;
          
        }

        public void ReFresh(DataTable dt)
        {
            cListObject.DataSource = dt;
            cListObject.Refresh();
            //Worksheet worksheet = Globals.Factory.GetVstoObject(
            // Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[1]);
            Globals.ThisAddIn.Application.ActiveWorkbook.RefreshAll();
            
        }

    }
}

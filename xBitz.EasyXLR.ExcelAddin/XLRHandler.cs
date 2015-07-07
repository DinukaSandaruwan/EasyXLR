using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xBitz.EasyXLR.ExcelAddin.BL;

namespace xBitz.EasyXLR.ExcelAddin
{
    public class XLRHandler
    {
        public static void Refresh()
        {
            XLRDataSource DS = ThisAddIn.datasource[0];
            DataHandler dt = new DataHandler();
            DS.ReFresh(dt.RefreshDataSource());
        }

        public static bool GetWorkBook(string filePath)
        {
            Application app = XLRExtention.GetExcelApplicationInstance();
            Workbook wb = XLRExtention.GetWorkBook(app, filePath);
            XLRExtention.FindListObject(wb, "customer");
            app.Workbooks.Add(wb);
            return true;
        }
    }
}

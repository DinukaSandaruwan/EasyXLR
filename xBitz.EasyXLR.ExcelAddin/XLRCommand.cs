using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using xBitz.EasyXLR.ExcelAddin.BL;
using xBitz.EasyXLR.ExcelAddin.winForm;
using Office = Microsoft.Office.Core;

namespace xBitz.EasyXLR.ExcelAddin
{
    public class XLRCommand
    {
      
        public void XLRAction(Office.IRibbonControl control)
        {
            //this is test only 
            string cmd = control.Tag;       
            var val = control.Id;
            switch (cmd)
            {
                case "NEW":
                    frmNewProject frm = new frmNewProject();
                    frm.Show();
                    break;
                case "Refresh":
                    XLRExtention.Refresh();
                    break;
                default:
                    
                    break;
            }
        }
    }


    public class XLRSource
    {
        List<XLRFied> ColumnField { get; set; }
        DataTable dt { get; set; }
    }

    public class XLRFied 
    {
        public string ColumnName {get;set;}
        public string ColumnDataType {get;set;}
        public bool IsFilter { get; set; }
    }
}

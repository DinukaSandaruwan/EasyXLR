using Microsoft.Office.Tools.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xBitz.EasyXLR.ExcelAddin.BL;

namespace xBitz.EasyXLR.ExcelAddin.winForm
{
    public partial class frmNewProject : Form
    {
        DataHandler dth = new DataHandler();

        public frmNewProject()
        {
            InitializeComponent();
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {           
            //Worksheet worksheet = Globals.Factory.GetVstoObject(
            //Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[1]);

            //Microsoft.Office.Tools.Excel.ListObject list1;
            //Microsoft.Office.Interop.Excel.Range cell = worksheet.Range["A1"];
            //list1 = worksheet.Controls.AddListObject(cell, "Customers");
            //list1.AutoSetDataBoundColumnHeaders = true;
            //list1.DataSource = dt;
            //this.Close();      
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = dth.FakeDataSource();
            XLRDataSource xl = new XLRDataSource("A1",dt,"customer");
            ThisAddIn.datasource.Add(xl);
        }

       


        
    }
}

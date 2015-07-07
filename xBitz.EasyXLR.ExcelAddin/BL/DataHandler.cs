
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace xBitz.EasyXLR.ExcelAddin.BL
{
    public class DataHandler
    {
        public XLRSource GetDataSource()
        {
            return new XLRSource();
        }
        public DataTable FakeDataSource()
        { 
            DataColumn dt1 = new DataColumn("Name");
            DataColumn dt2 = new DataColumn("Address");
            DataColumn dt3 = new DataColumn("Sales");
            DataTable dt = new DataTable();
            dt.Columns.Add(dt1);
            dt.Columns.Add(dt2);
            dt.Columns.Add(dt3);

            for (int i = 0; i < 100; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "MyName" + i;
                dr[1] = "MyAddress " + i;
                dr[2] = i;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable RefreshDataSource()
        {
            DataColumn dt1 = new DataColumn("Name");
            DataColumn dt2 = new DataColumn("Address");
            DataColumn dt3 = new DataColumn("Sales");
            DataTable dt = new DataTable();
            dt.Columns.Add(dt1);
            dt.Columns.Add(dt2);
            dt.Columns.Add(dt3);

            Random r = new Random();           
            for (int i = 0; i < 100; i++)
            {
                DataRow dr = dt.NewRow();               
                dr[0] = "My Name" + r.Next(1,50).ToString();
                dr[1] = "My Address " + r.Next(1, 50).ToString();
                dr[2] =  r.Next(1, 50).ToString();
                dt.Rows.Add(dr);
                Thread.Sleep(20);
            }
            return dt;
        }
    }
}

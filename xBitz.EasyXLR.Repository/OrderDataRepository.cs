using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xBitz.EasyXLR.Model;
using xBitz.EasyXLR.Repository.Interface;

namespace xBitz.EasyXLR.Repository
{
    public class OrderDataRepository : GenericRepository, IOrderDataRepository
    {
        public ReportData GetOrderData()
        {
            //appLog.Debug("GetOrderData");
            ReportData rpt = new ReportData();
            rpt.viewName = "Test Application ";
            return rpt;
        }
    }
}

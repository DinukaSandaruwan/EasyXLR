using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xBitz.EasyXLR.LogManager;
using xBitz.EasyXLR.Model;
using xBitz.EasyXLR.Repository.Interface;

namespace xBitz.EasyXLR.Repository
{
    public class OrderDataRepository : GenericRepository, IOrderDataRepository
    {
        #region LocalVariables
        private static readonly ILogger log = LogLocator.GetLogger(typeof(OrderDataRepository));
        #endregion

        public ReportData GetOrderData()
        {
            //appLog.Debug("GetOrderData");
            log.DebugFormat(null, "MY TEST MESSAGE", null);
            ReportData rpt = new ReportData();
            rpt.viewName = "Test Application ";
            return rpt;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBitz.EasyXLR.Model;

namespace xBitz.EasyXLR.TestRepo
{
    [TestClass]
    public class WcfServiceTest
    {
        [TestMethod]
        public void TestGetReporData()
        {
            try
            {
                var val = GetReportData();
                Assert.IsNotNull(val);

                var valAsync = GetReportDataAsync();
                Assert.IsNotNull(valAsync); 
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }

        public async Task<ReportData> GetReportDataAsync()
        {
            ServiceReference1.XlReportServiceClient clent = new ServiceReference1.XlReportServiceClient();
            return await clent.GetReportAsync();
        }

        public ReportData GetReportData()
        {
            ServiceReference1.XlReportServiceClient clent = new ServiceReference1.XlReportServiceClient();
            return clent.GetReport();
        }
        
        
    }
}

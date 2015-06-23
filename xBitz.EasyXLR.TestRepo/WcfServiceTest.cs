using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBitz.EasyXLR.TestRepo
{
    [TestClass]
    public class WcfServiceTest
    {
        [TestMethod]
        public void TestGetReporData()
        {
            ServiceReference1.XlReportServiceClient clent = new ServiceReference1.XlReportServiceClient();
            var val = clent.GetReport();
            Assert.IsNotNull(val); 
        }
        
    }
}

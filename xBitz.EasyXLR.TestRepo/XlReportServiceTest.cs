using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBitz.EasyXLR.ServiceManager;

namespace xBitz.EasyXLR.TestRepo
{
     [TestClass]
    public class XlReportServiceTest
    {
         [TestMethod]
         public void GetReport()
         {
             XlReportServiceManager repo = new XlReportServiceManager();
            var  val = repo.GetReport();
            Assert.IsNotNull(val); 
         }
    }
}

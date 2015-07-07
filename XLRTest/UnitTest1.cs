using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBitz.EasyXLR.ExcelAddin.BL;
using System.Data;

namespace XLRTest
{
    [TestClass]
    public class UnitTest1
    {
        
       
        [TestMethod]
        public void BLDataHanlder()
        {
            DataHandler dl = new DataHandler();
            DataTable dt = dl.RefreshDataSource();

            Assert.IsNotNull(dt);
        }
    }
}

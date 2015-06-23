using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBitz.EasyXLR.IService;
using xBitz.EasyXLR.Model;
using xBitz.EasyXLR.Repository;
using xBitz.EasyXLR.Repository.Interface;

namespace xBitz.EasyXLR.ServiceManager
{
    /// <summary>
    /// need to implement factory pattern and replace OrderRep to IOrderRep to decuple the Repository 
    /// </summary>
    public class XlReportServiceManager : BaseServiceManager<OrderDataRepository>, IXlReportService
    {
        public async Task<ReportData> GetReport()
        {
            return await Task.Factory.StartNew<ReportData>(()=> Manger.GetOrderData());
        }       
        //A) create new class for xlFilterParam 
        //B) create new wcf method to implement xlFilter
        //C) create database handler fetch data
        //D) start excel pluging development
                //1. Add Ribon Controller 
                //2. Add new Project Button
                //3. Create new Popup Menu 
                //4. GetdataTable and Display on excel sheet
                //5. Save excel sheet
                //6. Refresh excel sheet
    }
}

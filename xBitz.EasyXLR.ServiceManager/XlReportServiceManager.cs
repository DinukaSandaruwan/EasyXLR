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

        void IXlReportService.GetReport()
        {
            throw new NotImplementedException();
        }
    }
}

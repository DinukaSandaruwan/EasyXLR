using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using xBitz.EasyXLR.Model;

namespace xBitz.EasyXLR.IService
{
    [ServiceContract]
    public interface IXlReportService
    {
        [OperationContract]
        Task<ReportData> GetReport();
    }
}

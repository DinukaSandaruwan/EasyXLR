using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace xBitz.EasyXLR.IService
{
    [ServiceContract]
    public interface IXlReportService
    {
        [OperationContract]
        void GetReport();
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace xBitz.EasyXLR.Model.Interface
{
    public interface IReportData
    {
        string viewName { get; set; }
        DataSet dataSet { get; set; }
    }
}

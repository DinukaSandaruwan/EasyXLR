using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using xBitz.EasyXLR.Model.Interface;

namespace xBitz.EasyXLR.Model
{
    [DataContract]
    public class ReportData : IReportData
    {
        [DataMember]
        public string viewName { get; set; }

        [DataMember]
        public DataTable dataTable { get; set; }

        public List<xlFilter> filter { get;set; }


        
    }
}

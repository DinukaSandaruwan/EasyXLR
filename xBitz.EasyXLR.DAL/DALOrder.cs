using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBitz.EasyXLR.Model.Constants;

namespace xBitz.EasyXLR.DAL
{
    public class DALOrder 
    {
        private IDbManager manager;

        public DALOrder()
        { 
            manager =DbFactory.getDBManager(DatabaseType.SQL);
        }       

        public DataSet GetReportdata(string cmdText)
        {
            try
            {
                return manager.ExecuteDataset(cmdText,CommandType.Text);
            }
            catch (Exception ex)
            {              
                throw ex;
            }
        }
      
    }
}

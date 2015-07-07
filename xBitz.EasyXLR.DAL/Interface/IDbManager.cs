using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBitz.EasyXLR.DAL
{
    public interface IDbManager
    {
        //string GetDbConnection { get; set; }
        DataSet ExecuteDataset(string commandText, CommandType cmdType, SqlParameter[] param = null);
    }
}

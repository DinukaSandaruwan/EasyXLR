using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBitz.EasyXLR.Model.Constants;

namespace xBitz.EasyXLR.DAL
{
    public class DbFactory
    {
        public static IDbManager getDBManager(DatabaseType dbType)
        {
            IDbManager manager ;
            switch (dbType)
            {
                case DatabaseType.SQL:  
                    manager = new DBSqlManager();
                    break;
                case DatabaseType.Access:
                    throw new NotImplementedException();                   
                 default:
                     manager = new DBSqlManager();
                    break;
            }
            return  manager;
        }
    }
}

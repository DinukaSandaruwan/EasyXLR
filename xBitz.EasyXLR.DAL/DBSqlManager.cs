using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBitz.EasyXLR.Model.Constants;

namespace xBitz.EasyXLR.DAL
{
    public sealed class DBSqlManager :IDbManager
    {        
        private static string dbConnection()
        {
            //dycripts connection 
            return GetDBConnection();
        }

        private static string GetDBConnection()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[AppConstance.DB_CONNECTION].ConnectionString;
        }

        protected DataSet ExecuteDataSet(string commandText, CommandType cmdType, SqlParameter[] param = null)
        {
            DataSet ds = new DataSet();
            string ConnectionString = dbConnection();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = cmdType;
                        command.CommandText = commandText;
                        command.Parameters.AddRange(param);
                        SqlDataAdapter dataAdatpter = new SqlDataAdapter(command);
                        dataAdatpter.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();                        
                }
            }
            return ds;
        }




        public DataSet ExecuteDataset(string commandText, CommandType cmdType, SqlParameter[] param = null)
        {
            throw new NotImplementedException();
        }
    }
}

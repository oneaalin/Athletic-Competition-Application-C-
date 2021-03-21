using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.Data.Sqlite;

namespace Contest_CS.repository
{
    public static class DBUtils
    {
        
        private static readonly ILog log = LogManager.GetLogger("DBUtils");
        
        private static IDbConnection instance = null;

        public static IDbConnection getConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection()
        {
			
            return ConnectionUtils.ConnectionFactory.getInstance().createConnection();

            /*var url = ConfigurationManager.ConnectionStrings["Contest"].ConnectionString;
            SqliteConnection connection = null;
            try
            {
                connection = new SqliteConnection(url);
            }
            catch (SqlException e)
            {
                log.Error(e);
            }

            return connection;*/
        }
    }
}
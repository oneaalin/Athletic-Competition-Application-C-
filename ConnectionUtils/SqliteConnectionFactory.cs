using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.Data.Sqlite;
namespace ConnectionUtils
{
    public class SqliteConnectionFactory : ConnectionFactory
    {
        
        private static readonly ILog log = LogManager.GetLogger("ConnectionFactory");
        public override IDbConnection createConnection()
        {
            

            // Windows Sqlite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin
            //String connectionString = "Data Source=contest.db";
            //return new SqliteConnection(connectionString);
            var url = ConfigurationManager.ConnectionStrings["Contest"].ConnectionString;
            SqliteConnection connection = null;
            try
            {
                connection = new SqliteConnection(url);
            }
            catch (SqlException e)
            {
                log.Error(e);
            }

            return connection;
        }
    }
}
using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using log4net;
using Microsoft.Data.Sqlite;

namespace Persistence
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
                //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_dynamic_cdecl());
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection()
        {
			
            return ConnectionFactory.getInstance().createConnection();

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
    
    public abstract class ConnectionFactory
    {
        protected ConnectionFactory()
        {
        }

        private static ConnectionFactory instance;

        public static ConnectionFactory getInstance()
        {
            if (instance == null)
            {

                Assembly assem = Assembly.GetExecutingAssembly();
                Type[] types = assem.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(ConnectionFactory)))
                        instance = (ConnectionFactory)Activator.CreateInstance(type);
                }
            }
            return instance;
        }

        public abstract  IDbConnection createConnection();
    }
    
    public class SqliteConnectionFactory : ConnectionFactory
    {
        
        private static readonly ILog log = LogManager.GetLogger("ConnectionFactory");
        public override IDbConnection createConnection()
        {
            

            // Windows Sqlite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin
            
            /*String connectionString = "Data Source=contest.db";
            return new SqliteConnection(connectionString);*/
            
            var url = ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
            string[] returns = url.Split('=');
            string dbString = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location).Replace(@"\", "/");

            string kstr = dbString.Replace("/Server", "");
            dbString = returns[0] + "=" + kstr + "/" + returns[1];
            return new SQLiteConnection(dbString);
            /*SqliteConnection connection = null;
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
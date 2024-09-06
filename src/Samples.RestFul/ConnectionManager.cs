using System;
using Oracle.DataAccess.Client;
using System.Configuration;
using System.Data;

namespace Samples.RestFul
{
    internal static class ConnectionManager
    {
        static OracleConnection connection = null;

        public static OracleConnection GetConnection()
        {
            string connectionString = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["Oracle"].ConnectionString;
                connection = new OracleConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (ConfigurationException configex)
            {
                throw new ApplicationException("Cannot find a connectionString in config", configex);
            }
            catch (OracleException ex)
            {
            	throw new ApplicationException(string.Format("Cannot connect to datasource: [{0}]",connectionString),ex);
            }
        }
        public static void CloseConnection()
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }
    }
}
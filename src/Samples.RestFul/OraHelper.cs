using System;
using Oracle.DataAccess.Client;
using System.Data;

namespace Samples.RestFul
{
    internal sealed class OraHelper
    {
        internal static int ExecuteCommand(string commandText, OracleParameter[] parameters)
        {
            int rowAffected = 0;
                using (OracleConnection conn = ConnectionManager.GetConnection())
                {
                    using (OracleCommand cmd = new OracleCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(item);
                        }
                        rowAffected = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
            return rowAffected;
        }

        internal OracleDataReader GetReaderFromStore(string commandText,
           OracleParameter[] parameters)
        {
            OracleDataReader reader = null;
            OracleConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();
                using (OracleCommand cmd = new OracleCommand(commandText, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (OracleException ex)
            {
                ConnectionManager.CloseConnection();
                Console.WriteLine(ex.Message);
            }
            return reader;
        }


    }
}

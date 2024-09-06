using System;
using Oracle.DataAccess.Client;

namespace Samples.RestFul
{
    internal static class Util
    {
        internal static string CastNullToString(OracleDataReader reader, string column)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                return reader.GetString(reader.GetOrdinal(column)).Trim();
            return null;
        }

        internal static Decimal? CastNullToDecimal(OracleDataReader reader, string column)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                return reader.GetDecimal(reader.GetOrdinal(column));
            return null;
        }

        internal static DateTime? CastNullToDateTime(OracleDataReader reader, string column)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                return reader.GetDateTime(reader.GetOrdinal(column));
            return null;
        }

        internal static int? CastNullToInt(OracleDataReader reader, string column)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                return reader.GetInt32(reader.GetOrdinal(column));
            return null;
        }

        internal static Employee ScanEmployee()
        {
            var e = new Employee();
            string[] labels = { "Employee ID: ",
                "First name: ", "Last name: ", "Email: ", "Phone: "
                ,"Hire Date: ","Job Id: ","Commission","Salary: "
            };
            string[] fields = new string[labels.Length];
            for (var i = 0; i < labels.Length; i++)
            {
                fields[i] = Scanf(labels[i]);
            }
            e.EmployeeId = ConvertToInt(fields[0]);
            e.FirstName = fields[1];
            e.LastName = fields[2];
            e.Email = fields[3];
            e.PhoneNumber = fields[4];
            e.HireDate = fields[5];
            e.JobId = fields[6];
            e.Commission = ConvertToDecimal(fields[7]);
            e.Salary = ConvertToDecimal(fields[8]);
            return e;
        }

        internal static string Scanf(string message)
        {
            Console.Write("\t[ " + message + " ]\t");
            return Console.ReadLine();
        }

        internal static decimal? ConvertToDecimal(string varchar)
        {
            if (string.IsNullOrEmpty(varchar))
                return null;
            else
                return Convert.ToDecimal(varchar);
        }
        internal static int? ConvertToInt(string varchar)
        {
            if (string.IsNullOrEmpty(varchar))
                return null;
            else
                return Convert.ToInt32(varchar);
        }

        internal static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress [Enter] to continue...");
            Console.ReadLine();
        }

    }
}
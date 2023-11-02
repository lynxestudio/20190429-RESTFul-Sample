using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text;

namespace Samples.WCF.Post
{
    internal static class EmployeesDac
    {
        
        public static int Create(Employee e)
        {
            int rowAffected = 0;
            string commandText = "INSERT INTO employees(employee_id,first_name,last_name,email,phone_number,hire_date,job_id,salary)" +
                "VALUES(:prmEmployeeId,:prmFirstName,:prmLastName,:prmEmail,:prmPhoneNumber,:prmHireDate,:prmJobId,:prmSalary)";
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("prmEmployeeId",e.EmployeeId));
            parameters.Add(new OracleParameter("prmFirstName",e.FirstName));
            parameters.Add(new OracleParameter("prmLastName",e.LastName));
            parameters.Add(new OracleParameter("prmEmail",e.Email));
            parameters.Add(new OracleParameter("prmPhoneNumber",e.PhoneNumber));
            parameters.Add(new OracleParameter("prmHireDate",e.HireDate));
            parameters.Add(new OracleParameter("prmJobId",e.JobId));
            parameters.Add(new OracleParameter("prmSalary",e.Salary));
            rowAffected = OraHelper.ExecuteCommand(commandText, parameters.ToArray());
            return rowAffected;
        }

        public static int Delete(string id)
        {
            int rowAffected = 0;
            string commandText1 = "DELETE FROM job_history WHERE employee_id = :prmEmployeeId ";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("prmEmployeeId", id); 
            rowAffected = OraHelper.ExecuteCommand(commandText1, parameters);
            string commandText2 = "DELETE FROM employees WHERE employee_id = :prmEmployeeId";
            rowAffected = OraHelper.ExecuteCommand(commandText2, parameters);
            return rowAffected;
        }

        public static int Update(Employee e)
        {
            int rowAffected = 0;
            StringBuilder buf = new StringBuilder();
            buf.Append("UPDATE employees SET ");
            buf.Append(" first_name = :prmFirstName");
            buf.Append(" ,last_name = :prmLastName");
            buf.Append(" ,email = :prmEmail");
            buf.Append(" ,phone_number = :prmPhoneNumber");
            buf.Append(" ,hire_date = :prmHireDate");
            buf.Append(" ,job_id = :prmJobId");
            buf.Append(" ,salary = :prmSalary");
            buf.Append(" ,commission_pct = :prmCommission");
            buf.Append(" WHERE employee_id = :prmEmployeeId ");
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("prmFirstName",e.FirstName));
            parameters.Add(new OracleParameter("prmLastName",e.LastName));
            parameters.Add(new OracleParameter("prmEmail", e.Email));
            parameters.Add(new OracleParameter("prmPhoneNumber",e.PhoneNumber));
            parameters.Add(new OracleParameter("prmHireDate",e.HireDate));
            parameters.Add(new OracleParameter("prmJobId",e.JobId));
            parameters.Add(new OracleParameter("prmSalary",e.Salary));
            parameters.Add(new OracleParameter("prmCommission",  e.Commission));
            parameters.Add(new OracleParameter("prmEmployeeId",e.EmployeeId));
            rowAffected = OraHelper.ExecuteCommand(buf.ToString(), parameters.ToArray());
            return rowAffected;
        }

    }
}
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;
using System.Web.Script.Serialization;

namespace NetFrameworkSoapApi
{
    /// <summary>
    /// Summary description for EmployeeListerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeListerService : System.Web.Services.WebService
    {
        /// <summary>
        /// This Function accepts two parameters , send these parameters to oracle store procedure to gather required information.
        /// Returns a List Of Employees
        /// </summary>
        /// <param name="departmentid"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        [WebMethod]
        public List<Employee> select_employeesWithOptionalFilter(int departmentid, int salary)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            OracleCommand objCmd = new OracleCommand();
            objCmd.Connection = conn;
            objCmd.CommandText = "getAllEmployees";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.Add("dep_id", OracleDbType.Int32, ParameterDirection.Input).Value = departmentid;
            objCmd.Parameters.Add("emp_salary", OracleDbType.Int32, ParameterDirection.Input).Value = salary;
            objCmd.Parameters.Add("p_recordset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter odr = new OracleDataAdapter(objCmd);
            DataSet ds = new DataSet();
            odr.Fill(ds);

            var empList = ds.Tables[0].AsEnumerable()
             .Select(dataRow => new Employee
             {
                 EMPLOYEE_ID = dataRow.Field<int>("EMPLOYEE_ID"),
                 FIRST_NAME = dataRow.Field<string>("FIRST_NAME"),
                 LAST_NAME = dataRow.Field<string>("LAST_NAME"),
                 JOB_TITLE = dataRow.Field<string>("JOB_TITLE"),
                 PREVIOUS_POSITION_TITLE = dataRow.Field<string>("PREVIOUS_POSITION_TITLE"),
                 CITY = dataRow.Field<string>("CITY"),
                 SALARY = dataRow.Field<double>("SALARY"),
                 MANAGER_FULLNAME = dataRow.Field<string>("MANAGER_FULLNAME")
             }).ToList();

            return empList;

        }

        /// <summary>
        /// This Function directly send pre defined parameters to oracle store procedure to gather required information.
        /// Returns a List Of Employees
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<Employee> select_employeesWithPreFiltered()
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            OracleCommand objCmd = new OracleCommand();
            objCmd.Connection = conn;
            objCmd.CommandText = "getAllEmployees";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.Add("dep_id", OracleDbType.Int32, ParameterDirection.Input).Value = 60;
            objCmd.Parameters.Add("emp_salary", OracleDbType.Int32, ParameterDirection.Input).Value = 4200;
            objCmd.Parameters.Add("p_recordset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter odr = new OracleDataAdapter(objCmd);
            DataSet ds = new DataSet();
            odr.Fill(ds);

            var empList = ds.Tables[0].AsEnumerable()
             .Select(dataRow => new Employee
             {
                 EMPLOYEE_ID = dataRow.Field<int>("EMPLOYEE_ID"),
                 FIRST_NAME = dataRow.Field<string>("FIRST_NAME"),
                 LAST_NAME = dataRow.Field<string>("LAST_NAME"),
                 JOB_TITLE = dataRow.Field<string>("JOB_TITLE"),
                 PREVIOUS_POSITION_TITLE = dataRow.Field<string>("PREVIOUS_POSITION_TITLE"),
                 CITY = dataRow.Field<string>("CITY"),
                 SALARY = dataRow.Field<double>("SALARY"),
                 MANAGER_FULLNAME = dataRow.Field<string>("MANAGER_FULLNAME")
             }).ToList();

            return empList;

        }

    }
}

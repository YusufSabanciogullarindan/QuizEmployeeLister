using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFrameworkSoapApi
{
    /// <summary>
    /// Employee Class to hold required information that coming from Oracle Stored Procedure.
    /// </summary>
    public class Employee
    {        
        public int EMPLOYEE_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string JOB_TITLE { get; set; }
        public string PREVIOUS_POSITION_TITLE { get; set; }
        public string CITY { get; set; }
        public double SALARY { get; set; }
        public string MANAGER_FULLNAME { get; set; }
    }
}
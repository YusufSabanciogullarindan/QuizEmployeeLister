using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFrameworkSoapApi
{
    class DBOracleUtils
    {
        /// <summary>
        /// Accepts parameters that coming from Web.config to create connectionstring and then creates the Oracle Connection.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="sid"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static OracleConnection
        GetDBConnection(string host, int port, String sid, String user, String password)
        {
        
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleConnection conn = new OracleConnection();

            conn.ConnectionString = connString;

            return conn;
        }

    }
}
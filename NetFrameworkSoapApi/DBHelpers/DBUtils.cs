using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace NetFrameworkSoapApi
{
    public class DBUtils
    {   
        /// <summary>
        /// Gather connection information from Web.config and send to other Util to create connection.
        /// </summary>
        /// <returns></returns>
        public static OracleConnection GetDBConnection()
        {
            string _host = ConfigurationManager.AppSettings["host"];
            int _port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            string _sid = ConfigurationManager.AppSettings["sid"];
            string _user = ConfigurationManager.AppSettings["user"];
            string _password = ConfigurationManager.AppSettings["password"];

            string host = _host;
            int port = _port;
            string sid = _sid;
            string user = _user;
            string password = _password;           

            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }
}
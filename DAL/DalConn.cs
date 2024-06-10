using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace JKTS_Contract_system.DAL
{
    public class DalConn
    {
        // to connect to the database
        public SqlConnection GetConnection()
        {
            SqlConnection dbConn;
            String connString = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

            dbConn = new SqlConnection(connString);

            return dbConn;
        }
    }
}
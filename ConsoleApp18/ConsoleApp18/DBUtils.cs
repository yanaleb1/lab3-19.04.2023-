using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ConsoleApp18
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "commercial_hospital";
            string username = "user1";
            string password = "1";

                return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
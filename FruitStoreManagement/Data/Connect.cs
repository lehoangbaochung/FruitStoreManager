using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FruitStoreManager.Databases
{
    class Connect
    {
        public static SqlConnection ConnectString()
        {
            string datasource = @"DESKTOP-OUF6DI5\SQLEXPRESS";
            string database = "TraiCay";
            string username = null;
            string password = null;

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True";// User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUF6DI5\SQLEXPRESS;Initial Catalog=TraiCay;Integrated Security=True");

            return conn;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace EnchantedPOS
{
    public static class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static MySqlConnection GetConnection()
        {
            MySqlConnection con = new MySqlConnection(GetConnectionString());
            con.Open();
            return con;
        }
    }
}

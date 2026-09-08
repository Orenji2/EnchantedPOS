using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace EnchantedPOS
{
    public static class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            return "Server=localhost;Database=EnchantedPOS;Uid=root;Pwd=Ottos-18052025;";
        }

        public static MySqlConnection GetConnection()
        {
            MySqlConnection con = new MySqlConnection(GetConnectionString());
            con.Open();
            return con;
        }
    }
}

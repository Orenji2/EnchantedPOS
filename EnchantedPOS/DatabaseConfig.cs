using System;
using System.Collections.Generic;
using System.Text;

namespace EnchantedPOS
{
    public static class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            // Reference to the directory of the exe file
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;

            // Reference to the Path of the Database
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(exeFolder, @"..\..\..\dbEn.accdb"));

            // Access uses an OLEDB provider pointing directly to your local file
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
        }
    }
}

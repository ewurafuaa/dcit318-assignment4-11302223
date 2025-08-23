using System.Configuration;
using System.Data.SqlClient;

namespace PharmacyInventoryApp.Data
{
    internal static class Db
    {
        public static string Cs =>
            ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString;

        public static SqlConnection GetConn() => new SqlConnection(Cs);
    }
}

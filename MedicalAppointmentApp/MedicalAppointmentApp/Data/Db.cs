using System.Configuration;
using System.Data.SqlClient;

namespace MedicalAppointmentApp
{
    internal static class Db
    {
        public static SqlConnection GetConn() =>
            new SqlConnection(ConfigurationManager.ConnectionStrings["MedicalDb"].ConnectionString);
    }
}


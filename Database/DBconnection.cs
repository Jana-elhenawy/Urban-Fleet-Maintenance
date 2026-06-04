using Microsoft.Data.SqlClient;

namespace database_app.Database
{
    internal class DBconnection
    {
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=Urban_fleet_and_Maintenance_hub;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
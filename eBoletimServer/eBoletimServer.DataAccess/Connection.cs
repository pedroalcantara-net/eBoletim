using Microsoft.Data.SqlClient;

namespace eBoletimServer.DataAccess
{
    public static class Connection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        private static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("ConnString");
        }
    }
}

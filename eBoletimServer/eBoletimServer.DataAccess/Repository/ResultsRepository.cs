using Dapper;
using eBoletimServer.Domain.Models;
using System.Data;

namespace eBoletimServer.DataAccess.Repository
{
    public static class ResultsRepository
    {
        public static async Task<List<Results>> Get(Results resultQuery)
        {
            var results = new List<Results>();
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    results = conn.Query<Results>("SP_eBoletim_GenerateResults", new
                    {
                        @StudentId = resultQuery.StudentId != null ? resultQuery.StudentId : (int?)null,
                        @Subject = !String.IsNullOrWhiteSpace(resultQuery.SubjectName) ? resultQuery.SubjectName : (string?)null,
                        @Year = resultQuery.Year == null ? resultQuery.Year : (int?)null,
                    }, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {

            }

            return results;
        }
    }
}

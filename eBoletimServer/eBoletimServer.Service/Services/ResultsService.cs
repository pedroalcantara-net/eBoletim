using eBoletimServer.DataAccess.Repository;
using eBoletimServer.Domain.Models;
using eBoletimServer.Domain.Models.ViewModels;

namespace eBoletimServer.Service.Services
{
    public static class ResultsService
    {
        public static async Task<List<Results>> GetById(int id)
        {
            var result = new Results()
            {
                StudentId = id
            };

            return await ResultsRepository.Get(result);
        }
        public static async Task<List<Results>> Get(Results result)
        {
            return await ResultsRepository.Get(result);
        }

        public static async Task<List<ResultsChart>> GetChartById(int id)
        {
            var resultQuery = new Results()
            {
                StudentId = id
            };

            var results = await ResultsRepository.Get(resultQuery);

            var charts = new List<ResultsChart>();

            foreach (var result in results)
            {
                var chartSubject = charts.Where(chart => chart.Subject == result.SubjectName).FirstOrDefault();
                if (chartSubject == null)
                {
                    var newSubject = new ResultsChart()
                    {
                        StudentId = result.StudentId,
                        Year = result.Year,
                        TeacherName = result.TeacherName,
                        Subject = result.SubjectName
                    };

                    charts.Add(newSubject);

                    chartSubject = charts.Where(chart => chart.Subject == result.SubjectName).FirstOrDefault();
                }

                switch (result.Quarter)
                {
                    case 1: chartSubject.Quarter1 = result.Grade; break;
                    case 2: chartSubject.Quarter2 = result.Grade; break;
                    case 3: chartSubject.Quarter3 = result.Grade; break;
                    case 4: chartSubject.Quarter4 = result.Grade; break;
                    default: break;
                }

                if (chartSubject.Quarter1 != null && chartSubject.Quarter2 != null && chartSubject.Quarter3 != null && chartSubject.Quarter4 != null)
                {
                    chartSubject.Average = (chartSubject.Quarter1 + chartSubject.Quarter2 + chartSubject.Quarter3 + chartSubject.Quarter4) / 4;
                    chartSubject.Status = chartSubject.Average >= 5 ? "Approved" : "Failed";
                }
                else
                {
                    chartSubject.Status = "In Progress";
                }
            }

            return charts;
        }
    }
}

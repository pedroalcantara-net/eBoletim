namespace eBoletimServer.Domain.Models.ViewModels
{
    public class ResultsChart
    {
        public int? StudentId { get; set; }
        public string? Subject { get; set; }
        public string? TeacherName { get; set; }
        public int? Year { get; set; }
        public decimal? Quarter1 { get; set; }
        public decimal? Quarter2 { get; set; }
        public decimal? Quarter3 { get; set; }
        public decimal? Quarter4 { get; set; }
        public decimal? Average { get; set; }
        public string? Status { get; set; }
    }
}

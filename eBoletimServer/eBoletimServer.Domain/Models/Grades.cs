namespace eBoletimServer.Domain.Models
{
    public class Grades : BaseModel
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int Quarter { get; set; }
        public decimal Grade { get; set; }
    }
}

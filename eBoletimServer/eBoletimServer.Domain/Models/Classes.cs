namespace eBoletimServer.Domain.Models
{
    public class Classes : BaseModel
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int Year { get; set; }
    }
}

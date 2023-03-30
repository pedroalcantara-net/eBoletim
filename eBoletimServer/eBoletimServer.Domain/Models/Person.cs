namespace eBoletimServer.Domain.Models
{
    public class Person : BaseModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}

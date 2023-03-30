using System;
using System.Collections.Generic;

namespace eBoletimServer.Domain.ModelsTeste
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}

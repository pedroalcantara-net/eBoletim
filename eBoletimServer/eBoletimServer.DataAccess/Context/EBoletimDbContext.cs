using eBoletimServer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace eBoletimServer.Infra.Context
{
    public class EBoletimDbContext : DbContext
    {
        public EBoletimDbContext(DbContextOptions<EBoletimDbContext> opt) : base(opt) { }
        public DbSet<Person> Person { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<StudentClasses> StudentClasses { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

    }
}

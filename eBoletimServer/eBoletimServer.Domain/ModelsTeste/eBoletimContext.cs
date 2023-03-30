using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eBoletimServer.Domain.ModelsTeste
{
    public partial class eBoletimContext : DbContext
    {
        public eBoletimContext()
        {
        }

        public eBoletimContext(DbContextOptions<eBoletimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StudentClass> StudentClasses { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=eBoletim;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.TeacherId, e.Year })
                    .HasName("PK__Classes__A6103B5EE7088E1B");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ClassId, e.Quarter })
                    .HasName("PK__Grades__90E4FC67ED620A41");

                entity.Property(e => e.Grade1)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("Grade");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Person__C1FF9308F304CF43");

                entity.ToTable("Person");

                entity.Property(e => e.Cpf).HasMaxLength(11);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.RegistrationDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Surname).HasMaxLength(250);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Role1)
                    .HasName("PK__Roles__DA15413FC137185D");

                entity.Property(e => e.Role1)
                    .HasMaxLength(50)
                    .HasColumnName("Role");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.StudentId })
                    .HasName("PK__StudentC__48357579310AA2C9");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Subject1)
                    .HasName("PK__Subjects__A2B1D905CE7DBDE6");

                entity.Property(e => e.Subject1)
                    .HasMaxLength(20)
                    .HasColumnName("Subject");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

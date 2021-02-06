using System;
using Microsoft.EntityFrameworkCore;
using Uni.Students.Domain;

namespace Uni.Students.DataAccess
{
    public class StudentDbContext : DbContext
    {
        //TODO: move out in configuration
        private const string _connectionString =
            "Data Source=.; Initial Catalog=students; Integrated Security=true;MultipleActiveResultSets=True; Application Name=Uni.Students";
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Student>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>().Property(s => s.FirstName).IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.LastName).IsRequired();
            modelBuilder.Entity<Student>().HasData(new Student { Id = new Guid("F0668573-0717-4B47-97CF-3842FF4B17AC"), FirstName = "TestFirstName", LastName = "TestLastName" });
        }
    }
}

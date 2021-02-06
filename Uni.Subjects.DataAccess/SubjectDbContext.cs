using System;
using Microsoft.EntityFrameworkCore;
using Uni.Subjects.Domain;

namespace Uni.Subjects.DataAccess
{
    public class SubjectDbContext : DbContext
    {
        //TODO: move out in configuration
        private const string _connectionString =
            "Data Source=.; Initial Catalog=subjects; Integrated Security=true;MultipleActiveResultSets=True; Application Name=Uni.Subjects";

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectStudent> SubjectStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subject>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Subject>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Subject>().Property(s => s.Name).IsRequired();

            modelBuilder.Entity<SubjectStudent>().HasKey(s => new { s.StudentId, s.SubjectId });

            modelBuilder.Entity<SubjectStudent>()
                .HasOne(sc => sc.Subject)
                .WithMany(s => s.SubjectStudents)
                .HasForeignKey(sc => sc.SubjectId);

            modelBuilder.Entity<Subject>().HasData(new Subject { Id = new Guid("F0668573-0717-4B47-97CF-3842FF4B17AD"), Name = "BiologyTest" });
            
            modelBuilder.Entity<SubjectStudent>().HasData(new SubjectStudent { SubjectId = new Guid("F0668573-0717-4B47-97CF-3842FF4B17AD"), StudentId = new Guid("F0668573-0717-4B47-97CF-3842FF4B17AC") });
        }
    }
}

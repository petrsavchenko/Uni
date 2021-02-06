using System;
using Microsoft.EntityFrameworkCore;
using Uni.Lectures.Domain;

namespace Uni.Lectures.DataAccess
{
    public class LectureDbContext : DbContext
    {
        //TODO: move out in configuration
        private const string _connectionString =
            "Data Source=.; Initial Catalog=lectures; Integrated Security=true;MultipleActiveResultSets=True; Application Name=Uni.Lectures";

        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lecture>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Lecture>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Lecture>().HasData(new Lecture 
            { 
                Id = new Guid("B0668573-0717-4B47-97CF-3842FF4B17AD"), 
                SubjectId = new Guid("F0668573-0717-4B47-97CF-3842FF4B17AD"),
                LectureTheatreId = new Guid("A0668573-0717-4B47-97CF-3842FF4B17AD"),
                Duration = new TimeSpan(2, 0, 0),
                StartDate = DateTime.Now
            });
        }
    }
}

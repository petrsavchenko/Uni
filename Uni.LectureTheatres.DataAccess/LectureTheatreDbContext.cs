using System;
using Microsoft.EntityFrameworkCore;
using Uni.LectureTheatres.Domain;

namespace Uni.LectureTheatres.DataAccess
{
    public class LectureTheatreDbContext : DbContext
    {
        //TODO: move out in configuration
        private const string _connectionString =
            "Data Source=.; Initial Catalog=lectureTheatres; Integrated Security=true;MultipleActiveResultSets=True; Application Name=Uni.LectureTheatres";

        public DbSet<LectureTheatre> LectureTheatres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LectureTheatre>().HasKey(s => new { s.Id });
            modelBuilder.Entity<LectureTheatre>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<LectureTheatre>().HasData(new LectureTheatre { Id = new Guid("A0668573-0717-4B47-97CF-3842FF4B17AD"), Name = "Room15_Test", Capacity = 100 });
        }
    }
}

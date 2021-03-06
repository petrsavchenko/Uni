﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uni.Lectures.DataAccess;

namespace Uni.Lectures.DataAccess.Migrations
{
    [DbContext(typeof(LectureDbContext))]
    [Migration("20210206030102_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Uni.Lectures.Domain.Lecture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<Guid>("LectureTheatreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Lectures");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0668573-0717-4b47-97cf-3842ff4b17ad"),
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            LectureTheatreId = new Guid("a0668573-0717-4b47-97cf-3842ff4b17ad"),
                            StartDate = new DateTime(2021, 2, 6, 14, 1, 2, 178, DateTimeKind.Local).AddTicks(7877),
                            SubjectId = new Guid("f0668573-0717-4b47-97cf-3842ff4b17ad")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

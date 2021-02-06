﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uni.Subjects.DataAccess;

namespace Uni.Subjects.DataAccess.Migrations
{
    [DbContext(typeof(SubjectDbContext))]
    [Migration("20210206044157_addedRequiredRestrictionOnColumns")]
    partial class addedRequiredRestrictionOnColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Uni.Subjects.Domain.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f0668573-0717-4b47-97cf-3842ff4b17ad"),
                            Name = "BiologyTest"
                        });
                });

            modelBuilder.Entity("Uni.Subjects.Domain.SubjectStudent", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectStudents");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("f0668573-0717-4b47-97cf-3842ff4b17ac"),
                            SubjectId = new Guid("f0668573-0717-4b47-97cf-3842ff4b17ad")
                        });
                });

            modelBuilder.Entity("Uni.Subjects.Domain.SubjectStudent", b =>
                {
                    b.HasOne("Uni.Subjects.Domain.Subject", "Subject")
                        .WithMany("SubjectStudents")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Uni.Subjects.Domain.Subject", b =>
                {
                    b.Navigation("SubjectStudents");
                });
#pragma warning restore 612, 618
        }
    }
}

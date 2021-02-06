using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uni.Lectures.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureTheatreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "Id", "Duration", "LectureTheatreId", "StartDate", "SubjectId" },
                values: new object[] { new Guid("b0668573-0717-4b47-97cf-3842ff4b17ad"), new TimeSpan(0, 2, 0, 0, 0), new Guid("a0668573-0717-4b47-97cf-3842ff4b17ad"), new DateTime(2021, 2, 6, 14, 1, 2, 178, DateTimeKind.Local).AddTicks(7877), new Guid("f0668573-0717-4b47-97cf-3842ff4b17ad") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectures");
        }
    }
}

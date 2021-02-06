using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uni.LectureTheatres.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LectureTheatres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureTheatres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LectureTheatres",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("a0668573-0717-4b47-97cf-3842ff4b17ad"), 100, "Room15_Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureTheatres");
        }
    }
}

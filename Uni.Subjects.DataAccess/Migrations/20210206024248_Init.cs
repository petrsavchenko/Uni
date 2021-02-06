using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uni.Subjects.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectStudents",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectStudents", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectStudents_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f0668573-0717-4b47-97cf-3842ff4b17ad"), "BiologyTest" });

            migrationBuilder.InsertData(
                table: "SubjectStudents",
                columns: new[] { "StudentId", "SubjectId" },
                values: new object[] { new Guid("f0668573-0717-4b47-97cf-3842ff4b17ac"), new Guid("f0668573-0717-4b47-97cf-3842ff4b17ad") });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStudents_SubjectId",
                table: "SubjectStudents",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectStudents");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}

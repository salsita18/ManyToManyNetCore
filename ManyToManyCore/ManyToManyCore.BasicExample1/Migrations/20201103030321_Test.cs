using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManyToManyCore.BasicExample1.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiddleEntity<Job, Person, Guid, int>",
                columns: table => new
                {
                    IdDependent = table.Column<Guid>(nullable: false),
                    IdHolder = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleEntity<Job, Person, Guid, int>", x => new { x.IdHolder, x.IdDependent });
                    table.ForeignKey(
                        name: "FK_MiddleEntity<Job, Person, Guid, int>_Job_IdDependent",
                        column: x => x.IdDependent,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiddleEntity<Job, Person, Guid, int>_Person_IdHolder",
                        column: x => x.IdHolder,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiddleEntity<Job, Person, Guid, int>_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiddleEntity<Job, Person, Guid, int>_IdDependent",
                table: "MiddleEntity<Job, Person, Guid, int>",
                column: "IdDependent");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleEntity<Job, Person, Guid, int>_PersonId",
                table: "MiddleEntity<Job, Person, Guid, int>",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiddleEntity<Job, Person, Guid, int>");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}

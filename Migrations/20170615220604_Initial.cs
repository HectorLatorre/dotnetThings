using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace firstapp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IDCurso = table.Column<int>(nullable: false),
                    Creditos = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.IDCurso);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IDUser = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Apellido = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    IDInscripcion = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    IDCurso = table.Column<int>(nullable: false),
                    IDUser = table.Column<int>(nullable: false),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.IDInscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Curso_IDCurso",
                        column: x => x.IDCurso,
                        principalTable: "Curso",
                        principalColumn: "IDCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_User_IDUser",
                        column: x => x.IDUser,
                        principalTable: "User",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_IDCurso",
                table: "Inscripcion",
                column: "IDCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_IDUser",
                table: "Inscripcion",
                column: "IDUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class correctionsv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEstudiante",
                table: "ProfesorAlumnos");

            migrationBuilder.DropColumn(
                name: "IdProfesor",
                table: "ProfesorAlumnos");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "ProfesorAlumnos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AltaSistema",
                table: "ProfesorAlumnos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "ProfesorAlumnos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "ProfesorAlumnos");

            migrationBuilder.DropColumn(
                name: "AltaSistema",
                table: "ProfesorAlumnos");

            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "ProfesorAlumnos");

            migrationBuilder.AddColumn<int>(
                name: "IdEstudiante",
                table: "ProfesorAlumnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProfesor",
                table: "ProfesorAlumnos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class corrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEscuela",
                table: "AlumnoEscuelas");

            migrationBuilder.DropColumn(
                name: "IdEstudiante",
                table: "AlumnoEscuelas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEscuela",
                table: "AlumnoEscuelas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEstudiante",
                table: "AlumnoEscuelas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

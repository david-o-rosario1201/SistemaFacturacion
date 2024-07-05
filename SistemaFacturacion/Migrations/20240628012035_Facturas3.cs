using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion.Migrations
{
    /// <inheritdoc />
    public partial class Facturas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreEncargado",
                table: "Facturas",
                newName: "Telefono");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Facturas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Facturas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Facturas");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Facturas",
                newName: "NombreEncargado");
        }
    }
}

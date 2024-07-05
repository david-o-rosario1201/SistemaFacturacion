using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion.Migrations
{
    /// <inheritdoc />
    public partial class Facturas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FacturasDetalle_ProductoId",
                table: "FacturasDetalle",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturasDetalle_Productos_ProductoId",
                table: "FacturasDetalle",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturasDetalle_Productos_ProductoId",
                table: "FacturasDetalle");

            migrationBuilder.DropIndex(
                name: "IX_FacturasDetalle_ProductoId",
                table: "FacturasDetalle");
        }
    }
}

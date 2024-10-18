using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestamosAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrestamoSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Clientes_IdCliente",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_EstadoPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "EstadoPrestamoId",
                table: "Prestamos");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "EstadoPrestamos",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Clientes",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdEstadoPrestamo",
                table: "Prestamos",
                column: "IdEstadoPrestamo");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Clientes_IdCliente",
                table: "Prestamos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_IdEstadoPrestamo",
                table: "Prestamos",
                column: "IdEstadoPrestamo",
                principalTable: "EstadoPrestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Clientes_IdCliente",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_IdEstadoPrestamo",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_IdEstadoPrestamo",
                table: "Prestamos");

            migrationBuilder.AddColumn<int>(
                name: "EstadoPrestamoId",
                table: "Prestamos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "EstadoPrestamos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Clientes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_EstadoPrestamoId",
                table: "Prestamos",
                column: "EstadoPrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Clientes_IdCliente",
                table: "Prestamos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "Prestamos",
                column: "EstadoPrestamoId",
                principalTable: "EstadoPrestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

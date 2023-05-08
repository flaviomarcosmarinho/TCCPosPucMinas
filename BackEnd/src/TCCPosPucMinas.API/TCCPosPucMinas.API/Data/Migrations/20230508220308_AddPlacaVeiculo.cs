using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCPosPucMinas.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlacaVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Veiculos",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Veiculos");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfectShoes.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CSV",
                table: "CreditCards",
                newName: "CVC");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CVC",
                table: "CreditCards",
                newName: "CSV");
        }
    }
}

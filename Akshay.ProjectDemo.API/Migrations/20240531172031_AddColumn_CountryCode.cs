using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akshay.ProjectDemo.API.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_CountryCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "countries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "countries");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Downing.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixcompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Companies",
                newName: "CompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Companies",
                newName: "Title");
        }
    }
}

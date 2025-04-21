using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaggyProject.Migrations
{
    /// <inheritdoc />
    public partial class add_category_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Costumes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Costumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

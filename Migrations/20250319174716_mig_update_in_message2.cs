using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaggyProject.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_in_message2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "Content",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

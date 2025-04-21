using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaggyProject.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_in_message : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message_Content",
                table: "Messages",
                newName: "MessageBody");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "MessageBody",
                table: "Messages",
                newName: "Message_Content");
        }
    }
}

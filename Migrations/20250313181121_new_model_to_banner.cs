using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaggyProject.Migrations
{
    /// <inheritdoc />
    public partial class new_model_to_banner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Banners",
                newName: "BannerImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BannerImageUrl",
                table: "Banners",
                newName: "ImageUrl");
        }
    }
}

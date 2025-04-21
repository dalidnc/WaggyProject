using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaggyProject.Migrations
{
    /// <inheritdoc />
    public partial class update_last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costume_Categories_CategoryId",
                table: "Costume");

            migrationBuilder.DropForeignKey(
                name: "FK_Feature_Products_ProductId",
                table: "Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feature",
                table: "Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costume",
                table: "Costume");

            migrationBuilder.RenameTable(
                name: "Feature",
                newName: "Features");

            migrationBuilder.RenameTable(
                name: "Costume",
                newName: "Costumes");

            migrationBuilder.RenameIndex(
                name: "IX_Feature_ProductId",
                table: "Features",
                newName: "IX_Features_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Costume_CategoryId",
                table: "Costumes",
                newName: "IX_Costumes_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Features",
                table: "Features",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costumes",
                table: "Costumes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Costumes_Categories_CategoryId",
                table: "Costumes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Products_ProductId",
                table: "Features",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costumes_Categories_CategoryId",
                table: "Costumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Products_ProductId",
                table: "Features");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Features",
                table: "Features");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costumes",
                table: "Costumes");

            migrationBuilder.RenameTable(
                name: "Features",
                newName: "Feature");

            migrationBuilder.RenameTable(
                name: "Costumes",
                newName: "Costume");

            migrationBuilder.RenameIndex(
                name: "IX_Features_ProductId",
                table: "Feature",
                newName: "IX_Feature_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Costumes_CategoryId",
                table: "Costume",
                newName: "IX_Costume_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feature",
                table: "Feature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costume",
                table: "Costume",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Costume_Categories_CategoryId",
                table: "Costume",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_Products_ProductId",
                table: "Feature",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

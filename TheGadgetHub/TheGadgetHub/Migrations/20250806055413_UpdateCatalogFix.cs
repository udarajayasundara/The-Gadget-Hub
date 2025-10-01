using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheGadgetHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCatalogFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GlobalProductCatalog",
                table: "GlobalProductCatalog");

            migrationBuilder.RenameTable(
                name: "GlobalProductCatalog",
                newName: "GlobalProductCatlog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlobalProductCatlog",
                table: "GlobalProductCatlog",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GlobalProductCatlog",
                table: "GlobalProductCatlog");

            migrationBuilder.RenameTable(
                name: "GlobalProductCatlog",
                newName: "GlobalProductCatalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlobalProductCatalog",
                table: "GlobalProductCatalog",
                column: "Id");
        }
    }
}

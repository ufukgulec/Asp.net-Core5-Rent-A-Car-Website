using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAracKiralama.Migrations
{
    public partial class brandlogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandLogoUrl",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandLogoUrl",
                table: "Brands");
        }
    }
}

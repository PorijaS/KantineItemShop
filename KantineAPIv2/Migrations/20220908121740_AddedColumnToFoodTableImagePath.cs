using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KantineAPIv2.Migrations
{
    public partial class AddedColumnToFoodTableImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Food",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Food");
        }
    }
}

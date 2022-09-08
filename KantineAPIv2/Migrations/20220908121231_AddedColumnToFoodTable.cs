using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KantineAPIv2.Migrations
{
    public partial class AddedColumnToFoodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Food",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Food");
        }
    }
}

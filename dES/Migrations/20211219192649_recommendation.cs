using Microsoft.EntityFrameworkCore.Migrations;

namespace dES.Migrations
{
    public partial class recommendation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Recommendation",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "Products");
        }
    }
}

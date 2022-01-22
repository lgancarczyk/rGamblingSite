using Microsoft.EntityFrameworkCore.Migrations;

namespace gamblingSite.Migrations
{
    public partial class isClosed_RoulleteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "RouletteModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "RouletteModels");
        }
    }
}

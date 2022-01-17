using Microsoft.EntityFrameworkCore.Migrations;

namespace gamblingSite.Migrations
{
    public partial class Extended_IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MoneyAmount",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyAmount",
                table: "AspNetUsers");
        }
    }
}

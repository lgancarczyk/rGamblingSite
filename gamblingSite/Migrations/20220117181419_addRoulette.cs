using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gamblingSite.Migrations
{
    public partial class addRoulette : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RouletteModel",
                columns: table => new
                {
                    SpinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouletteModel", x => x.SpinID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRouletteModel",
                columns: table => new
                {
                    SpinsSpinID = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRouletteModel", x => new { x.SpinsSpinID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRouletteModel_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRouletteModel_RouletteModel_SpinsSpinID",
                        column: x => x.SpinsSpinID,
                        principalTable: "RouletteModel",
                        principalColumn: "SpinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRouletteModel_UsersId",
                table: "ApplicationUserRouletteModel",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRouletteModel");

            migrationBuilder.DropTable(
                name: "RouletteModel");
        }
    }
}

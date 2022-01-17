using Microsoft.EntityFrameworkCore.Migrations;

namespace gamblingSite.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRouletteModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouletteModel",
                table: "RouletteModel");

            migrationBuilder.RenameTable(
                name: "RouletteModel",
                newName: "RouletteModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouletteModels",
                table: "RouletteModels",
                column: "SpinID");

            migrationBuilder.CreateTable(
                name: "ApplicationUserRouletteModels",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpinId = table.Column<int>(type: "int", nullable: false),
                    Stake = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRouletteModels", x => new { x.UserId, x.SpinId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRouletteModels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRouletteModels_RouletteModels_SpinId",
                        column: x => x.SpinId,
                        principalTable: "RouletteModels",
                        principalColumn: "SpinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRouletteModels_SpinId",
                table: "ApplicationUserRouletteModels",
                column: "SpinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRouletteModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouletteModels",
                table: "RouletteModels");

            migrationBuilder.RenameTable(
                name: "RouletteModels",
                newName: "RouletteModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouletteModel",
                table: "RouletteModel",
                column: "SpinID");

            migrationBuilder.CreateTable(
                name: "ApplicationUserRouletteModel",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RouletteModelsSpinID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRouletteModel", x => new { x.ApplicationUsersId, x.RouletteModelsSpinID });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRouletteModel_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRouletteModel_RouletteModel_RouletteModelsSpinID",
                        column: x => x.RouletteModelsSpinID,
                        principalTable: "RouletteModel",
                        principalColumn: "SpinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRouletteModel_RouletteModelsSpinID",
                table: "ApplicationUserRouletteModel",
                column: "RouletteModelsSpinID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace gamblingSite.Migrations
{
    public partial class addedPromo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromoCodeModel",
                columns: table => new
                {
                    PromoCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeModel", x => x.PromoCodeId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserPromoCodeModel",
                columns: table => new
                {
                    applicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    promoCodeModelsPromoCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserPromoCodeModel", x => new { x.applicationUsersId, x.promoCodeModelsPromoCodeId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserPromoCodeModel_AspNetUsers_applicationUsersId",
                        column: x => x.applicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserPromoCodeModel_PromoCodeModel_promoCodeModelsPromoCodeId",
                        column: x => x.promoCodeModelsPromoCodeId,
                        principalTable: "PromoCodeModel",
                        principalColumn: "PromoCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserPromoCodeModel_promoCodeModelsPromoCodeId",
                table: "ApplicationUserPromoCodeModel",
                column: "promoCodeModelsPromoCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserPromoCodeModel");

            migrationBuilder.DropTable(
                name: "PromoCodeModel");
        }
    }
}

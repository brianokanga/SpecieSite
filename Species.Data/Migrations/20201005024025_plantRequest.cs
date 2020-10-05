using Microsoft.EntityFrameworkCore.Migrations;

namespace Species.Data.Migrations
{
    public partial class plantRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantRequests_SubCounties_SubCountyId",
                table: "PlantRequests");

            migrationBuilder.DropIndex(
                name: "IX_PlantRequests_SubCountyId",
                table: "PlantRequests");

            migrationBuilder.DropColumn(
                name: "SubCountyId",
                table: "PlantRequests");

            migrationBuilder.AddColumn<int>(
                name: "PlantRequestId",
                table: "SubCounties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCounties_PlantRequestId",
                table: "SubCounties",
                column: "PlantRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCounties_PlantRequests_PlantRequestId",
                table: "SubCounties",
                column: "PlantRequestId",
                principalTable: "PlantRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCounties_PlantRequests_PlantRequestId",
                table: "SubCounties");

            migrationBuilder.DropIndex(
                name: "IX_SubCounties_PlantRequestId",
                table: "SubCounties");

            migrationBuilder.DropColumn(
                name: "PlantRequestId",
                table: "SubCounties");

            migrationBuilder.AddColumn<int>(
                name: "SubCountyId",
                table: "PlantRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantRequests_SubCountyId",
                table: "PlantRequests",
                column: "SubCountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantRequests_SubCounties_SubCountyId",
                table: "PlantRequests",
                column: "SubCountyId",
                principalTable: "SubCounties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

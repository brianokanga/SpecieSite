using Microsoft.EntityFrameworkCore.Migrations;

namespace Species.Data.Migrations
{
    public partial class AddSpecieDetailsRefactorToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecieInformations_Locations_LocationId",
                table: "SpecieInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecieInformations_Species_SpecieId",
                table: "SpecieInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecieInformations",
                table: "SpecieInformations");

            migrationBuilder.RenameTable(
                name: "SpecieInformations",
                newName: "SpecieDetails");

            migrationBuilder.RenameIndex(
                name: "IX_SpecieInformations_SpecieId",
                table: "SpecieDetails",
                newName: "IX_SpecieDetails_SpecieId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecieInformations_LocationId",
                table: "SpecieDetails",
                newName: "IX_SpecieDetails_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecieDetails",
                table: "SpecieDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecieDetails_Locations_LocationId",
                table: "SpecieDetails",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecieDetails_Species_SpecieId",
                table: "SpecieDetails",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecieDetails_Locations_LocationId",
                table: "SpecieDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecieDetails_Species_SpecieId",
                table: "SpecieDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecieDetails",
                table: "SpecieDetails");

            migrationBuilder.RenameTable(
                name: "SpecieDetails",
                newName: "SpecieInformations");

            migrationBuilder.RenameIndex(
                name: "IX_SpecieDetails_SpecieId",
                table: "SpecieInformations",
                newName: "IX_SpecieInformations_SpecieId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecieDetails_LocationId",
                table: "SpecieInformations",
                newName: "IX_SpecieInformations_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecieInformations",
                table: "SpecieInformations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecieInformations_Locations_LocationId",
                table: "SpecieInformations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecieInformations_Species_SpecieId",
                table: "SpecieInformations",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

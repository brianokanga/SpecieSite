using Microsoft.EntityFrameworkCore.Migrations;

namespace Species.Data.Migrations
{
    public partial class AddModelsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountyId = table.Column<int>(nullable: false),
                    SubCountyId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    SpecieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantRequests_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlantRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counties_PlantRequests_PlantRequestId",
                        column: x => x.PlantRequestId,
                        principalTable: "PlantRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCounties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCounties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCounties_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SubCountyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_SubCounties_SubCountyId",
                        column: x => x.SubCountyId,
                        principalTable: "SubCounties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecieInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapUrl = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    SpecieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecieInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecieInformations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecieInformations_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Counties_PlantRequestId",
                table: "Counties",
                column: "PlantRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SubCountyId",
                table: "Locations",
                column: "SubCountyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantRequests_CountyId",
                table: "PlantRequests",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantRequests_LocationId",
                table: "PlantRequests",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantRequests_SpecieId",
                table: "PlantRequests",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantRequests_SubCountyId",
                table: "PlantRequests",
                column: "SubCountyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieInformations_LocationId",
                table: "SpecieInformations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecieInformations_SpecieId",
                table: "SpecieInformations",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCounties_CountyId",
                table: "SubCounties",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantRequests_SubCounties_SubCountyId",
                table: "PlantRequests",
                column: "SubCountyId",
                principalTable: "SubCounties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantRequests_Counties_CountyId",
                table: "PlantRequests",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantRequests_Locations_LocationId",
                table: "PlantRequests",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counties_PlantRequests_PlantRequestId",
                table: "Counties");

            migrationBuilder.DropTable(
                name: "SpecieInformations");

            migrationBuilder.DropTable(
                name: "PlantRequests");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "SubCounties");

            migrationBuilder.DropTable(
                name: "Counties");
        }
    }
}

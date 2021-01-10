using Microsoft.EntityFrameworkCore.Migrations;

namespace ddfgroup.Migrations
{
    public partial class Migupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Cars_CarsModel_CarsModelId",
            //    table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarsModelId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarModelName",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarsModelId",
                table: "Cars",
                column: "CarsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarsModel_CarsModelId",
                table: "Cars",
                column: "CarsModelId",
                principalTable: "CarsModel",
                principalColumn: "CarsModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

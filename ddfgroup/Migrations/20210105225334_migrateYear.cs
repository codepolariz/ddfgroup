using Microsoft.EntityFrameworkCore.Migrations;

namespace ddfgroup.Migrations
{
    public partial class migrateYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "CarModelName",
            //    table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "CarsModel",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "ModelName",
            //    table: "Cars",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "CarsModel");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarModelName",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

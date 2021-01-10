using Microsoft.EntityFrameworkCore.Migrations;

namespace ddfgroup.Migrations
{
    public partial class updatedNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrayFileName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ArrayFileType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DisplayFileType",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ArrayFilePath",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrayFilePath",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ArrayFileName",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrayFileType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayFileType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

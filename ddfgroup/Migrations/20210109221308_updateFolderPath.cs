using Microsoft.EntityFrameworkCore.Migrations;

namespace ddfgroup.Migrations
{
    public partial class updateFolderPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrayFilePath",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DisplayFilePath",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ArrayFileName",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FolderName",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbFolderName",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrayFileName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FolderName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ThumbFolderName",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ArrayFilePath",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayFilePath",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

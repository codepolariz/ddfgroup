using Microsoft.EntityFrameworkCore.Migrations;

namespace ddfgroup.Migrations
{
    public partial class migrateNewest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayFilePath",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayFilePath",
                table: "Cars");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace T4Challenge.Data.Migrations
{
    public partial class databaseFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsClient",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsClient",
                table: "AspNetUsers");
        }
    }
}

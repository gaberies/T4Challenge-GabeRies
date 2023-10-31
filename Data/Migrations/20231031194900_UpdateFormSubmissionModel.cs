using Microsoft.EntityFrameworkCore.Migrations;

namespace T4Challenge.Data.Migrations
{
    public partial class UpdateFormSubmissionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "FormSubmissions");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FormSubmissions");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace T4Challenge.Data.Migrations
{
    public partial class AddDynamicFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DynamicFields",
                table: "FormSubmissions");

            migrationBuilder.CreateTable(
                name: "DynamicFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldName = table.Column<string>(type: "TEXT", nullable: false),
                    FieldValue = table.Column<string>(type: "TEXT", nullable: false),
                    FormSubmissionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicFields_FormSubmissions_FormSubmissionId",
                        column: x => x.FormSubmissionId,
                        principalTable: "FormSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFields_FormSubmissionId",
                table: "DynamicFields",
                column: "FormSubmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicFields");

            migrationBuilder.AddColumn<string>(
                name: "DynamicFields",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);
        }
    }
}

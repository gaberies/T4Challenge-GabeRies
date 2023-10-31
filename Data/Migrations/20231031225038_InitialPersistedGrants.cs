using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace T4Challenge.Data.Migrations
{
    public partial class InitialPersistedGrants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceCodes",
                table: "DeviceCodes");

            migrationBuilder.DropIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes");

            migrationBuilder.DropIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes");

            migrationBuilder.RenameTable(
                name: "DeviceCodes",
                newName: "DeviceFlowCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PersistedGrants",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "PersistedGrants",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50000);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "PersistedGrants",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "DynamicFields",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration",
                table: "DeviceFlowCodes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceCode",
                table: "DeviceFlowCodes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "DeviceFlowCodes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50000);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "DeviceFlowCodes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceFlowCodes",
                table: "DeviceFlowCodes",
                column: "UserCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceFlowCodes",
                table: "DeviceFlowCodes");

            migrationBuilder.DropColumn(
                name: "DynamicFields",
                table: "FormSubmissions");

            migrationBuilder.RenameTable(
                name: "DeviceFlowCodes",
                newName: "DeviceCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PersistedGrants",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "PersistedGrants",
                type: "TEXT",
                maxLength: 50000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "PersistedGrants",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration",
                table: "DeviceCodes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceCode",
                table: "DeviceCodes",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "DeviceCodes",
                type: "TEXT",
                maxLength: 50000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "DeviceCodes",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceCodes",
                table: "DeviceCodes",
                column: "UserCode");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardValidation.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "expiryDate",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "id",
                keyValue: 1,
                column: "expiryDate",
                value: "102004");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "id",
                keyValue: 2,
                column: "expiryDate",
                value: "102004");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "id",
                keyValue: 3,
                column: "expiryDate",
                value: "102004");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "id",
                keyValue: 4,
                column: "expiryDate",
                value: "102004");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "expiryDate",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "id",
                keyValue: 1,
                column: "expiryDate",
                value: new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "id",
                keyValue: 2,
                column: "expiryDate",
                value: new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "id",
                keyValue: 3,
                column: "expiryDate",
                value: new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "id",
                keyValue: 4,
                column: "expiryDate",
                value: new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardValidation.Migrations
{
    public partial class CreateCardValidationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cardNumber = table.Column<string>(nullable: true),
                    expiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "id", "cardNumber", "expiryDate" },
                values: new object[,]
                {
                    { 1, "4000000000000000", new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "5000000000000000", new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "35000000000000000", new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "4000000000000000", new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}

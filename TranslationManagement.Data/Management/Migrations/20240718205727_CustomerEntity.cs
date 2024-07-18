using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationManagement.Data.Management.Migrations
{
    public partial class CustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRecord", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_CustomerId",
                table: "Translations",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_CustomerRecord_CustomerId",
                table: "Translations",
                column: "CustomerId",
                principalTable: "CustomerRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_CustomerRecord_CustomerId",
                table: "Translations");

            migrationBuilder.DropTable(
                name: "CustomerRecord");

            migrationBuilder.DropIndex(
                name: "IX_Translations_CustomerId",
                table: "Translations");
        }
    }
}

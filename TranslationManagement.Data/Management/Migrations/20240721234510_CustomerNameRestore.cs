using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationManagement.Data.Management.Migrations
{
    public partial class CustomerNameRestore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Customers_CustomerId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_CustomerId",
                table: "Translations");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Translations",
                newName: "CustomerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Translations",
                newName: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_CustomerId",
                table: "Translations",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Customers_CustomerId",
                table: "Translations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

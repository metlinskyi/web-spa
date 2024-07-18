using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationManagement.Data.Management.Migrations
{
    public partial class FixNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_CustomerRecord_CustomerId",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceRecord",
                table: "PriceRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerRecord",
                table: "CustomerRecord");

            migrationBuilder.RenameTable(
                name: "PriceRecord",
                newName: "Prices");

            migrationBuilder.RenameTable(
                name: "CustomerRecord",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Customers_CustomerId",
                table: "Translations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Customers_CustomerId",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "PriceRecord");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CustomerRecord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceRecord",
                table: "PriceRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerRecord",
                table: "CustomerRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_CustomerRecord_CustomerId",
                table: "Translations",
                column: "CustomerId",
                principalTable: "CustomerRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

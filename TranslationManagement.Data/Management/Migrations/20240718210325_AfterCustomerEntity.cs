using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationManagement.Data.Management.Migrations
{
    public partial class AfterCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "PriceRecord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceRecord",
                table: "PriceRecord",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceRecord",
                table: "PriceRecord");

            migrationBuilder.RenameTable(
                name: "PriceRecord",
                newName: "Prices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "Id");
        }
    }
}

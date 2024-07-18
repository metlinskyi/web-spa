using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationManagement.Data.Management.Migrations
{
    public partial class PriceValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var price = new PriceRecord(Guid.NewGuid(), Payments.PriceType.PerCharacter, 0.04m);
            migrationBuilder.InsertData(
                    table: "Prices",
                    columns: new[] { "Id", "Type", "Amount" },
                    values: new object[,]
                    {
                        { price.Id, (int)price.Type, price.Amount }
                    });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

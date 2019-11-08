using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class InitialCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Name" },
                values: new object[] { 1, "ZAR" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Name" },
                values: new object[] { 2, "USD" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Name" },
                values: new object[] { 3, "GBP" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}

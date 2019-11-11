using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class TransactionMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Merchant",
                table: "Merchant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("9d78f579-19a5-4792-961d-11d05df89e05"));

            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("c6b8e52c-d8aa-48d6-b03e-07fdfb405255"));

            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("d1d06695-c933-4f89-b780-c42af2d620b2"));

            migrationBuilder.RenameTable(
                name: "Merchant",
                newName: "Merchants");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Merchants",
                table: "Merchants",
                column: "MerchantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false),
                    CardID = table.Column<int>(nullable: false),
                    BankReferenceID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_CardDetails_CardID",
                        column: x => x.CardID,
                        principalTable: "CardDetails",
                        principalColumn: "CardDetailsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("aeb1b512-f858-4434-89a3-1ef7e61e143e"), true, "Testing Description 1", "Test Merchant 1" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("456a1557-3ba6-4361-af4e-1324e8eca181"), true, "Testing Description 2", "Test Merchant 2" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("65a28ed4-8006-47ca-a936-a7777506ce78"), true, "Testing Description 3", "Test Merchant 3" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CardID",
                table: "Transactions",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyID",
                table: "Transactions",
                column: "CurrencyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Merchants",
                table: "Merchants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("456a1557-3ba6-4361-af4e-1324e8eca181"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("65a28ed4-8006-47ca-a936-a7777506ce78"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("aeb1b512-f858-4434-89a3-1ef7e61e143e"));

            migrationBuilder.RenameTable(
                name: "Merchants",
                newName: "Merchant");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Merchant",
                table: "Merchant",
                column: "MerchantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "CurrencyId");

            migrationBuilder.InsertData(
                table: "Merchant",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("c6b8e52c-d8aa-48d6-b03e-07fdfb405255"), true, "Testing Description 1", "Test Merchant 1" });

            migrationBuilder.InsertData(
                table: "Merchant",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("9d78f579-19a5-4792-961d-11d05df89e05"), true, "Testing Description 2", "Test Merchant 2" });

            migrationBuilder.InsertData(
                table: "Merchant",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("d1d06695-c933-4f89-b780-c42af2d620b2"), true, "Testing Description 3", "Test Merchant 3" });
        }
    }
}

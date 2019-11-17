using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class BankMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("1d620903-d485-4421-958f-8265c0b41844"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("311bfb23-11f9-44da-b3f9-ef53da3e6753"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("5d161a26-91a4-4784-8def-faf0a3f9e8b7"));

            migrationBuilder.AddColumn<int>(
                name: "BankID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankName = table.Column<string>(nullable: true),
                    BankURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankID);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankID", "BankName", "BankURL" },
                values: new object[,]
                {
                    { 1, "MockBank", "https://checkoutmockbank.azurewebsites.net/" },
                    { 2, "LocalTestBank", "http://localhost:62268/" }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a9b05e16-acd8-4acf-8e29-951e0d39da9a"), true, "Testing Description 1", "Test Merchant 1" },
                    { new Guid("b3e7c684-99a2-4253-898b-01515b92f1b1"), true, "Testing Description 2", "Test Merchant 2" },
                    { new Guid("e7039e52-410b-4a4a-8516-b15d64880734"), true, "Testing Description 3", "Test Merchant 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankID",
                table: "Transactions",
                column: "BankID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Banks_BankID",
                table: "Transactions",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "BankID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Banks_BankID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BankID",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("a9b05e16-acd8-4acf-8e29-951e0d39da9a"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("b3e7c684-99a2-4253-898b-01515b92f1b1"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("e7039e52-410b-4a4a-8516-b15d64880734"));

            migrationBuilder.DropColumn(
                name: "BankID",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("1d620903-d485-4421-958f-8265c0b41844"), true, "Testing Description 1", "Test Merchant 1" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("311bfb23-11f9-44da-b3f9-ef53da3e6753"), true, "Testing Description 2", "Test Merchant 2" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("5d161a26-91a4-4784-8def-faf0a3f9e8b7"), true, "Testing Description 3", "Test Merchant 3" });
        }
    }
}

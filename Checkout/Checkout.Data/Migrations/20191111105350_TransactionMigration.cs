using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class TransactionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("59692633-f0db-445e-8b56-f926adcacf3e"));

            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("78aa88e6-13cc-44d8-8b8f-e080d3b641b0"));

            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("92ccab88-0609-4032-958b-d0f8b20df414"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Merchant",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("78aa88e6-13cc-44d8-8b8f-e080d3b641b0"), true, "Testing Description 1", "Test Merchant 1" });

            migrationBuilder.InsertData(
                table: "Merchant",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("59692633-f0db-445e-8b56-f926adcacf3e"), true, "Testing Description 2", "Test Merchant 2" });

            migrationBuilder.InsertData(
                table: "Merchant",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("92ccab88-0609-4032-958b-d0f8b20df414"), true, "Testing Description 3", "Test Merchant 3" });
        }
    }
}

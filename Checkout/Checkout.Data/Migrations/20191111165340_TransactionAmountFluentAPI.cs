using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class TransactionAmountFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("18d94a7f-1770-4ddf-9e1d-bf37495054b9"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("352489dd-c5b9-483b-a436-8f47a902daa1"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("e31f32a6-e078-41e3-8b4f-e936788eade0"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(int));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("352489dd-c5b9-483b-a436-8f47a902daa1"), true, "Testing Description 1", "Test Merchant 1" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("e31f32a6-e078-41e3-8b4f-e936788eade0"), true, "Testing Description 2", "Test Merchant 2" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("18d94a7f-1770-4ddf-9e1d-bf37495054b9"), true, "Testing Description 3", "Test Merchant 3" });
        }
    }
}

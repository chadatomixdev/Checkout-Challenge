using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class TransactionMaxLengthStatusAndKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("467e46fb-d389-4d6e-a689-fc41d4f3fc45"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("56e889d8-e8de-4bbe-85aa-bae7e959e21f"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "MerchantID",
                keyValue: new Guid("f16b33c1-055e-44c9-b574-ef329648a654"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transactions",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubStatus",
                table: "Transactions",
                maxLength: 100,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SubStatus",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("f16b33c1-055e-44c9-b574-ef329648a654"), true, "Testing Description 1", "Test Merchant 1" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("467e46fb-d389-4d6e-a689-fc41d4f3fc45"), true, "Testing Description 2", "Test Merchant 2" });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("56e889d8-e8de-4bbe-85aa-bae7e959e21f"), true, "Testing Description 3", "Test Merchant 3" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class TransactionMerchant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "MerchantID",
                table: "Transactions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MerchantID",
                table: "Transactions",
                column: "MerchantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Merchants_MerchantID",
                table: "Transactions",
                column: "MerchantID",
                principalTable: "Merchants",
                principalColumn: "MerchantID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Merchants_MerchantID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_MerchantID",
                table: "Transactions");

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

            migrationBuilder.DropColumn(
                name: "MerchantID",
                table: "Transactions");

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
        }
    }
}

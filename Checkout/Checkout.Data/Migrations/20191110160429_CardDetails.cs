using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class CardDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("4cf74069-e3ad-441e-a281-f7ba649907a2"));

            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("63f9a6a0-c2db-457d-a814-cf48dfe45774"));

            migrationBuilder.DeleteData(
                table: "Merchant",
                keyColumn: "MerchantID",
                keyValue: new Guid("72fc3389-b745-485b-8d34-903fb130004e"));

            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    CardDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<string>(nullable: true),
                    Cvv = table.Column<string>(nullable: true),
                    HolderName = table.Column<string>(nullable: true),
                    ExpiryMonth = table.Column<string>(nullable: true),
                    ExpiryYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.CardDetailsID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDetails");

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
                values: new object[] { new Guid("4cf74069-e3ad-441e-a281-f7ba649907a2"), true, "Testing Description 1", "Test Merchant 1" });

            migrationBuilder.InsertData(
                table: "Merchant",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("63f9a6a0-c2db-457d-a814-cf48dfe45774"), true, "Testing Description 2", "Test Merchant 2" });

            migrationBuilder.InsertData(
                table: "Merchant",
                columns: new[] { "MerchantID", "Active", "Description", "Name" },
                values: new object[] { new Guid("72fc3389-b745-485b-8d34-903fb130004e"), true, "Testing Description 3", "Test Merchant 3" });
        }
    }
}

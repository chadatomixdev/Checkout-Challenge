using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Data.Migrations
{
    public partial class Merchants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchant",
                columns: table => new
                {
                    MerchantID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchant", x => x.MerchantID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchant");
        }
    }
}

﻿// <auto-generated />
using System;
using Checkout.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Checkout.Data.Migrations
{
    [DbContext(typeof(CheckoutDBContext))]
    [Migration("20191108213446_Merchants")]
    partial class Merchants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Checkout.Data.Model.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currency");

                    b.HasData(
                        new
                        {
                            CurrencyId = 1,
                            Name = "ZAR"
                        },
                        new
                        {
                            CurrencyId = 2,
                            Name = "USD"
                        },
                        new
                        {
                            CurrencyId = 3,
                            Name = "GBP"
                        });
                });

            modelBuilder.Entity("Checkout.Data.Model.Merchant", b =>
                {
                    b.Property<Guid>("MerchantID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("MerchantID");

                    b.ToTable("Merchant");

                    b.HasData(
                        new
                        {
                            MerchantID = new Guid("4cf74069-e3ad-441e-a281-f7ba649907a2"),
                            Active = true,
                            Description = "Testing Description 1",
                            Name = "Test Merchant 1"
                        },
                        new
                        {
                            MerchantID = new Guid("63f9a6a0-c2db-457d-a814-cf48dfe45774"),
                            Active = true,
                            Description = "Testing Description 2",
                            Name = "Test Merchant 2"
                        },
                        new
                        {
                            MerchantID = new Guid("72fc3389-b745-485b-8d34-903fb130004e"),
                            Active = true,
                            Description = "Testing Description 3",
                            Name = "Test Merchant 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

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
    [Migration("20191111105350_TransactionMigration")]
    partial class TransactionMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Checkout.Data.Model.CardDetails", b =>
                {
                    b.Property<int>("CardDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardNumber");

                    b.Property<string>("Cvv");

                    b.Property<string>("ExpiryMonth");

                    b.Property<string>("ExpiryYear");

                    b.Property<string>("HolderName");

                    b.HasKey("CardDetailsID");

                    b.ToTable("CardDetails");
                });

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
                            MerchantID = new Guid("c6b8e52c-d8aa-48d6-b03e-07fdfb405255"),
                            Active = true,
                            Description = "Testing Description 1",
                            Name = "Test Merchant 1"
                        },
                        new
                        {
                            MerchantID = new Guid("9d78f579-19a5-4792-961d-11d05df89e05"),
                            Active = true,
                            Description = "Testing Description 2",
                            Name = "Test Merchant 2"
                        },
                        new
                        {
                            MerchantID = new Guid("d1d06695-c933-4f89-b780-c42af2d620b2"),
                            Active = true,
                            Description = "Testing Description 3",
                            Name = "Test Merchant 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

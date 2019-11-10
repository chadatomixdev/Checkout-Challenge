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
    [Migration("20191110160429_CardDetails")]
    partial class CardDetails
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
                            MerchantID = new Guid("78aa88e6-13cc-44d8-8b8f-e080d3b641b0"),
                            Active = true,
                            Description = "Testing Description 1",
                            Name = "Test Merchant 1"
                        },
                        new
                        {
                            MerchantID = new Guid("59692633-f0db-445e-8b56-f926adcacf3e"),
                            Active = true,
                            Description = "Testing Description 2",
                            Name = "Test Merchant 2"
                        },
                        new
                        {
                            MerchantID = new Guid("92ccab88-0609-4032-958b-d0f8b20df414"),
                            Active = true,
                            Description = "Testing Description 3",
                            Name = "Test Merchant 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.eShopOnContainers.Services.Ordering.SqlData.UnitOfWork;

namespace Ordering.API.Migrations
{
    [DbContext(typeof(OrderingDbContext))]
    [Migration("20160909233852_Migration3")]
    partial class Migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("CountryCode");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("State");

                    b.Property<string>("StateCode");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BillingAddressId");

                    b.Property<Guid>("BuyerId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<Guid?>("ShippingAddressId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("BillingAddressId");

                    b.HasIndex("ShippingAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.Order", b =>
                {
                    b.HasOne("Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressId");

                    b.HasOne("Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.Address", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId");
                });
        }
    }
}
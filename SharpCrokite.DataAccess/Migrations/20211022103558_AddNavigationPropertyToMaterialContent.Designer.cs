﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharpCrokite.DataAccess.DatabaseContexts;

namespace SharpCrokite.DataAccess.Migrations
{
    [DbContext(typeof(SharpCrokiteDbContext))]
    [Migration("20211022103558_AddNavigationPropertyToMaterialContent")]
    partial class AddNavigationPropertyToMaterialContent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("SharpCrokite.DataAccess.Models.Harvestable", b =>
                {
                    b.Property<int>("HarvestableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Icon")
                        .HasColumnType("BLOB");

                    b.Property<int?>("IsCompressedVariantOfType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("HarvestableId");

                    b.ToTable("Harvestables");
                });

            modelBuilder.Entity("SharpCrokite.DataAccess.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Icon")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("SharpCrokite.DataAccess.Models.MaterialContent", b =>
                {
                    b.Property<int>("MaterialContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HarvestableId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaterialContentId");

                    b.HasIndex("HarvestableId");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialContents");
                });

            modelBuilder.Entity("SharpCrokite.DataAccess.Models.Price", b =>
                {
                    b.Property<int>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("BuyMax")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("BuyMin")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("BuyPercentile")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HarvestableId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("SellMax")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SellMin")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SellPercentile")
                        .HasColumnType("TEXT");

                    b.Property<int>("SystemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PriceId");

                    b.HasIndex("HarvestableId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("SharpCrokite.DataAccess.Models.MaterialContent", b =>
                {
                    b.HasOne("SharpCrokite.DataAccess.Models.Harvestable", "Harvestable")
                        .WithMany("MaterialContents")
                        .HasForeignKey("HarvestableId");

                    b.HasOne("SharpCrokite.DataAccess.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.Navigation("Harvestable");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("SharpCrokite.DataAccess.Models.Price", b =>
                {
                    b.HasOne("SharpCrokite.DataAccess.Models.Harvestable", "Harvestable")
                        .WithMany("Prices")
                        .HasForeignKey("HarvestableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SharpCrokite.DataAccess.Models.Material", "Material")
                        .WithMany("Prices")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Harvestable");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("SharpCrokite.DataAccess.Models.Harvestable", b =>
                {
                    b.Navigation("MaterialContents");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("SharpCrokite.DataAccess.Models.Material", b =>
                {
                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}

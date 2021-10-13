﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SharpCrokite.DataAccess.DatabaseContexts;

namespace SharpCrokite.DataAccess.Migrations
{
    [DbContext(typeof(SharpCrokiteDbContext))]
    [Migration("20211008171137_AddIcons")]
    partial class AddIcons
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("MyEveToolset.Data.Models.Harvestable", b =>
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

            modelBuilder.Entity("MyEveToolset.Data.Models.Material", b =>
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

            modelBuilder.Entity("MyEveToolset.Data.Models.MaterialContent", b =>
                {
                    b.Property<int>("MaterialContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HarvestableId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaterialId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaterialContentId");

                    b.HasIndex("HarvestableId");

                    b.ToTable("MaterialContents");
                });

            modelBuilder.Entity("MyEveToolset.Data.Models.Price", b =>
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

            modelBuilder.Entity("MyEveToolset.Data.Models.MaterialContent", b =>
                {
                    b.HasOne("MyEveToolset.Data.Models.Harvestable", null)
                        .WithMany("MaterialContents")
                        .HasForeignKey("HarvestableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyEveToolset.Data.Models.Price", b =>
                {
                    b.HasOne("MyEveToolset.Data.Models.Harvestable", "Harvestable")
                        .WithMany("Prices")
                        .HasForeignKey("HarvestableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyEveToolset.Data.Models.Material", "Material")
                        .WithMany("Prices")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Harvestable");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("MyEveToolset.Data.Models.Harvestable", b =>
                {
                    b.Navigation("MaterialContents");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("MyEveToolset.Data.Models.Material", b =>
                {
                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}

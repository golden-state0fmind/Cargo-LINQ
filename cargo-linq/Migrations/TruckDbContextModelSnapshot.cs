﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cargolinq.Data;

#nullable disable

namespace cargo_linq.Migrations
{
    [DbContext(typeof(TruckDbContext))]
    partial class TruckDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("cargolinq.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SupplierEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("cargolinq.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TruckMileage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TruckModel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Truck");
                });

            modelBuilder.Entity("cargolinq.Models.TruckParts", b =>
                {
                    b.Property<int>("TruckPartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PartPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("PartQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TruckPartId");

                    b.HasIndex("SupplierId");

                    b.ToTable("TruckParts");
                });

            modelBuilder.Entity("cargolinq.Models.TruckParts", b =>
                {
                    b.HasOne("cargolinq.Models.Supplier", "Supplier")
                        .WithMany("SuppliedParts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("cargolinq.Models.Supplier", b =>
                {
                    b.Navigation("SuppliedParts");
                });
#pragma warning restore 612, 618
        }
    }
}

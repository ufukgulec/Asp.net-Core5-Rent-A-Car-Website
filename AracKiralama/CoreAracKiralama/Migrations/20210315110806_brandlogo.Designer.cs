﻿// <auto-generated />
using System;
using CoreAracKiralama.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreAracKiralama.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210315110806_brandlogo")]
    partial class brandlogo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreAracKiralama.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminRole")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("CoreAracKiralama.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandLogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BrandStatus")
                        .HasColumnType("bit");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CoreAracKiralama.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CompanyStatus")
                        .HasColumnType("bit");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CoreAracKiralama.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleFuelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleGearType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VehicleInspectionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehiclePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VehiclePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("VehicleStatus")
                        .HasColumnType("bit");

                    b.Property<string>("VehicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CoreAracKiralama.Models.Vehicle", b =>
                {
                    b.HasOne("CoreAracKiralama.Models.Brand", "Brand")
                        .WithMany("Vehicles")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreAracKiralama.Models.Company", "Company")
                        .WithMany("Vehicles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CoreAracKiralama.Models.Brand", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("CoreAracKiralama.Models.Company", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}

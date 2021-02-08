﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentNow.Infrastructure.Context;

namespace RentNow.Infrastructure.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("RentNow.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("KEY");

                    b.HasKey("Key");

                    b.ToTable("CAR_BRAND");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.CarModel", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("KEY");

                    b.Property<Guid?>("CAR_BRAND_KEY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Key");

                    b.HasIndex("CAR_BRAND_KEY");

                    b.ToTable("CAR_MODEL");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("KEY");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BIRTHDATE");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ROLE");

                    b.HasKey("Key");

                    b.ToTable("CLIENT");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Credentials", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("KEY");

                    b.Property<string>("Login")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("LOGIN");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("PASSWORD");

                    b.HasKey("Key");

                    b.ToTable("CREDENTIALS");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Operator", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("KEY");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ROLE");

                    b.HasKey("Key");

                    b.ToTable("OPERATOR");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Scheduling", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("KEY");

                    b.Property<Guid?>("CLIENTEKEY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VEHICLEKEY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Key");

                    b.HasIndex("CLIENTEKEY");

                    b.HasIndex("VEHICLEKEY");

                    b.ToTable("SCHEDULING");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("KEY");

                    b.Property<Guid?>("CAR_MODEL_KEY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int")
                        .HasColumnName("CATEGORY");

                    b.Property<int>("Fuel")
                        .HasColumnType("int")
                        .HasColumnName("FUEL");

                    b.HasKey("Key");

                    b.HasIndex("CAR_MODEL_KEY");

                    b.ToTable("VEHICLE");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Brand", b =>
                {
                    b.OwnsOne("RentNow.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("BrandKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("name")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("NAME");

                            b1.HasKey("BrandKey");

                            b1.ToTable("CAR_BRAND");

                            b1.WithOwner()
                                .HasForeignKey("BrandKey");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.CarModel", b =>
                {
                    b.HasOne("RentNow.Domain.Entities.Brand", "CarBrand")
                        .WithMany()
                        .HasForeignKey("CAR_BRAND_KEY");

                    b.OwnsOne("RentNow.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CarModelKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("name")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("NAME");

                            b1.HasKey("CarModelKey");

                            b1.ToTable("CAR_MODEL");

                            b1.WithOwner()
                                .HasForeignKey("CarModelKey");
                        });

                    b.Navigation("CarBrand");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Client", b =>
                {
                    b.HasOne("RentNow.Domain.Entities.Credentials", "Credentials")
                        .WithOne()
                        .HasForeignKey("RentNow.Domain.Entities.Client", "Key")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RentNow.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<string>("Street")
                                .HasColumnType("varchar(200)")
                                .HasColumnName("STREET");

                            b1.Property<string>("Postcode")
                                .HasColumnType("varchar(10)")
                                .HasColumnName("POSTCODE");

                            b1.Property<string>("Number")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("NUMBER");

                            b1.Property<string>("City")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("CITY");

                            b1.Property<string>("State")
                                .HasColumnType("varchar(20)")
                                .HasColumnName("STATE");

                            b1.Property<Guid>("ClientKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Complement")
                                .HasColumnType("varchar(300)")
                                .HasColumnName("COMPLEMENT");

                            b1.HasKey("Street", "Postcode", "Number", "City", "State", "ClientKey");

                            b1.HasIndex("ClientKey")
                                .IsUnique();

                            b1.ToTable("ADDRESS");

                            b1.WithOwner()
                                .HasForeignKey("ClientKey");
                        });

                    b.OwnsOne("RentNow.Domain.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("ClientKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("cpf")
                                .HasColumnType("varchar(11)")
                                .HasColumnName("CPF");

                            b1.HasKey("ClientKey");

                            b1.ToTable("CLIENT");

                            b1.WithOwner()
                                .HasForeignKey("ClientKey");
                        });

                    b.OwnsOne("RentNow.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("ClientKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("name")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("NAME");

                            b1.HasKey("ClientKey");

                            b1.ToTable("CLIENT");

                            b1.WithOwner()
                                .HasForeignKey("ClientKey");
                        });

                    b.Navigation("Address");

                    b.Navigation("Cpf");

                    b.Navigation("Credentials");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Operator", b =>
                {
                    b.HasOne("RentNow.Domain.Entities.Credentials", "Credentials")
                        .WithOne()
                        .HasForeignKey("RentNow.Domain.Entities.Operator", "Key")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RentNow.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("OperatorKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("name")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("NAME");

                            b1.HasKey("OperatorKey");

                            b1.ToTable("OPERATOR");

                            b1.WithOwner()
                                .HasForeignKey("OperatorKey");
                        });

                    b.OwnsOne("RentNow.Domain.ValueObjects.Registration", "Registration", b1 =>
                        {
                            b1.Property<Guid>("OperatorKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("registration")
                                .HasColumnType("varchar(6)")
                                .HasColumnName("REGISTRATION");

                            b1.HasKey("OperatorKey");

                            b1.ToTable("OPERATOR");

                            b1.WithOwner()
                                .HasForeignKey("OperatorKey");
                        });

                    b.Navigation("Credentials");

                    b.Navigation("Name");

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Scheduling", b =>
                {
                    b.HasOne("RentNow.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("CLIENTEKEY");

                    b.HasOne("RentNow.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VEHICLEKEY");

                    b.OwnsOne("RentNow.Domain.ValueObjects.Hours", "TotalHours", b1 =>
                        {
                            b1.Property<Guid>("SchedulingKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("hours")
                                .HasColumnType("int")
                                .HasColumnName("TOTAL_HOURS");

                            b1.HasKey("SchedulingKey");

                            b1.ToTable("SCHEDULING");

                            b1.WithOwner()
                                .HasForeignKey("SchedulingKey");
                        });

                    b.Navigation("Client");

                    b.Navigation("TotalHours");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("RentNow.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("RentNow.Domain.Entities.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CAR_MODEL_KEY");

                    b.OwnsOne("RentNow.Domain.ValueObjects.HourPrice", "HourPrice", b1 =>
                        {
                            b1.Property<Guid>("VehicleKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("hourPrice")
                                .HasColumnType("money")
                                .HasColumnName("HOUR_PRICE");

                            b1.HasKey("VehicleKey");

                            b1.ToTable("VEHICLE");

                            b1.WithOwner()
                                .HasForeignKey("VehicleKey");
                        });

                    b.OwnsOne("RentNow.Domain.ValueObjects.Plate", "Plate", b1 =>
                        {
                            b1.Property<Guid>("VehicleKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("plate")
                                .HasColumnType("varchar(8)")
                                .HasColumnName("PLATE");

                            b1.HasKey("VehicleKey");

                            b1.ToTable("VEHICLE");

                            b1.WithOwner()
                                .HasForeignKey("VehicleKey");
                        });

                    b.OwnsOne("RentNow.Domain.ValueObjects.TrunkLimit", "TrunkLimit", b1 =>
                        {
                            b1.Property<Guid>("VehicleKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("trunkLimit")
                                .HasColumnType("int")
                                .HasColumnName("TRUNK_LIMIT");

                            b1.HasKey("VehicleKey");

                            b1.ToTable("VEHICLE");

                            b1.WithOwner()
                                .HasForeignKey("VehicleKey");
                        });

                    b.OwnsOne("RentNow.Domain.ValueObjects.Year", "Year", b1 =>
                        {
                            b1.Property<Guid>("VehicleKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("year")
                                .HasColumnType("int")
                                .HasColumnName("YEAR");

                            b1.HasKey("VehicleKey");

                            b1.ToTable("VEHICLE");

                            b1.WithOwner()
                                .HasForeignKey("VehicleKey");
                        });

                    b.Navigation("CarModel");

                    b.Navigation("HourPrice");

                    b.Navigation("Plate");

                    b.Navigation("TrunkLimit");

                    b.Navigation("Year");
                });
#pragma warning restore 612, 618
        }
    }
}

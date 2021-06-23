﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CabBookingAppDbContext))]
    partial class CapBookingAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasMaxLength(128)
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FromPlace")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickUpAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ToPlace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FromPlace");

                    b.HasIndex("ToPlace");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ApplicationCore.Entities.CabType", b =>
                {
                    b.Property<int>("CabTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CabTypeName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CabTypeId");

                    b.ToTable("CabTypes");
                });

            modelBuilder.Entity("ApplicationCore.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasMaxLength(128)
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FPlacePlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("FromPlace")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickUpAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TPlacePlaceId")
                        .HasColumnType("int");

                    b.Property<int>("ToPlace")
                        .HasColumnType("int");

                    b.Property<decimal>("charge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("comp_time")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FPlacePlaceId");

                    b.HasIndex("TPlacePlaceId");

                    b.ToTable("Bookings history");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlaceName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Booking", b =>
                {
                    b.HasOne("ApplicationCore.Entities.CabType", "CabType")
                        .WithMany("Bookings")
                        .HasForeignKey("CabTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Place", "FPlace")
                        .WithMany("FBookings")
                        .HasForeignKey("FromPlace")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Place", "TPlace")
                        .WithMany("TBookings")
                        .HasForeignKey("ToPlace")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CabType");

                    b.Navigation("FPlace");

                    b.Navigation("TPlace");
                });

            modelBuilder.Entity("ApplicationCore.Entities.History", b =>
                {
                    b.HasOne("ApplicationCore.Entities.CabType", "CabType")
                        .WithMany("Histories")
                        .HasForeignKey("CabTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Place", "FPlace")
                        .WithMany()
                        .HasForeignKey("FPlacePlaceId");

                    b.HasOne("ApplicationCore.Entities.Place", "TPlace")
                        .WithMany()
                        .HasForeignKey("TPlacePlaceId");

                    b.Navigation("CabType");

                    b.Navigation("FPlace");

                    b.Navigation("TPlace");
                });

            modelBuilder.Entity("ApplicationCore.Entities.CabType", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Histories");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Place", b =>
                {
                    b.Navigation("FBookings");

                    b.Navigation("TBookings");
                });
#pragma warning restore 612, 618
        }
    }
}

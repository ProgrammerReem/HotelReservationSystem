﻿// <auto-generated />
using System;
using HotelReservationSystem.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace HotelReservationSystem.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelReservationSystem.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("CardId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Cvv")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("bankAccounts");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("contactUs");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Desc")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Imagepath")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Loc")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Rating")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.PageContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AboutUs")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ConactUs")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ConactUsPath")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("pageContent");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("RoomId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("UserID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserID");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("RoomId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UserID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserID");

                    b.ToTable("residents");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Room", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("HotelId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("PriceByNight")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("roomNumber")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id");

                    b.HasIndex("HotelId");

                    b.ToTable("room");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Testimonial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int?>("HotelId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("roomId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("userId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("roomId");

                    b.HasIndex("userId");

                    b.ToTable("testimonials");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardCvv")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("CardId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("balance")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("phone")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.UserTransactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("RoomId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UserID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserID");

                    b.ToTable("userTransactions");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.BankAccount", b =>
                {
                    b.HasOne("HotelReservationSystem.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Reservation", b =>
                {
                    b.HasOne("HotelReservationSystem.Models.Room", "room")
                        .WithMany("reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystem.Models.User", "user")
                        .WithMany("reservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");

                    b.Navigation("user");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Resident", b =>
                {
                    b.HasOne("HotelReservationSystem.Models.Room", "room")
                        .WithMany("Residents")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystem.Models.User", "user")
                        .WithMany("Residents")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");

                    b.Navigation("user");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Room", b =>
                {
                    b.HasOne("HotelReservationSystem.Models.Hotel", "hotel")
                        .WithMany("rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotel");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Testimonial", b =>
                {
                    b.HasOne("HotelReservationSystem.Models.Hotel", null)
                        .WithMany("testimonials")
                        .HasForeignKey("HotelId");

                    b.HasOne("HotelReservationSystem.Models.Room", "room")
                        .WithMany("testimonials")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystem.Models.User", "user")
                        .WithMany("testimonials")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");

                    b.Navigation("user");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.UserTransactions", b =>
                {
                    b.HasOne("HotelReservationSystem.Models.Room", "room")
                        .WithMany("userTransactions")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystem.Models.User", "user")
                        .WithMany("userTransactions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");

                    b.Navigation("user");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Hotel", b =>
                {
                    b.Navigation("rooms");

                    b.Navigation("testimonials");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.Room", b =>
                {
                    b.Navigation("Residents");

                    b.Navigation("reservations");

                    b.Navigation("testimonials");

                    b.Navigation("userTransactions");
                });

            modelBuilder.Entity("HotelReservationSystem.Models.User", b =>
                {
                    b.Navigation("Residents");

                    b.Navigation("reservations");

                    b.Navigation("testimonials");

                    b.Navigation("userTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}

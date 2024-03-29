﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231203041550_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccesLayer.Models.BookModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentlyBorrowedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBookAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("LentByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("UserModelId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentlyBorrowedById");

                    b.HasIndex("LentByUserId");

                    b.HasIndex("UserModelId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DataAccesLayer.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokensAvailable")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "edeb3c02-42e3-4cf3-8841-4c15ecf784bc",
                            Name = "Priyesh Zope",
                            Password = "Pzoistbpl@2001",
                            TokensAvailable = 10,
                            Username = "zopepriyesh"
                        },
                        new
                        {
                            Id = "ba74660f-f3c6-4a51-ac1c-567b1e281ee2",
                            Name = "Demo User 1",
                            Password = "Password",
                            TokensAvailable = 10,
                            Username = "Demouser1"
                        },
                        new
                        {
                            Id = "91dc118b-d6ae-492d-a622-791cf2cec142",
                            Name = "Demo User 2",
                            Password = "Password",
                            TokensAvailable = 10,
                            Username = "DemoUser2"
                        },
                        new
                        {
                            Id = "145c4a26-fed6-4ef2-a67e-1fc55433b075",
                            Name = "Demo User 3",
                            Password = "password",
                            TokensAvailable = 10,
                            Username = "DemoUser3"
                        });
                });

            modelBuilder.Entity("DataAccesLayer.Models.BookModel", b =>
                {
                    b.HasOne("DataAccesLayer.Models.UserModel", "CurrentlyBorrowedByUser")
                        .WithMany()
                        .HasForeignKey("CurrentlyBorrowedById")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DataAccesLayer.Models.UserModel", "LentByUser")
                        .WithMany("BooksLent")
                        .HasForeignKey("LentByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccesLayer.Models.UserModel", null)
                        .WithMany("BooksBorrowed")
                        .HasForeignKey("UserModelId");

                    b.Navigation("CurrentlyBorrowedByUser");

                    b.Navigation("LentByUser");
                });

            modelBuilder.Entity("DataAccesLayer.Models.UserModel", b =>
                {
                    b.Navigation("BooksBorrowed");

                    b.Navigation("BooksLent");
                });
#pragma warning restore 612, 618
        }
    }
}

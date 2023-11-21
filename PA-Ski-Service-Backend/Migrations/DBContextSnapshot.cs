﻿
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkiServiceBackend.Models;

#nullable disable

namespace Praxisarbeit.Migrations
{
    [DbContext(typeof(DbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Praxisarbeit.Model.RegistrationModel", b =>
            {
                b.Property<int>("OrderID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                b.Property<DateTime>("CreateDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("PickupDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Priority")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Service")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("OrderID");

                b.ToTable("Registrations");
            });

            modelBuilder.Entity("Praxisarbeit.Model.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Users");

                b.HasData(
                    new
                    {
                        Id = 1,
                        Password = "admin",
                        UserName = "admin"
                    });
            });
#pragma warning restore 612, 618
        }
    }
}

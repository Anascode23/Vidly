﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Vidly.Access.Data;
#nullable disable

namespace Vidly.Migrations
{
    [DbContext(typeof(VidlyDBContext))]
    [Migration("20240322144828_SeededMembershiptypeModel")]
    partial class SeededMembershiptypeModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vidly.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sarah"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jack"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Marry"
                        });
                });

            modelBuilder.Entity("Vidly.Models.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<int>("DurationInMonths")
                        .HasColumnType("int");

                    b.Property<int>("SignUpFee")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            DiscountRate = 0,
                            DurationInMonths = 0,
                            SignUpFee = 0
                        },
                        new
                        {
                            Id = 5,
                            DiscountRate = 10,
                            DurationInMonths = 1,
                            SignUpFee = 30
                        },
                        new
                        {
                            Id = 6,
                            DiscountRate = 15,
                            DurationInMonths = 3,
                            SignUpFee = 90
                        },
                        new
                        {
                            Id = 7,
                            DiscountRate = 20,
                            DurationInMonths = 12,
                            SignUpFee = 300
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

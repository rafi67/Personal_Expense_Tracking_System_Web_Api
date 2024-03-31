﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Personal_Expense_Tracking_System_Web_Api.Data;

#nullable disable

namespace Personal_Expense_Tracking_System_Web_Api.Migrations
{
    [DbContext(typeof(ApplicationDB))]
    [Migration("20240331060139_SeedingAndCreatingCategoriesTable")]
    partial class SeedingAndCreatingCategoriesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Personal_Expense_Tracking_System_Web_Api.Models.Categories", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Salary"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Freelancing"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Invesments"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Stocks"
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Bitcoin"
                        },
                        new
                        {
                            CategoryID = 6,
                            CategoryName = "Bank Transfer"
                        },
                        new
                        {
                            CategoryID = 7,
                            CategoryName = "Youtube"
                        },
                        new
                        {
                            CategoryID = 8,
                            CategoryName = "Other"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

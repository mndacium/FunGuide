﻿// <auto-generated />
using System;
using FunGuide.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FunGuide.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220426175346_SportsmanMigration")]
    partial class SportsmanMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FunGuide.Shared.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Football"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MMA"
                        });
                });

            modelBuilder.Entity("FunGuide.Shared.Sportsman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<string>("Citizenship")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Sportsmen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 22,
                            FirstName = "Vlad",
                            Height = 1.8200000000000001,
                            LastName = "Tanasiichuk",
                            SportId = 1,
                            Weight = 75.799999999999997,
                            Citizenship = "Ukrainian"
                        },
                        new
                        {
                            Id = 2,
                            Age = 21,
                            BirthDate = new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Andrey",
                            Height = 1.8,
                            LastName = "Huila",
                            SportId = 2,
                            Weight = 75.299999999999997,
                            Citizenship = "Ukrainian"
                        });
                });

            modelBuilder.Entity("FunGuide.Shared.Sportsman", b =>
                {
                    b.HasOne("FunGuide.Shared.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });
#pragma warning restore 612, 618
        }
    }
}
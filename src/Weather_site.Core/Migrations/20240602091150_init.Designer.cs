﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather_site.Core.Context;

#nullable disable

namespace Weather_site.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240602091150_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Weather_site.Core.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7067e7c1-f026-48dd-bf5e-c6c6654eb663"),
                            CountryId = new Guid("4510dd92-816f-44d8-a084-e87f4a1aacde"),
                            Name = "Osrtoh"
                        },
                        new
                        {
                            Id = new Guid("749837dd-7765-48ca-8097-406788f6cccf"),
                            CountryId = new Guid("4510dd92-816f-44d8-a084-e87f4a1aacde"),
                            Name = "Rivne"
                        });
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4510dd92-816f-44d8-a084-e87f4a1aacde"),
                            Name = "UA"
                        });
                });

            modelBuilder.Entity("Weather_site.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Weather", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("FeelsLikeT")
                        .HasColumnType("float");

                    b.Property<int>("GrndLevel")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaxT")
                        .HasColumnType("float");

                    b.Property<double>("MinT")
                        .HasColumnType("float");

                    b.Property<int>("Pressure")
                        .HasColumnType("int");

                    b.Property<int>("SeaLevel")
                        .HasColumnType("int");

                    b.Property<double>("Temp")
                        .HasColumnType("float");

                    b.Property<Guid>("WindId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("WindId");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Wind", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Gust")
                        .HasColumnType("float");

                    b.Property<double>("Humidity")
                        .HasColumnType("float");

                    b.Property<double>("Speed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Winds");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.City", b =>
                {
                    b.HasOne("Weather_site.Core.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.User", b =>
                {
                    b.HasOne("Weather_site.Core.Entities.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Weather", b =>
                {
                    b.HasOne("Weather_site.Core.Entities.City", "City")
                        .WithMany("Weathers")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weather_site.Core.Entities.Wind", "Wind")
                        .WithMany("Weathers")
                        .HasForeignKey("WindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Wind");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.City", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("Weathers");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Wind", b =>
                {
                    b.Navigation("Weathers");
                });
#pragma warning restore 612, 618
        }
    }
}

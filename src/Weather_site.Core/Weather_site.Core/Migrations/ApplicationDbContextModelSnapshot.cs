﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather_site.UI.Data;

#nullable disable

namespace Weather_site.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Weather_site.Core.Entities.Clouds", b =>
                {
                    b.Property<int>("all")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("all"));

                    b.HasKey("all");

                    b.ToTable("Clouds");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Coord", b =>
                {
                    b.Property<double>("lon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float");

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.HasKey("lon");

                    b.ToTable("Coords");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Main", b =>
                {
                    b.Property<double>("temp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float");

                    b.Property<double>("feels_like")
                        .HasColumnType("float");

                    b.Property<int>("humidity")
                        .HasColumnType("int");

                    b.Property<int>("pressure")
                        .HasColumnType("int");

                    b.Property<double>("temp_max")
                        .HasColumnType("float");

                    b.Property<int>("temp_min")
                        .HasColumnType("int");

                    b.HasKey("temp");

                    b.ToTable("Mains");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.ResultViewModel", b =>
                {
                    b.Property<string>("City")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Humidity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempFeelsLike")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempMax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempMin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeatherIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("City");

                    b.ToTable("ResultViewModels");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.RootObject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("base")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cloudsall")
                        .HasColumnType("int");

                    b.Property<int>("cod")
                        .HasColumnType("int");

                    b.Property<double>("coordlon")
                        .HasColumnType("float");

                    b.Property<int>("dt")
                        .HasColumnType("int");

                    b.Property<double>("maintemp")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("systype")
                        .HasColumnType("int");

                    b.Property<int>("timezone")
                        .HasColumnType("int");

                    b.Property<int>("visibility")
                        .HasColumnType("int");

                    b.Property<double>("windspeed")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("cloudsall");

                    b.HasIndex("coordlon");

                    b.HasIndex("maintemp");

                    b.HasIndex("systype");

                    b.HasIndex("windspeed");

                    b.ToTable("RootObjects");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Sys", b =>
                {
                    b.Property<int>("type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("type"));

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("sunrise")
                        .HasColumnType("int");

                    b.Property<int>("sunset")
                        .HasColumnType("int");

                    b.HasKey("type");

                    b.ToTable("Sys");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Weather", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("RootObjectid")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("main")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("RootObjectid");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Wind", b =>
                {
                    b.Property<double>("speed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float");

                    b.Property<int>("deg")
                        .HasColumnType("int");

                    b.HasKey("speed");

                    b.ToTable("Winds");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.RootObject", b =>
                {
                    b.HasOne("Weather_site.Core.Entities.Clouds", "clouds")
                        .WithMany()
                        .HasForeignKey("cloudsall")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weather_site.Core.Entities.Coord", "coord")
                        .WithMany()
                        .HasForeignKey("coordlon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weather_site.Core.Entities.Main", "main")
                        .WithMany()
                        .HasForeignKey("maintemp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weather_site.Core.Entities.Sys", "sys")
                        .WithMany()
                        .HasForeignKey("systype")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weather_site.Core.Entities.Wind", "wind")
                        .WithMany()
                        .HasForeignKey("windspeed")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clouds");

                    b.Navigation("coord");

                    b.Navigation("main");

                    b.Navigation("sys");

                    b.Navigation("wind");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.Weather", b =>
                {
                    b.HasOne("Weather_site.Core.Entities.RootObject", null)
                        .WithMany("weather")
                        .HasForeignKey("RootObjectid");
                });

            modelBuilder.Entity("Weather_site.Core.Entities.RootObject", b =>
                {
                    b.Navigation("weather");
                });
#pragma warning restore 612, 618
        }
    }
}

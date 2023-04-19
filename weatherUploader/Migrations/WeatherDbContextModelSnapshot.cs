﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using weatherUploader.Models.Entity;

#nullable disable

namespace weatherUploader.Migrations
{
    [DbContext(typeof(WeatherDbContext))]
    partial class WeatherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("weatherUploader.Models.Entity.WeatherFileInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("hash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WeatherFileInfo");
                });

            modelBuilder.Entity("weatherUploader.Models.Entity.WheatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("FileInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("H")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<double>("Pressure")
                        .HasColumnType("REAL");

                    b.Property<double>("T")
                        .HasColumnType("REAL");

                    b.Property<double>("Td")
                        .HasColumnType("REAL");

                    b.Property<string>("TimeMSC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("VV")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WeatherConditions")
                        .HasColumnType("TEXT");

                    b.Property<string>("WindDirection")
                        .HasColumnType("TEXT");

                    b.Property<double?>("WindSpeed")
                        .HasColumnType("REAL");

                    b.Property<int?>("Сloudiness")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FileInfoId");

                    b.ToTable("WheatherForecast");
                });

            modelBuilder.Entity("weatherUploader.Models.Entity.WheatherForecast", b =>
                {
                    b.HasOne("weatherUploader.Models.Entity.WeatherFileInfo", "FileInfo")
                        .WithMany()
                        .HasForeignKey("FileInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileInfo");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAssessment_Moroz;

#nullable disable

namespace TestAssessment_Moroz.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestAssessment_Moroz.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DOLocationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dropoff_datetime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Fare_amount")
                        .HasColumnType("float");

                    b.Property<int>("PULocationID")
                        .HasColumnType("int");

                    b.Property<int>("Passenger_count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Pickup_datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Store_and_fwd_flag")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<double>("Tip_amount")
                        .HasColumnType("float");

                    b.Property<double>("Trip_distance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PULocationID")
                        .HasDatabaseName("IX_Trips_PULocationID");

                    b.HasIndex("Trip_distance")
                        .HasDatabaseName("IX_Trips_TripDistance");

                    b.HasIndex("Pickup_datetime", "Dropoff_datetime")
                        .HasDatabaseName("IX_Trips_TravelTime");

                    b.ToTable("Models");
                });
#pragma warning restore 612, 618
        }
    }
}

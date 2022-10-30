﻿// <auto-generated />
using System;
using GD.HealthFlip.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GD.HealthFlip.Infrastructure.Migrations
{
    [DbContext(typeof(HealthFlipDbContext))]
    partial class HealthFlipDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GD.HealthFlip.Core.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("LastModifiedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
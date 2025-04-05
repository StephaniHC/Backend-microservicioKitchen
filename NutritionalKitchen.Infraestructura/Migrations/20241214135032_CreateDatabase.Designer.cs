﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutritionalKitchen.Infraestructura.StoredModel;

#nullable disable

namespace NutritionalKitchen.Infraestructura.Migrations
{
    [DbContext(typeof(StoredDbContext))]
    [Migration("20241214135032_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NutritionalKitchen.Infraestructura.StoredModel.Entities.IngredientsStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("ingredients");
                });

            modelBuilder.Entity("NutritionalKitchen.Infraestructura.StoredModel.Entities.KitchenManagerStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("name");

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("shift");

                    b.HasKey("Id");

                    b.ToTable("kitchenManager");
                });

            modelBuilder.Entity("NutritionalKitchen.Infraestructura.StoredModel.Entities.LabelStoredModel", b =>
                {
                    b.Property<Guid>("BatchCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("char(50)")
                        .HasColumnName("batchCode");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("address");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("detail");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("expirationDate");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("char(36)")
                        .HasColumnName("patientId");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("productionDate");

                    b.HasKey("BatchCode");

                    b.ToTable("label");
                });

            modelBuilder.Entity("NutritionalKitchen.Infraestructura.StoredModel.Entities.PackageStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("BatchCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("batchCode");

                    b.Property<Guid>("PreparedRecipeId")
                        .HasColumnType("char(36)")
                        .HasColumnName("preparedRecipeId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("package");
                });

            modelBuilder.Entity("NutritionalKitchen.Infraestructura.StoredModel.Entities.RecipeStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("name");

                    b.Property<string>("PreparationTime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("preparationTime");

                    b.HasKey("Id");

                    b.ToTable("recipe");
                });
#pragma warning restore 612, 618
        }
    }
}

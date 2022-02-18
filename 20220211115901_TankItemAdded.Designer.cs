﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kanusaoft1.Models;

namespace kanusaoft1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220211115901_TankItemAdded")]
    partial class TankItemAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kanusaoft1.Model.location", b =>
                {
                    b.Property<string>("address")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("address");

                    b.ToTable("locations");

                    b.HasData(
                        new
                        {
                            address = "Wsta",
                            name = "Mimar"
                        },
                        new
                        {
                            address = "4rbye",
                            name = "Shamomar"
                        },
                        new
                        {
                            address = "al-whde str",
                            name = "al-slam"
                        });
                });

            modelBuilder.Entity("kanusaoft1.Model.supplement", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("locationaddress")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("name");

                    b.HasIndex("locationaddress");

                    b.ToTable("supplements");

                    b.HasData(
                        new
                        {
                            name = "Water",
                            amount = 30
                        },
                        new
                        {
                            name = "Gazoline",
                            amount = 30
                        },
                        new
                        {
                            name = "Disel",
                            amount = 30
                        });
                });

            modelBuilder.Entity("kanusaoft1.Models.TankItem", b =>
                {
                    b.Property<int>("TankItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("TankId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("supplementname")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TankItemId");

                    b.HasIndex("supplementname");

                    b.ToTable("TankItems");
                });

            modelBuilder.Entity("kanusaoft1.Model.supplement", b =>
                {
                    b.HasOne("kanusaoft1.Model.location", "location")
                        .WithMany("supplement")
                        .HasForeignKey("locationaddress");
                });

            modelBuilder.Entity("kanusaoft1.Models.TankItem", b =>
                {
                    b.HasOne("kanusaoft1.Model.supplement", "supplement")
                        .WithMany()
                        .HasForeignKey("supplementname");
                });
#pragma warning restore 612, 618
        }
    }
}

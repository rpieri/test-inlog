﻿// <auto-generated />
using System;
using InLogTest.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InLogTest.Repository.Migrations
{
    [DbContext(typeof(EntityContext))]
    partial class EntityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InLogTest.Domain.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Chassis")
                        .IsRequired()
                        .HasColumnName("varchar(250)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnName("varchar(50)");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("deleted")
                        .HasDefaultValue(false);

                    b.Property<byte>("NumberOfPassagers")
                        .HasColumnName("numberPassagers");

                    b.Property<int>("Type")
                        .HasColumnName("typeVehicle");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}

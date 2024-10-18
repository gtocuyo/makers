﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrestamosAPI.Infrastructure.Persistence;

#nullable disable

namespace PrestamosAPI.Migrations
{
    [DbContext(typeof(PrestamosDbContext))]
    partial class PrestamosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PrestamosAPI.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PrestamosAPI.Domain.Entities.EstadoPrestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("EstadoPrestamos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Pendiente"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Aprobado"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Rechazado"
                        });
                });

            modelBuilder.Entity("PrestamosAPI.Domain.Entities.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<int>("IdEstadoPrestamo")
                        .HasColumnType("integer");

                    b.Property<double>("Monto")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEstadoPrestamo");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("PrestamosAPI.Domain.Entities.Prestamo", b =>
                {
                    b.HasOne("PrestamosAPI.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PrestamosAPI.Domain.Entities.EstadoPrestamo", "EstadoPrestamo")
                        .WithMany()
                        .HasForeignKey("IdEstadoPrestamo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("EstadoPrestamo");
                });

            modelBuilder.Entity("PrestamosAPI.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
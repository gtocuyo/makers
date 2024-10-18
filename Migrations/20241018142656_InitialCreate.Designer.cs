﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrestamosAPI.Infrastructure.Persistence;

#nullable disable

namespace PrestamosAPI.Migrations
{
    [DbContext(typeof(PrestamosDbContext))]
    [Migration("20241018142656_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

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
                        .HasColumnType("text");

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

                    b.Property<int>("EstadoPrestamoId")
                        .HasColumnType("integer");

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

                    b.HasIndex("EstadoPrestamoId");

                    b.HasIndex("IdCliente");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("PrestamosAPI.Domain.Entities.Prestamo", b =>
                {
                    b.HasOne("PrestamosAPI.Domain.Entities.EstadoPrestamo", "EstadoPrestamo")
                        .WithMany()
                        .HasForeignKey("EstadoPrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrestamosAPI.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
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
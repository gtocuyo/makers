using PrestamosAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PrestamosAPI.Infrastructure.Persistence
{
    public class PrestamosDbContext : DbContext
    {
        public PrestamosDbContext(DbContextOptions<PrestamosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<EstadoPrestamo> EstadoPrestamos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Prestamo
            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Asegura que el campo IdEstadoPrestamo sea obligatorio (NOT NULL)
                entity.Property(e => e.IdEstadoPrestamo)
                      .IsRequired();

                // Relación entre Prestamo y EstadoPrestamo (Foreign Key)
                entity.HasOne(e => e.EstadoPrestamo)
                      .WithMany()
                      .HasForeignKey(e => e.IdEstadoPrestamo)
                      .OnDelete(DeleteBehavior.Restrict); // Evita eliminación en cascada

                // Relación entre Prestamo y Cliente (Foreign Key)
                entity.HasOne(e => e.Cliente)
                      .WithMany(c => c.Prestamos)
                      .HasForeignKey(e => e.IdCliente)
                      .OnDelete(DeleteBehavior.Restrict); // Evita eliminación en cascada
            });

            // Configuración de la entidad EstadoPrestamo
            modelBuilder.Entity<EstadoPrestamo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Descripcion)
                      .HasMaxLength(255)
                      .IsRequired();
                
                // Seed data: Inicializamos estados predefinidos
                entity.HasData(
                    new EstadoPrestamo { Id = 1, Descripcion = "Pendiente" },
                    new EstadoPrestamo { Id = 2, Descripcion = "Aprobado" },
                    new EstadoPrestamo { Id = 3, Descripcion = "Rechazado" }
                );
            });

            // Configuración de la entidad Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                      .HasMaxLength(255)
                      .IsRequired();

                entity.Property(e => e.Apellido)
                      .HasMaxLength(255)
                      .IsRequired();
            });
        }
    }
}
using PrestamosAPI.Application.Interfaces;
using PrestamosAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PrestamosAPI.Infrastructure.Persistence;

namespace PrestamosAPI.Infrastructure.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly PrestamosDbContext _context;

        public PrestamoRepository(PrestamosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prestamo>> GetAllPrestamos() =>
            await _context.Prestamos.Include(p => p.EstadoPrestamo).ToListAsync();

        public async Task<Prestamo> GetPrestamoById(int id) =>
            await _context.Prestamos.FindAsync(id);

        public async Task<IEnumerable<Prestamo>> GetPrestamosByClienteId(int clienteId) =>
            await _context.Prestamos.Where(p => p.IdCliente == clienteId).ToListAsync();

        public async Task AddPrestamo(Prestamo prestamo)
        {
            await _context.Prestamos.AddAsync(prestamo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePrestamo(Prestamo prestamo)
        {
            prestamo.FechaModificacion = DateTime.UtcNow;
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
        }
    }
}

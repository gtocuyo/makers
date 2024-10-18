using PrestamosAPI.Domain.Entities;

namespace PrestamosAPI.Application.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<IEnumerable<Prestamo>> GetAllPrestamos();
        Task<Prestamo> GetPrestamoById(int id);
        Task<IEnumerable<Prestamo>> GetPrestamosByClienteId(int clienteId);
        Task AddPrestamo(Prestamo prestamo);
        Task UpdatePrestamo(Prestamo prestamo);
    }
}
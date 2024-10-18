using PrestamosAPI.Application.Interfaces;
using PrestamosAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PrestamosAPI.Common;

namespace PrestamosAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoRepository _prestamoRepository;

        public PrestamoController(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrestamos()
        {
            var prestamos = await _prestamoRepository.GetAllPrestamos();
            return Ok(prestamos);
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetPrestamosByClienteId(int clienteId)
        {
            var prestamos = await _prestamoRepository.GetPrestamosByClienteId(clienteId);
            return Ok(prestamos);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrestamo([FromBody] Prestamo prestamo)
        {
            // Asignar la fecha actual
            prestamo.FechaIngreso = DateTime.UtcNow;
            prestamo.FechaModificacion = DateTime.UtcNow;
            
            // Asignar el estado 'Pendiente' por defecto
            prestamo.IdEstadoPrestamo = GlobalConstants.EstadoPrestamo.Pendiente;

            await _prestamoRepository.AddPrestamo(prestamo);
            return Ok(prestamo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrestamoEstado(int id, [FromBody]  Prestamo prestamoNuevo)
        {
            var prestamo = await _prestamoRepository.GetPrestamoById(id);
            if (prestamo == null) return NotFound();

            prestamo.IdEstadoPrestamo = prestamoNuevo.IdEstadoPrestamo;
            await _prestamoRepository.UpdatePrestamo(prestamo);

            return Ok(prestamo);
        }
    }
}

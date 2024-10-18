namespace PrestamosAPI.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }

        // Relación con Prestamos
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
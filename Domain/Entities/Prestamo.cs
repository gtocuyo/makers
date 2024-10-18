namespace PrestamosAPI.Domain.Entities
{
    public class Prestamo
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public int IdEstadoPrestamo { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaModificacion { get; set; }

        public EstadoPrestamo? EstadoPrestamo { get; set; }
        public Cliente? Cliente { get; set; }
        
    }
}
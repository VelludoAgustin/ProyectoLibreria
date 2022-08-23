using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoPracticoIndividualProyectoSoftware.CrearTablas
{
    public class Alquileres
    {
        [Key]
        public int Id { get; set; }

        [Column("Cliente")]
        [ForeignKey(nameof(Cliente))]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }


        [Column("ISBN")]
        [ForeignKey(nameof(ISBN))]
        [MaxLength(50, ErrorMessage = "El campo ISBN no puede contener mas de 50 caracteres.")]
        public string ISBNId { get; set; }
        public virtual Libros ISBN { get; set; }


        [Column("Estado")]
        [ForeignKey(nameof(Estado))]
        public int EstadoId { get; set; }
        public virtual EstadoDeAlquileres Estado { get; set; }


        [Display(Name = "FechaAlquiler")]
        public DateTime? FechaAlquiler { get; set; } = null;


        [Display(Name = "FechaReserva")]
        public DateTime? FechaReserva { get; set; } = null;


        [Display(Name = "FechaDevolucion")]
        public DateTime? FechaDevolucion { get; set; } = null;
    }
}

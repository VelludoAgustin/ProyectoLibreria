using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoIndividualProyectoSoftware.CrearTablas
{
    public class EstadoDeAlquileres
    {
        [Key]
        public int EstadoID { get; set; }


        [MaxLength(45, ErrorMessage = "El campo Descripcion no puede contener mas de 45 caracteres.")]
        public string Descripcion { get; set; }


        public ICollection<Alquileres> Alquileres { get; set; }
    }
}

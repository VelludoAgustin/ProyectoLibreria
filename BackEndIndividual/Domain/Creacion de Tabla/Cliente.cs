using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoIndividualProyectoSoftware.CrearTablas
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }


        [MaxLength(10, ErrorMessage = "El campo DNI no puede contener mas de 10 caracteres.")]
        public string DNI { get; set; }


        [MaxLength(45, ErrorMessage = "El campo Nombre no puede contener mas de 45 caracteres.")]
        public string Nombre { get; set; }


        [MaxLength(45, ErrorMessage = "El campo Apellido no puede contener mas de 45 caracteres.")]
        public string Apellido { get; set; }


        [MaxLength(45, ErrorMessage = "El campo Email no puede contener mas de 45 caracteres.")]
        public string Email { get; set; }


        public ICollection<Alquileres> Alquileres { get; set; }
    }
}

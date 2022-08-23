using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoIndividualProyectoSoftware.CrearTablas
{
    public class Libros
    {
        [Key]
        [MaxLength(50, ErrorMessage = "El campo ISBN no puede contener mas de 50 caracteres.")]
        public string ISBN { get; set; }


        [MaxLength(45, ErrorMessage = "El campo Titulo no puede contener mas de 45 caracteres.")]
        public string Titulo { get; set; }


        [MaxLength(45, ErrorMessage = "El campo Autor no puede contener mas de 45 caracteres.")]
        public string Autor { get; set; }


        [MaxLength(45, ErrorMessage = "El campo Editorial no puede contener mas de 45 caracteres.")]
        public string Editorial { get; set; }


        [MaxLength(45, ErrorMessage = "El campo Edicion no puede contener mas de 45 caracteres.")]
        public string Edicion { get; set; }


        public int? Stock { get; set; }


        [MaxLength(100, ErrorMessage = "El campo Imagen no puede contener mas de 100 caracteres.")]
        public string Imagen { get; set; }


        public ICollection<Alquileres> Alquileres { get; set; }
    }
}

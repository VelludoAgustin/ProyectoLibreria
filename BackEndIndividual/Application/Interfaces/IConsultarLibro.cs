using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Application.Interfaces
{
    public interface IConsultarLibro
    {
        public Libros BuscarLibroConISBN(string isbn);
        public Libros BuscarLibroConTitulo(string titulo);
        public List<Libros> TodosLosLibros();
    }
}

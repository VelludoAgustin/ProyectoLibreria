using Application.Interfaces;
using ProyectoSoftwareIndividual.Contexto;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Data.Consultas
{
    public class ConsultaDeLibros : IConsultarLibro
    {
        private readonly ProyectoSoftwareLibreriaContext context;
        public ConsultaDeLibros(ProyectoSoftwareLibreriaContext cont)
        {
            context = cont;
        }
        public Libros BuscarLibroConISBN(string isbn)
        {
            return context.Libros.Where(s => s.ISBN == isbn).FirstOrDefault();
        }
        public Libros BuscarLibroConTitulo(string titulo)
        {
            return context.Libros.Where(s => s.Titulo == titulo).FirstOrDefault();
        }
        public List<Libros> TodosLosLibros()
        {
            return context.Libros.ToList();
        }
    }
}

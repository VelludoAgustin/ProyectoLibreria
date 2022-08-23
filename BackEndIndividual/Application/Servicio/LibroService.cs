using Application.ClasesDeMensajes;
using Application.Interfaces;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Application.Servicio
{
    public class LibroService : ILibroService
    {
        private readonly IConsultarLibro consultarLibro;
        public LibroService(IConsultarLibro com)
        {
            consultarLibro = com;
        }
        public Respuesta BuscarStock(string isbn, int stock)
        {
            var libro = consultarLibro.BuscarLibroConISBN(isbn);
            if (libro == null)
                return new Respuesta(false, "");
            if (libro.Stock < stock)
                return new Respuesta(false, "");
            return new Respuesta(true, "");
        }
        public List<DevolverLibrosFiltros> FiltrarLibros(bool stock, string? titulo, string? autor)
        {
            List<Libros> libros = consultarLibro.TodosLosLibros();
            List<DevolverLibrosFiltros> retornar = new List<DevolverLibrosFiltros>();

            if (stock)
                libros = FiltroStock(libros);
            if (titulo != null)
                libros = FiltroTitulo(libros, titulo);
            if (autor != null)
                libros = FiltroAutor(libros, autor);
            foreach (Libros libro in libros)
            {
                DevolverLibrosFiltros verificado = new DevolverLibrosFiltros();
                verificado.ISBN = libro.ISBN;
                verificado.titulo = libro.Titulo;
                verificado.autor = libro.Autor;
                verificado.editorial = libro.Editorial;
                verificado.edicion = libro.Edicion;
                verificado.stock = libro.Stock;
                verificado.imagen = libro.Imagen;
                retornar.Add(verificado);
            }
            return retornar;
        }
        private List<Libros> FiltroStock(List<Libros> libros)
        {
            List<Libros> librosRetornar = new List<Libros>();
            foreach (Libros libro in libros)
                if (libro.Stock > 0)
                    librosRetornar.Add(libro);
            return librosRetornar;
        }
        private List<Libros> FiltroTitulo(List<Libros> libros, string titulo)
        {
            List<Libros> librosRetornar = new List<Libros>();
            foreach (Libros libro in libros)
                if (libro.Titulo == titulo)
                    librosRetornar.Add(libro);
            return librosRetornar;
        }
        private List<Libros> FiltroAutor(List<Libros> libros, string autor)
        {
            List<Libros> librosRetornar = new List<Libros>();
            foreach (Libros libro in libros)
                if (libro.Autor == autor)
                    librosRetornar.Add(libro);
            return librosRetornar;
        }
        public List<DevolverLibrosFiltros> LibroParticular(string isbn)
        {
            List<DevolverLibrosFiltros> retornar = new();
            var libro = consultarLibro.BuscarLibroConISBN(isbn);
            if (libro == null)
                return retornar;
            var respuesta = new DevolverLibrosFiltros();
            respuesta.ISBN = libro.ISBN;
            respuesta.titulo = libro.Titulo;
            respuesta.autor = libro.Autor;
            respuesta.editorial = libro.Editorial;
            respuesta.edicion = libro.Edicion;
            respuesta.stock = libro.Stock;
            respuesta.imagen = libro.Imagen;
            retornar.Add(respuesta);
            return retornar;
        }
    }
}

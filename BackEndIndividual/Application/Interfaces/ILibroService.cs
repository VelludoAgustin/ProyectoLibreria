using Application.ClasesDeMensajes;

namespace Application.Interfaces
{
    public interface ILibroService
    {
        public Respuesta BuscarStock(string titulo, int stock);
        public List<DevolverLibrosFiltros> FiltrarLibros(bool stock, string? titulo, string? autor);
        public List<DevolverLibrosFiltros> LibroParticular(string isbn);
    }
}

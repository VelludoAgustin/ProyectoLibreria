using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Application.ClasesDeMensajes
{
    public class RetornoDeObjetos
    {
        public Cliente? cliente { get; set; }
        public Libros? libro { get; set; }
        public EstadoDeAlquileres? estado { get; set; }
        public Alquileres? alquileres { get; set; }
        public Respuesta? respuesta { get; set; }
        public List<Alquileres>? alquileresList { get; set; }
        public void RestornoObjetos(Cliente resultado, Libros mensaje, EstadoDeAlquileres estadoDeAlquileres, Alquileres alquileres, Respuesta respuesta)
        {
            this.cliente = resultado;
            this.libro = mensaje;
            this.estado = estadoDeAlquileres;
            this.respuesta = respuesta;
            this.alquileres = alquileres;
        }
    }
}

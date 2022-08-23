using Application.ClasesDeMensajes;
using Application.Interfaces;
using ProyectoSoftwareIndividual.Contexto;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Data.Consultas
{
    public class ConsultarTodosLosAlquileres : IConsultarAlquiler
    {
        private readonly ProyectoSoftwareLibreriaContext context;
        public ConsultarTodosLosAlquileres(ProyectoSoftwareLibreriaContext cont)
        {
            context = cont;
        }
        public List<Alquileres> ListarAlquileres()
        {
            return context.Alquileres.ToList();
        }
        public Alquileres? ReservaId(int id)
        {
            return context.Alquileres.Where(a => a.Id == id).FirstOrDefault();
        }
        public List<Alquileres> ListarAlquileresCliente(int id)
        {
            return context.Alquileres.Where(a=>a.ClienteId==id).ToList();
        }
        public List<Alquileres> ListarAlquileresConEstado(int? estado)
        {
            if (estado == null)
                return new List<Alquileres> { };
            return context.Alquileres.Where(a => a.EstadoId == estado).ToList();
        }
        public List<Alquileres> ListarSoloReservas(IngresoModificacion modificacion)
        {
            return context.Alquileres.Where(x => x.FechaReserva != null && x.ClienteId.ToString() == modificacion.cliente && x.ISBNId == modificacion.ISBN).ToList();
        }
    }
}

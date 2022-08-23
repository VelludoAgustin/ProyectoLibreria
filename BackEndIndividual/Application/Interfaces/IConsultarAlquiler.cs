using Application.ClasesDeMensajes;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Application.Interfaces
{
    public interface IConsultarAlquiler
    {
        public List<Alquileres> ListarAlquileres();
        public List<Alquileres> ListarAlquileresCliente(int id);
        public List<Alquileres> ListarAlquileresConEstado(int? estado);
        public List<Alquileres> ListarSoloReservas(IngresoModificacion modificacion);
        public Alquileres? ReservaId(int id);
    }
}

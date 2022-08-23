using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Application.Interfaces
{
    public interface IConsultarEstado
    {
        public EstadoDeAlquileres BuscarEstado(string eleccion);
        public EstadoDeAlquileres BuscarEstadoID(int id);
    }
}

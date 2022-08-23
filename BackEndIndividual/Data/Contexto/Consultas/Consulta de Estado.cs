using Application.Interfaces;
using ProyectoSoftwareIndividual.Contexto;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Data.Consultas
{
    public class ConsultaDeEstado : IConsultarEstado
    {
        private readonly ProyectoSoftwareLibreriaContext context;
        public ConsultaDeEstado(ProyectoSoftwareLibreriaContext cont)
        {
            context = cont;
        }
        public EstadoDeAlquileres BuscarEstado(string eleccion)
        {
            var estado = context.EstadoDeAlquileres.Where(s => s.Descripcion == eleccion).FirstOrDefault();
            return estado;
        }
        public EstadoDeAlquileres BuscarEstadoID(int id)
        {
            var estado = context.EstadoDeAlquileres.Where(s => s.EstadoID == id).FirstOrDefault();
            return estado;
        }
    }
}

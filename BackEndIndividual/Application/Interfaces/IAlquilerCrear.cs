using Application.ClasesDeMensajes;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Application.Interfaces
{
    public interface IAlquilerCrear
    {
        public Respuesta CreacionReserva(RetornoDeObjetos retornoDeObjetos, IngresoAlquiler ingresoReserva);
        public Respuesta CreacionAlquiler(RetornoDeObjetos retornoDeObjetos, IngresoAlquiler ingresoAlquiler);
        public Respuesta UpdateReserva(Alquileres alquileres);
    }
}

using Application.ClasesDeMensajes;
using System.Collections;

namespace Application.Interfaces
{
    public interface IAlquilerService
    {
        public Respuesta CrearAlquilerOReserva(IngresoAlquiler ingresoAlquiler);
        public ArrayList ListarReservasOAlquileres(int? opcion);
        public Respuesta ActualizarReserva(IngresoModificacion modificacion);
        public ArrayList ListarLibrosCliente(int id);
        public Respuesta ActualizarReservaId(int id);
    }
}
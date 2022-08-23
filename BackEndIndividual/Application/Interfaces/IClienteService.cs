using Application.ClasesDeMensajes;


namespace Application.Interfaces
{
    public interface IClienteService
    {
        public Respuesta CrearCliente(IngresoCliente cliente);
        public List<DevolverCliente> BuscarCliente(string nombre, string apellido, string dni);
    }
}

using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Application.Interfaces
{
    public interface IConsultarCliente
    {
        public List<Cliente> ListarClientes();
        public Cliente BuscarClienteEnBaseNombre(string nombre);
        public Cliente BuscarClienteEnBaseApellido(string apellido);
        public Cliente BuscarClienteEnBaseDNI(string dni);
        public Cliente BuscarClienteEnBaseId(int id);
    }
}

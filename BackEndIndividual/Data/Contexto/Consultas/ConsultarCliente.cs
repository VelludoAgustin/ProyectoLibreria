using Application.Interfaces;
using ProyectoSoftwareIndividual.Contexto;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Data.Consultas
{
    public class ConsultarCliente : IConsultarCliente
    {
        private readonly ProyectoSoftwareLibreriaContext context;
        public ConsultarCliente(ProyectoSoftwareLibreriaContext cont)
        {
            context = cont;
        }
        public List<Cliente> ListarClientes()
        {
            return context.cliente.ToList();
        }
        public Cliente BuscarClienteEnBaseDNI(string dni)
        {
            return context.cliente.Where(s => s.DNI == dni).FirstOrDefault();
        }
        public Cliente BuscarClienteEnBaseId(int id)
        {
            return context.cliente.Where(s => s.ClienteID == id).FirstOrDefault();
        }
        public Cliente BuscarClienteEnBaseNombre(string nombre)
        {
            return context.cliente.Where(s => s.Nombre == nombre).FirstOrDefault();
        }
        public Cliente BuscarClienteEnBaseApellido(string apellido)
        {
            return context.cliente.Where(s => s.Apellido == apellido).FirstOrDefault();
        }
    }
}
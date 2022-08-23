using Application.ClasesDeMensajes;
using Application.Interfaces;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Application.Servicio
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteCrear clienteCrear;
        private readonly IConsultarCliente clienteConsulta;
        public ClienteService(IClienteCrear com, IConsultarCliente query)
        {
            clienteCrear = com;
            clienteConsulta = query;
        }
        public Respuesta CrearCliente(IngresoCliente cliente)
        {
            Respuesta valido = ValidacionCliente(cliente.DNI, cliente.nombre, cliente.apellido, cliente.email);
            if (!valido.resultado)
                return valido;
            return clienteCrear.CreacionCliente(cliente.DNI, cliente.nombre, cliente.apellido, cliente.email);
        }
        public List<DevolverCliente> BuscarCliente(string nombre, string apellido, string dni)
        {
            List<DevolverCliente> devolverClientes = new List<DevolverCliente>();
            List<Cliente> lista = clienteConsulta.ListarClientes();
            if (dni != null)
                lista = FiltarDni(lista, dni);
            if (nombre != null)
                lista = FiltarNombre(lista, nombre);
            if (apellido != null)
                lista = FiltarApellido(lista, apellido);
            foreach (Cliente cliente in lista)
            {
                DevolverCliente devolver = new DevolverCliente();
                devolver.DNI = cliente.DNI;
                devolver.Nombre = cliente.Nombre;
                devolver.Apellido = cliente.Apellido;
                devolver.Email = cliente.Email;
                devolverClientes.Add(devolver);
            }
            return devolverClientes;
        }
        private List<Cliente> FiltarDni(List<Cliente> clientes, string dni)
        {
            List<Cliente> devolver = new List<Cliente>();
            foreach (Cliente cliente in clientes)
                if (cliente.DNI == dni)
                    devolver.Add(cliente);
            return devolver;
        }
        private List<Cliente> FiltarNombre(List<Cliente> clientes, string nombre)
        {
            List<Cliente> devolver = new List<Cliente>();
            foreach (Cliente cliente in clientes)
                if (cliente.Nombre == nombre)
                    devolver.Add(cliente);
            return devolver;
        }
        private List<Cliente> FiltarApellido(List<Cliente> clientes, string apellido)
        {
            List<Cliente> devolver = new List<Cliente>();
            foreach (Cliente cliente in clientes)
                if (cliente.Apellido == apellido)
                    devolver.Add(cliente);
            return devolver;
        }
        private Respuesta ValidacionCliente(string dni, string nombre, string apellido, string email)
        {
            try
            {
                int dniint = Convert.ToInt32(dni);
                if (dni.Length > 10 || 8 > dni.Length)
                    return new Respuesta(false, "El DNI no puede ser menor a 8 digitos o mayor de 10 digitos");
                if (nombre == "" || nombre.Length > 45 || nombre == null)
                    return new Respuesta(false, "El Nombre no puede ser nulo, vacio o mayor a 45 digitos");
                if (apellido == null || apellido.Length > 45 || apellido == "")
                    return new Respuesta(false, "El Apellido no puede ser nulo, vacio o mayor a 45 digitos");
                if (email == "" || email.Length > 45 || email == null)
                    return new Respuesta(false, "El Email no puede ser nulo, vacio o mayor a 45 digitos");
                var repetido = clienteConsulta.BuscarClienteEnBaseDNI(dni);
                if (repetido != null)
                    return new Respuesta(false, "El DNI ya se encuentra en la base de datos");
            }
            catch (Exception)
            {
                return new Respuesta(false, "El DNI es demaciado largo o contiene un caracter no numerico");
            }
            return new Respuesta(true, "Se validaron los datos correctamente");
        }
    }
}

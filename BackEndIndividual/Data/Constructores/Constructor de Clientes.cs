using Application.ClasesDeMensajes;
using Application.Interfaces;
using ProyectoSoftwareIndividual.Contexto;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace data.Constructores
{
    public class ConstructorClientes : IClienteCrear
    {
        private readonly ProyectoSoftwareLibreriaContext context;
        public ConstructorClientes(ProyectoSoftwareLibreriaContext cont)
        {
            context = cont;
        }
        public Respuesta CreacionCliente(string _DNI, string _Nombre, string _Apellido, string _Email)
        {
            try
            {
                var cliente1 = new Cliente()
                {
                    DNI = _DNI,
                    Nombre = _Nombre,
                    Apellido = _Apellido,
                    Email = _Email
                };
                context.cliente.Add(cliente1);
                context.SaveChanges();
                return new Respuesta(true, "Ingresado con exito en la base de datos");
            }
            catch (Exception)
            {
                return new Respuesta(false, "Internal server error");
            }
        }
    }
}

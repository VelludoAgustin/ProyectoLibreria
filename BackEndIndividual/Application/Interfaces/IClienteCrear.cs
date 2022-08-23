using Application.ClasesDeMensajes;


namespace Application.Interfaces
{
    public interface IClienteCrear
    {
        public Respuesta CreacionCliente(string _DNI, string _Nombre, string _Apellido, string _Email);
    }
}

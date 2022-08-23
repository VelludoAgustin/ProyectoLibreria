using Application.ClasesDeMensajes;
using Application.Interfaces;
using System.Collections;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;


namespace Application.Servicio
{
    public class AlquilerService : IAlquilerService
    {
        private readonly IAlquilerCrear alquilerCrear;
        private readonly IConsultarAlquiler alquilerConsulta;
        private readonly IConsultarCliente clienteConsulta;
        private readonly IConsultarLibro consultarLibro;
        private readonly IConsultarEstado consultarEstado;
        public AlquilerService(IAlquilerCrear com, IConsultarAlquiler query, IConsultarCliente queryCli, IConsultarLibro queryLib, IConsultarEstado queryEstado)
        {
            alquilerCrear = com;
            alquilerConsulta = query;
            clienteConsulta = queryCli;
            consultarLibro = queryLib;
            consultarEstado = queryEstado;
        }
        public Respuesta CrearAlquilerOReserva(IngresoAlquiler ingresoAlquiler)
        {
            Respuesta validado = ValidarAlquiler(ingresoAlquiler.cliente, ingresoAlquiler.ISBN);
            if (!validado.resultado)
                return validado;
            RetornoDeObjetos retornoDeObjetos = Validar(ingresoAlquiler);
            if (!retornoDeObjetos.respuesta.resultado)
                return retornoDeObjetos.respuesta;
            if (ingresoAlquiler.fechaAlquiler == null)
                return (alquilerCrear.CreacionReserva(retornoDeObjetos, ingresoAlquiler));
            else return (alquilerCrear.CreacionAlquiler(retornoDeObjetos, ingresoAlquiler));
        }
        public Respuesta ActualizarReserva(IngresoModificacion modificacion)
        {
            Respuesta validado = this.ValidarUpdate(modificacion);
            if (!validado.resultado)
                return validado;
            var listaReservas = alquilerConsulta.ListarSoloReservas(modificacion);
            if (listaReservas.Count == 0)
                return new Respuesta(false, "No se encontro ninguna reserva en la base con esos datos");
            return alquilerCrear.UpdateReserva(listaReservas[0]);
        }
        public Respuesta ActualizarReservaId(int id)
        {
            var listaReservas = alquilerConsulta.ReservaId(id);
            if (listaReservas == null)
                return new Respuesta(false, "No se encontro ninguna reserva en la base con esos datos");
            if (listaReservas.FechaAlquiler != null)
                return new Respuesta(false, "Esta Reserva ya se convirtio previamente");
            return alquilerCrear.UpdateReserva(listaReservas);
        }
        public ArrayList ListarReservasOAlquileres(int? opcion)
        {
            ArrayList retornoDeObjetos = new ArrayList();
            List<Alquileres> listaAlquileres = null;
            if (opcion != null)
                listaAlquileres = alquilerConsulta.ListarAlquileresConEstado(opcion);
            else
                listaAlquileres = alquilerConsulta.ListarAlquileres();
            foreach (var item in listaAlquileres)
            {
                if (item.EstadoId == 2)
                {
                    DevolverAlquileresYLibro instancia = new DevolverAlquileresYLibro();
                    var cliente = clienteConsulta.BuscarClienteEnBaseId(item.ClienteId);
                    var libro = consultarLibro.BuscarLibroConISBN(item.ISBNId);

                    instancia.nombreCliente = cliente.Nombre + " " + cliente.Apellido;
                    instancia.fechaAlquiler = item.FechaAlquiler;
                    instancia.fechaDevolucion = item.FechaDevolucion;
                    instancia.ISBN = libro.ISBN;
                    instancia.titulo = libro.Titulo;
                    instancia.autor = libro.Autor;
                    instancia.editorial = libro.Editorial;
                    instancia.edicion = libro.Edicion;
                    instancia.stock = libro.Stock;
                    instancia.imagen = libro.Imagen;
                    retornoDeObjetos.Add(instancia);
                }
                if (item.EstadoId == 1)
                {
                    DevolverReservasYLibro instancia = new DevolverReservasYLibro();
                    var cliente = clienteConsulta.BuscarClienteEnBaseId(item.ClienteId);
                    var libro = consultarLibro.BuscarLibroConISBN(item.ISBNId);
                    instancia.nombreCliente = cliente.Nombre + " " + cliente.Apellido;
                    instancia.fechaReserva = item.FechaReserva;
                    instancia.ISBN = libro.ISBN;
                    instancia.titulo = libro.Titulo;
                    instancia.autor = libro.Autor;
                    instancia.editorial = libro.Editorial;
                    instancia.edicion = libro.Edicion;
                    instancia.stock = libro.Stock;
                    instancia.imagen = libro.Imagen;
                    retornoDeObjetos.Add(instancia);
                }
            }
            return retornoDeObjetos;
        }
        public ArrayList ListarLibrosCliente(int id)
        {
            ArrayList retornoDeObjetos = new ArrayList();
            ArrayList retornoReservas = new ArrayList();
            ArrayList retornoAlquileres = new ArrayList();
            List<Alquileres> listaAlquileres = null;
            if (id != null)
                listaAlquileres = alquilerConsulta.ListarAlquileresCliente(id);
            foreach (var item in listaAlquileres)
            {
                DevolverAlquileresReservasYLibro instancia = new DevolverAlquileresReservasYLibro();
                var libro = consultarLibro.BuscarLibroConISBN(item.ISBNId);

                instancia.idAlquiler = item.Id;
                instancia.fechaAlquiler = item.FechaAlquiler;
                instancia.fechaDevolucion = item.FechaDevolucion;
                instancia.fechaReserva = item.FechaReserva;
                instancia.ISBN = libro.ISBN;
                instancia.titulo = libro.Titulo;
                instancia.autor = libro.Autor;
                instancia.editorial = libro.Editorial;
                instancia.edicion = libro.Edicion;
                instancia.stock = libro.Stock;
                instancia.imagen = libro.Imagen;

                if(item.FechaAlquiler==null)
                    retornoReservas.Add(instancia);
                else
                    retornoAlquileres.Add(instancia);
            }
            retornoDeObjetos.Add(retornoReservas);
            retornoDeObjetos.Add(retornoAlquileres);
            return retornoDeObjetos;
        }


        private Respuesta ValidarAlquiler(string IdCliente, string ISBN)
        {
            try
            {
                int _DNI = int.Parse(IdCliente);
                if (IdCliente == null)
                    return new Respuesta(false, "El ID de cliente no puede ser nulo");
            }
            catch (Exception)
            {
                return new Respuesta(false, "El ID no puede contener caracteres no numericos");
            }
            try
            {
                if (ISBN == null || ISBN.Length > 50)
                    return new Respuesta(false, "El ISBN no puede ser nulo o mayor de 50 digitos");
            }
            catch (Exception)
            {
                return new Respuesta(false, "ocurrio un error con el ISBN");
            }
            return new Respuesta(true, "Datos ingresados validados");
        }
        private RetornoDeObjetos Validar(IngresoAlquiler ingresoAlquiler)
        {
            RetornoDeObjetos retornoDeObjetos = new RetornoDeObjetos();
            var clienteEncontrado = clienteConsulta.BuscarClienteEnBaseId(Convert.ToInt32(ingresoAlquiler.cliente));
            if (clienteEncontrado == null)
            {
                retornoDeObjetos.respuesta = new Respuesta(false, "El ID no se encontro en la base de datos");
                return retornoDeObjetos;
            }
            var libroEncontrado = consultarLibro.BuscarLibroConISBN(ingresoAlquiler.ISBN);
            if (libroEncontrado == null)
            {
                retornoDeObjetos.respuesta = new Respuesta(false, "el ISBN no se encontro en la base de datos"); ;
                return retornoDeObjetos;
            }
            if (libroEncontrado.Stock == null || libroEncontrado.Stock <= 0)
            {
                retornoDeObjetos.respuesta = new Respuesta(false, "El libro se encuentra en la base, pero no se cuenta con stock"); ;
                return retornoDeObjetos;
            }
            if (ingresoAlquiler.fechaAlquiler != null && ingresoAlquiler.fechaReserva != null)
            {
                retornoDeObjetos.respuesta = new Respuesta(false, "No se puede crear una reserva y alquiler a la vez"); ;
                return retornoDeObjetos;
            }
            if (ingresoAlquiler.fechaAlquiler == null)
            {
                var estadoEncontrado = consultarEstado.BuscarEstado("Reservado");
                retornoDeObjetos.estado = estadoEncontrado;
            }
            else
            {
                var estadoEncontrado = consultarEstado.BuscarEstado("Alquilado");
                retornoDeObjetos.estado = estadoEncontrado;
            }
            retornoDeObjetos.cliente = clienteEncontrado;
            retornoDeObjetos.libro = libroEncontrado;
            retornoDeObjetos.respuesta = new Respuesta(true, "");
            return retornoDeObjetos;
        }
        private Respuesta ValidarUpdate(IngresoModificacion modificacion)
        {
            if (modificacion.cliente == null || modificacion.cliente == "")
                return new Respuesta(false, "El cliente es nulo o vacio");
            if (modificacion.cliente == null || modificacion.cliente == "")
                return new Respuesta(false, "El libro es nulo o vacio");
            return new Respuesta(true, "Validacion exitosa");
        }
    }
}

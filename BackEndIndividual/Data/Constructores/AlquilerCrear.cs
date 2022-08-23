using Application.ClasesDeMensajes;
using Application.Interfaces;
using ProyectoSoftwareIndividual.Contexto;
using TrabajoPracticoIndividualProyectoSoftware.CrearTablas;

namespace Data.Constructores
{
    public class AlquilerCrear : IAlquilerCrear
    {
        private readonly ProyectoSoftwareLibreriaContext context;
        public AlquilerCrear(ProyectoSoftwareLibreriaContext cont)
        {
            context = cont;
        }
        public Respuesta CreacionReserva(RetornoDeObjetos retornoDeObjetos, IngresoAlquiler ingresoAlquiler)
        {
            try
            {
                var std1 = new Alquileres()
                {
                    ClienteId = retornoDeObjetos.cliente.ClienteID,
                    ISBNId = retornoDeObjetos.libro.ISBN,
                    EstadoId = retornoDeObjetos.estado.EstadoID,
                    FechaReserva = ingresoAlquiler.fechaReserva,
                    FechaAlquiler = ingresoAlquiler.fechaAlquiler,
                    FechaDevolucion = ingresoAlquiler.fechaAlquiler
                };
                context.Alquileres.Add(std1);
                retornoDeObjetos.libro.Stock--;
                context.SaveChanges();
                return new Respuesta(true, "Reserva creada correctamente");
            }
            catch (Exception)
            {
                return new Respuesta(false, "Internal Server Error");
            }
        }
        public Respuesta CreacionAlquiler(RetornoDeObjetos retornoDeObjetos, IngresoAlquiler ingresoAlquiler)
        {
            try
            {
                var std1 = new Alquileres()
                {
                    ClienteId = retornoDeObjetos.cliente.ClienteID,
                    ISBNId = retornoDeObjetos.libro.ISBN,
                    EstadoId = retornoDeObjetos.estado.EstadoID,
                    FechaReserva = ingresoAlquiler.fechaReserva,
                    FechaAlquiler = ingresoAlquiler.fechaAlquiler,
                    FechaDevolucion = ingresoAlquiler.fechaAlquiler.Value.AddDays(7)
                };
                context.Alquileres.Add(std1);
                retornoDeObjetos.libro.Stock--;
                context.SaveChanges();
                return new Respuesta(true, "alquiler creado correctamente");
            }
            catch (Exception)
            {
                return new Respuesta(false, "Internal Server Error");
            }
        }
        public Respuesta UpdateReserva(Alquileres alquileres)
        {
            try
            {
                alquileres.EstadoId = 2;
                alquileres.FechaAlquiler = DateTime.Now;
                alquileres.FechaDevolucion = DateTime.Now.AddDays(7);

                context.Alquileres.Update(alquileres);
                context.SaveChanges();

                return new Respuesta(true, "Actualizacion Completada");
            }
            catch (Exception)
            {
                return new Respuesta(false, "Internal Server Error");
            }
        }
    }
}

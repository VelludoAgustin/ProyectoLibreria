using Application.ClasesDeMensajes;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApplicationPS.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService alquilerServices;

        public AlquilerController(IAlquilerService use)
        {
            alquilerServices = use;
        }
        [HttpPost("alquiler")]
        public IActionResult CrearAlquiler([FromBody] IngresoAlquiler alquiler)
        {
            Respuesta respuesta = alquilerServices.CrearAlquilerOReserva(alquiler);
            if (!respuesta.resultado)
                return new JsonResult(new { Error = respuesta.mensaje }) { StatusCode = 400 };
            return new JsonResult(new { Mensaje = respuesta.mensaje }) { StatusCode = 201 };
        }
        [HttpPut("alquiler")]
        public IActionResult ConvertirReserva([FromBody] IngresoModificacion modificacion)
        {
            Respuesta respuesta = alquilerServices.ActualizarReserva(modificacion);
            if (!respuesta.resultado)
                return new JsonResult(new { Error = respuesta.mensaje }) { StatusCode = 400 };
            return new JsonResult(new { Mensaje = respuesta.mensaje }) { StatusCode = 200 };
        }
        [HttpPut("alquiler/{id}")]
        public IActionResult ConvertirReservaId(int id)
        {
            Respuesta respuesta = alquilerServices.ActualizarReservaId(id);
            if (!respuesta.resultado)
                return new JsonResult(new { Error = respuesta.mensaje }) { StatusCode = 400 };
            return new JsonResult(new { Mensaje = respuesta.mensaje }) { StatusCode = 200 };
        }
        [HttpGet("alquiler")]
        public IActionResult ListarAlquileres(int? estado)
        {
            ArrayList respuesta = alquilerServices.ListarReservasOAlquileres(estado);
            if (respuesta == null)
                return new JsonResult(new { Lista = respuesta }) { StatusCode = 400 };
            return new JsonResult(new { Lista = respuesta }) { StatusCode = 200 };
        }
        [HttpGet("alquiler/cliente/{id}")]
        public IActionResult ListarlibrosCliente(int id)
        {
            ArrayList respuesta = alquilerServices.ListarLibrosCliente(id);
            if (respuesta == null)
                return new JsonResult(new { Lista = respuesta }) { StatusCode = 400 };
            return new JsonResult(new { Lista = respuesta }) { StatusCode = 200 };
        }
    }
}

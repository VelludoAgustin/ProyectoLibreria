using Application.ClasesDeMensajes;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoSoftwareIndividual.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteServices;

        public ClientesController(IClienteService use)
        {
            clienteServices = use;
        }
        [HttpPost("clientes")]
        public IActionResult CrearCliente([FromBody] IngresoCliente cliente)
        {
            Respuesta respuesta = clienteServices.CrearCliente(cliente);
            if (!respuesta.resultado)
                return new JsonResult(new { Error = respuesta.mensaje }) { StatusCode = 400 };
            return new JsonResult(new { Mensaje = respuesta.mensaje }) { StatusCode = 201 };
        }
        [HttpGet("clientes")]
        public IActionResult buscarCliente(string? nombre, string? apellido, string? dni)
        {
            List<DevolverCliente> respuesta = clienteServices.BuscarCliente(nombre, apellido, dni);
            if (respuesta.Count == 0)
                return new JsonResult(new { Lista = respuesta }) { StatusCode = 400 };
            return new JsonResult(new { Lista = respuesta }) { StatusCode = 200 };
        }
    }
}

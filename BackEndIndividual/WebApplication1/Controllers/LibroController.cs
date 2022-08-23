using Application.ClasesDeMensajes;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationPS.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService libroServices;

        public LibroController(ILibroService use)
        {
            libroServices = use;
        }
        [HttpGet("libros/")]
        public IActionResult listarLibrosFiltros(bool stock, string? titulo, string? autor)
        {
            List<DevolverLibrosFiltros> respuesta = libroServices.FiltrarLibros(stock, titulo, autor);
            if (respuesta.Count == 0)
                return new JsonResult(new { Lista = respuesta }) { StatusCode = 400 };
            return new JsonResult(new { Lista = respuesta }) { StatusCode = 200 };
        }
        [HttpHead("libros/{id}")]
        public IActionResult BuscarStock(string id, [FromQuery] int stock)
        {
            Respuesta respuesta = libroServices.BuscarStock(id, stock);
            if (!respuesta.resultado)
                return BadRequest();
            return Ok();
        }
        [HttpGet("LibroParticular/{isbn}")]
        public IActionResult LibroPArticular(string isbn)
        {
            List<DevolverLibrosFiltros> respuesta = libroServices.LibroParticular(isbn);
            if (respuesta.Count == 0)
                return new JsonResult(new { Lista = respuesta }) { StatusCode = 400 };
            return new JsonResult(new { Lista = respuesta }) { StatusCode = 200 };
        }
    }
}

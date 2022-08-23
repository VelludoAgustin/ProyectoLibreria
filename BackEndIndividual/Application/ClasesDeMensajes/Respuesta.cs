using System.Collections;

namespace Application.ClasesDeMensajes
{
    public class Respuesta
    {
        public bool resultado { get; set; }
        public string? mensaje { get; set; }
        public object? objects { get; set; }
        public ArrayList? List { get; set; }
        public Respuesta(bool resultadoParametro, string mensajeParametro)
        {
            this.resultado = resultadoParametro;
            this.mensaje = mensajeParametro;
        }
    }
}

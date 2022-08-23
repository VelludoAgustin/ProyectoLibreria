namespace Application.ClasesDeMensajes
{
    public class DevolverAlquileresYLibro
    {
        public string? nombreCliente { get; set; }
        public DateTime? fechaAlquiler { get; set; }
        public DateTime? fechaDevolucion { get; set; }
        public string? ISBN { get; set; }
        public string? titulo { get; set; }
        public string? autor { get; set; }
        public string? editorial { get; set; }
        public string? edicion { get; set; }
        public int? stock { get; set; }
        public string? imagen { get; set; }
    }
    public class DevolverReservasYLibro
    {
        public string? nombreCliente { get; set; }
        public DateTime? fechaReserva { get; set; }
        public string? ISBN { get; set; }
        public string? titulo { get; set; }
        public string? autor { get; set; }
        public string? editorial { get; set; }
        public string? edicion { get; set; }
        public int? stock { get; set; }
        public string? imagen { get; set; }
    }
    public class DevolverAlquileresReservasYLibro
    {
        public int? idAlquiler { get; set; }
        public DateTime? fechaAlquiler { get; set; }
        public DateTime? fechaReserva { get; set; }
        public DateTime? fechaDevolucion { get; set; }
        public string? ISBN { get; set; }
        public string? titulo { get; set; }
        public string? autor { get; set; }
        public string? editorial { get; set; }
        public string? edicion { get; set; }
        public int? stock { get; set; }
        public string? imagen { get; set; }
    }
}

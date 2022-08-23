namespace Application.ClasesDeMensajes
{
    public class DevolverLibro
    {
        public string? ISBN { get; set; }
        public string? titulo { get; set; }
        public string? autor { get; set; }
        public string? editorial { get; set; }
        public string? edicion { get; set; }
        public int? stock { get; set; }
        public string? imagen { get; set; }
        public int? cantidadRetenida { get; set; } = 0;
    }
}

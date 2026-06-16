using System;

namespace p3_csharp_orm.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? Edad { get; set; }
        public DateTime CreadoEn { get; set; } = DateTime.Now;
        public string? ContraseñaHash { get; set; }
        public DateTime ActualizadoEn { get; set; } = DateTime.Now;
        public string? NumeroCelular { get; set; }
    }
}

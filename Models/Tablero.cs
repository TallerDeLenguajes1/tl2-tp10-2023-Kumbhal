using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_Kumbhal.Models{
    public class Tablero{
        public int Id { get; set;}
        public int IdUsuarioPropietario { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set;}
    }
}
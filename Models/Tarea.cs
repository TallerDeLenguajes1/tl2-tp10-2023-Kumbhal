namespace tl2_tp10_2023_Kumbhal.Models{
    public enum EstadoTarea{
        Ideas = 1,
        ToDo = 2,
        Doing = 3,
        Review = 4,
        Done = 5
    }
    public class Tarea{
        public int Id{ get; set;}
        public int IdTablero{ get; set;}
        public string? Nombre{ get; set;}
        public string? Descripcion{ get; set;}
        public string? Color{ get; set;}
        public int IdUsuarioAsignado{ get; set;}
        public EstadoTarea Estado { get; set;}
    }
}
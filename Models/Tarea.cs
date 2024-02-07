namespace tl2_tp10_2023_Kumbhal.Models{
    public enum EstadoTarea{
        Ideas = 1,
        ToDo = 2,
        Doing = 3,
        Review = 4,
        Done = 5
    }
    public class Tarea{
        public int Id{ get => Id ; set => Id = value;}
        public int IdTablero{ get => IdTablero ; set => IdTablero = value;}
        public string? Nombre{ get => Nombre ; set => Nombre = value;}
        public string? Descripcion{ get => Descripcion ; set => Descripcion = value;}
        public string? Color{ get => Color ; set => Color = value;}
        public int IdUsuarioAsignado{ get => IdUsuarioAsignado ; set => IdUsuarioAsignado = value;}
        public EstadoTarea Estado { get => Estado; set => Estado = value; }
    }
}
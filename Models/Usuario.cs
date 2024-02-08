namespace tl2_tp10_2023_Kumbhal.Models{
    public enum Roles{
        Admin = 1,
        Operador = 2
    }
    public class Usuario{
        public int Id { get; set;}
        public string? NombreDeUsuario { get; set;}
        public string? Contrasenia { get; set;}
        public Roles RolUsuario { get; set;}
    }
}
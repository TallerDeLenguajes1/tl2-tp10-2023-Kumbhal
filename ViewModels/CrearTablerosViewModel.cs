using tl2_tp10_2023_Kumbhal.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_Kumbhal.ViewModels;

public class CrearTablerosViewModel{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo requerido")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Campo requerido")]
    public string Descripcion { get; set; }
    [Required(ErrorMessage = "Campo requerido")]
    public int? IdUsuarioPropietario { get; set; }
    public string? NombreUsuario {get; set;}
    public List<Usuario> ListaUsuarios {get; set;}
    public CrearTablerosViewModel(List<Usuario> listado){
        ListaUsuarios = listado;
    }
}
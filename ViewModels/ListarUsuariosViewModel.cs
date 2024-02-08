using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_Kumbhal.Models;

namespace tl2_tp10_2023_Kumbhal.ViewModels;

public class ListarUsuariosViewModel{
    public List<Usuario>? listadoUsuarios;
    [Required]
    public int idUsuarioBuscado;
    public ListarUsuariosViewModel(List<Usuario> listado){
        listadoUsuarios = listado;
    }
}
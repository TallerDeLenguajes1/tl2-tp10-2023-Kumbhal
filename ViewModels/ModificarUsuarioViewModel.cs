using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using tl2_tp10_2023_Kumbhal.Models;

namespace tl2_tp10_2023_Kumbhal.ViewModels;

public class ModificarUsuarioViewModel{
    public int Id {get; set;}

    [Required (ErrorMessage ="Campo requerido")]
    public string? MUVMUsuario {get; set;}
    public string? MUVMContrasenia {get; set;}
    [Required (ErrorMessage ="Campo requerido")]
    public Roles MUVMRoles {get; set;}
    public ModificarUsuarioViewModel(){}
    public ModificarUsuarioViewModel(Usuario usuarioElegido){
        Id = usuarioElegido.Id;
        MUVMRoles = usuarioElegido.RolUsuario;
        MUVMContrasenia = usuarioElegido.Contrasenia;
        MUVMUsuario = usuarioElegido.NombreDeUsuario;
    }
}
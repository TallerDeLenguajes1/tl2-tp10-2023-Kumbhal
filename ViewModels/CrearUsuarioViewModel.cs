using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_Kumbhal.Models;

namespace tl2_tp10_2023_Kumbhal.ViewModels;

public class CrearUsuarioViewModel{
    public int Id {get; set;}

    [Required (ErrorMessage ="Campo requerido")]
    public string? CUVMUsuario {get; set;}

    [Required (ErrorMessage ="Campo requerido")]
    public string? CUVMContrasenia {get; set;}

    [Required (ErrorMessage ="Campo requerido")]
    public int CUVMId {get; set;}

    [Required (ErrorMessage ="Campo requerido")]
    public Roles CUVMRol {get; set;}
}
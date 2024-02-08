using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using tl2_tp10_2023_Kumbhal.Models;

namespace tl2_tp10_2023_Kumbhal.ViewModels;

public class ModificarTableroViewModel{
    public int Id {get; set;}

    [Required (ErrorMessage ="Campo requerido")]
    public string? NombreTablero {get; set;}
    [Required (ErrorMessage ="Campo requerido")]
    public string? Descripcion {get; set;}
    [Required (ErrorMessage ="Campo requerido")]
    public int IdUsuarioPropietario {get; set;}
    public string? NombreUsuario { get; set; }
    public List<Usuario> listadoUsuarios { get; set; }
    public ModificarTableroViewModel(){}
    public ModificarTableroViewModel(Tablero tablero, List<Usuario> listadoU){
        Id = tablero.Id;
        NombreTablero = tablero.Nombre;
        Descripcion = tablero.Descripcion;
        IdUsuarioPropietario = tablero.IdUsuarioPropietario;
        listadoUsuarios = listadoU;
    }
}
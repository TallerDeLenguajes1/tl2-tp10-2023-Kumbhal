using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_Kumbhal.ViewModels;

public class LoginViewModel {
    [Required(ErrorMessage = "Campo requerido")]
    public string VMUsuario { get; set; }
    [Required(ErrorMessage = "Campo requerido")]
    [PasswordPropertyText]
    public string VMContrasenia { get; set; }
    public LoginViewModel(){}
    }
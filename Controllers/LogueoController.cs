using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_Kumbhal.Repositories;
using tl2_tp10_2023_Kumbhal.Models;
using tl2_tp10_2023_Kumbhal.ViewModels;

namespace tl2_tp10_2023_Kumbhal.Controllers;
public class LogueoController : Controller{
    private readonly ILogger<LogueoController> _logger;
    private IUsuarioRepository usuarioRepository;
    public LogueoController(ILogger<LogueoController> logger, IUsuarioRepository _usuarioRepository)
    {
        usuarioRepository = _usuarioRepository;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel usuario){
        var usuarios = usuarioRepository.GetAll();
        var usuarioLogueado = usuarios.FirstOrDefault(usuarioLog => usuarioLog.NombreDeUsuario == usuario.VMUsuario && usuarioLog.Contrasenia == usuario.VMContrasenia);
        if (usuarioLogueado == null){
            return RedirectToAction("Index");
        }
        LoguearUsuario(usuarioLogueado);
        return RedirectToAction("Index", "Home");
    }
    public void LoguearUsuario(Usuario usuarioLogueo){
        HttpContext.Session.SetString("Usuario", usuarioLogueo.NombreDeUsuario!);
        HttpContext.Session.SetInt32("Rol", (int)usuarioLogueo.RolUsuario);
        HttpContext.Session.SetInt32("Id", usuarioLogueo.Id);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
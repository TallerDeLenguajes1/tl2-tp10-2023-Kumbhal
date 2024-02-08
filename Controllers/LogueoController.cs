using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_Kumbhal.Repositories;
using tl2_tp10_2023_Kumbhal.Models;

namespace tl2_tp10_2023_Kumbhal.Controllers;
public class LogueoController : Controller{
    private readonly ILogger<LogueoController> _logger;
    UsuarioRepository usuarioRepository;
    public LogueoController(ILogger<LogueoController> logger)
    {
        usuarioRepository = new UsuarioRepository();
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string usuario, string contrasenia){
        var usuarios = usuarioRepository.GetAll();
        var usuarioLogueado = usuarios.FirstOrDefault(usuarioLog => usuarioLog.NombreDeUsuario == usuario && usuarioLog.Contrasenia == contrasenia);
        if (usuarioLogueado == null){
            return RedirectToAction("Index");
        }
        LoguearUsuario(usuarioLogueado);
        return RedirectToAction("Index", "Home");
    }
    public void LoguearUsuario(Usuario usuarioLogueo){
        HttpContext.Session.SetString("Usuario", usuarioLogueo.NombreDeUsuario!);
        HttpContext.Session.SetInt32("Rol", usuarioLogueo.RolUsuario);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
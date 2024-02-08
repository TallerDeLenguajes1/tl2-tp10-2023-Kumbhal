using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_Kumbhal.Repositories;
using tl2_tp10_2023_Kumbhal.Models;
using Microsoft.AspNetCore.Authorization;
using tl2_tp10_2023_Kumbhal.ViewModels;

namespace tl2_tp10_2023_Kumbhal.Controllers;

public class UsuarioController : Controller {
    private readonly ILogger<UsuarioController> _logger;
    UsuarioRepository usuarioRepository;

    public UsuarioController(ILogger<UsuarioController> logger) {
        usuarioRepository = new UsuarioRepository();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(){
        if (Log()){
            // Si no está autenticado, redirigir al controlador de Logueo
            return RedirectToAction("Index", "Logueo");
        }
        return View(new ListarUsuariosViewModel(usuarioRepository.GetAll()));
    }

    [HttpGet]
    public IActionResult Create(){
        if (Log()){
            return RedirectToAction("Index", "Logueo");
        }
        return View(new CrearUsuarioViewModel());
    } 

    [HttpPost]
    public IActionResult Create(CrearUsuarioViewModel usuario) {
        if (Log()){
            return RedirectToAction("Index", "Logueo");
        }
        var usuarioNuevo = new Usuario(){
            NombreDeUsuario = usuario.CUVMUsuario,
            Contrasenia = usuario.CUVMContrasenia
        };
        usuarioRepository.Create(usuarioNuevo);
        return RedirectToAction("Index", "Usuario");
    }

    [HttpGet]
    public IActionResult Update(int id){
        if(Log()){
            return RedirectToAction("Index", "Logueo");
        }
        return View(new ModificarUsuarioViewModel(usuarioRepository.GetById(id)));
    } 

    [HttpPost]
    public IActionResult Update(ModificarUsuarioViewModel usuarioVM){
        if (Log()){
            return RedirectToAction("Index", "Logueo");
        }
        /*if(!ModelState.IsValid){
            return RedirectToAction("Index", "Logueo");
        }*/
        var usuarioNuevo = ConvertirCrearUsuarioViewModelAUsuario(usuarioVM);
        usuarioRepository.Update(usuarioNuevo.Id, usuarioNuevo);
        if (HttpContext.Session.GetInt32("Rol") == 2){
            HttpContext.Session.SetString("Usuario", usuarioNuevo.NombreDeUsuario);
            HttpContext.Session.SetInt32("Rol", (int)usuarioNuevo.RolUsuario); 
        }
        return RedirectToAction("Index", "Usuario");
    }


    [HttpGet]
    public IActionResult Remove(int id) {
        if (HttpContext.Session.GetInt32("Id")==id){
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("Rol");
            HttpContext.Session.Remove("Usuario");
        }
        usuarioRepository.Remove(id);
        return RedirectToAction("Index", "Logueo");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    private bool Log(){
        return (HttpContext.Session.GetString("Usuario") == null);
    }
    private int NivelAdm(){
        return (int)HttpContext.Session.GetInt32("Rol")!;
    }
    private int IdUsuario(){
        return (int)HttpContext.Session.GetInt32("Id")!;
    }
    private Usuario ConvertirCrearUsuarioViewModelAUsuario(ModificarUsuarioViewModel usuarioVM)
    {
        var usuario = new Usuario();
        usuario.Id = usuarioVM.Id;
        usuario.NombreDeUsuario = usuarioVM.MUVMUsuario;
        usuario.Contrasenia = usuarioVM.MUVMContrasenia;
        usuario.RolUsuario = usuarioVM.MUVMRoles;
        return usuario;
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_Kumbhal.Repositories;
using tl2_tp10_2023_Kumbhal.Models;

namespace tl2_tp10_2023_Kumbhal.Controllers;

public class UsuarioController : Controller {
    private readonly ILogger<UsuarioController> _logger;
    UsuarioRepository usuarioRepository;

    public UsuarioController(ILogger<UsuarioController> logger) {
        usuarioRepository = new UsuarioRepository();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index() => View(usuarioRepository.GetAll());


    [HttpGet]
    public IActionResult Create() => View(new Usuario());

    [HttpPost]
    public IActionResult Create(Usuario usuario) {
        usuarioRepository.Create(usuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id){
        return View(usuarioRepository.GetById(id));
    } 

    [HttpPost]
    public IActionResult Update(Usuario usuario) {
        usuarioRepository.Update(usuario.Id, usuario);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Remove(int id) {
        usuarioRepository.Remove(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
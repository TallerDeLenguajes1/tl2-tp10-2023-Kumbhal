using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_Kumbhal.Repositories;
using tl2_tp10_2023_Kumbhal.Models;
using Microsoft.AspNetCore.Authorization;
using tl2_tp10_2023_Kumbhal.ViewModels;

namespace tl2_tp10_2023_Kumbhal.Controllers;

public class TableroController : Controller {
    private readonly ILogger<TableroController> _logger;
    UsuarioRepository usuarioRepository;
    TableroRepository tableroRepository;

    public TableroController(ILogger<TableroController> logger) {
        tableroRepository = new TableroRepository();
        usuarioRepository = new UsuarioRepository();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(){
        if (Log())
            {
                // Si no está autenticado, redirigir al controlador de Logueo
                return RedirectToAction("Index", "Logueo");
            }
        if (NivelAdm()==1){
            return View(new ListarTablerosViewModel(tableroRepository.GetAll()));
        }
        return View(new ListarTablerosViewModel(tableroRepository.GetAllById(IdUsuario())));
    }


    [HttpGet]
    public IActionResult Create(){
        if (Log()){
            return RedirectToAction("Index", "Logueo");
        }
        return View(new CrearTablerosViewModel(usuarioRepository.GetAll()));
    } 

    [HttpPost]
    public IActionResult Create(Tablero tablero){
        if (Log()){
            return RedirectToAction("Index", "Logueo");
        }
        tableroRepository.Create(tablero);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id){
        if (Log()){
            return RedirectToAction("Index", "Logueo");
        }
        return View(new ModificarTableroViewModel(tableroRepository.GetById(id), usuarioRepository.GetAll()));
    }

    [HttpPost]
    public IActionResult Update(ModificarTableroViewModel tableroVM) {
        if (Log()){
            return RedirectToAction("Index", "Logueo");
        }
        var tableroNuevo = ConvertirCrearTableroViewModelATablero(tableroVM);
        tableroRepository.Update(tableroNuevo.Id, tableroNuevo);
        return RedirectToAction("Index", "Tablero");
    }


    [HttpGet]
    public IActionResult Remove(int id) {
        tableroRepository.Remove(id);
        return RedirectToAction("Index");
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
    private Tablero ConvertirCrearTableroViewModelATablero(ModificarTableroViewModel tableroVM){
        var tablero = new Tablero();
        tablero.Id = tableroVM.Id;
        tablero.IdUsuarioPropietario = (int)tableroVM.IdUsuarioPropietario;
        tablero.Nombre = tableroVM.NombreTablero;
        tablero.Descripcion = tableroVM.Descripcion;
        return tablero;
    }
} 
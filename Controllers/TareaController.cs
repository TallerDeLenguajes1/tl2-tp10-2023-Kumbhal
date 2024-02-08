using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_Kumbhal.Repositories;
using tl2_tp10_2023_Kumbhal.Models;
using Microsoft.AspNetCore.Authorization;

namespace tl2_tp10_2023_Kumbhal.Controllers;

public class TareaController : Controller {
    private readonly ILogger<TareaController> _logger;
    TareaRepository tareaRepository;

    public TareaController(ILogger<TareaController> logger) {
        tareaRepository = new TareaRepository();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(){
        if (Log())
            {
                // Si no está autenticado, redirigir al controlador de Logueo
                return RedirectToAction("Index", "Logueo");
            }
        return View(tareaRepository.GetAll());
    }

    [HttpGet]
    public IActionResult Create(){
        return View(new Tarea());
    }

    [HttpPost]
    public IActionResult Create(Tarea tarea) {
        tareaRepository.Create(tarea);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id){
        return View(tareaRepository.GetById(id));
    }

    [HttpPost]
    public IActionResult Update (int id, Tarea tarea) {
        tareaRepository.Update(tarea.Id, tarea);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Remove(int id) {
        tareaRepository.Remove(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    private bool Log(){
        return (HttpContext.Session.GetString("Usuario") == null);
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_Kumbhal.Repositories;
using tl2_tp10_2023_Kumbhal.Models;

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
    public IActionResult Update (Tarea tarea, string? nombre) {
        tareaRepository.UpdateNombre(tarea.Id, nombre);
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
}
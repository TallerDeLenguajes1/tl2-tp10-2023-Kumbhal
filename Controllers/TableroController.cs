using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_Kumbhal.Repositories;
using tl2_tp10_2023_Kumbhal.Models;

namespace tl2_tp10_2023_Kumbhal.Controllers;

public class TableroController : Controller {
    private readonly ILogger<TableroController> _logger;
    TableroRepository tableroRepository;

    public TableroController(ILogger<TableroController> logger) {
        tableroRepository = new TableroRepository();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(){
        return View(tableroRepository.GetAll());
    }


    [HttpGet]
    public IActionResult Add(){
        return View(new Tablero());
    } 

    [HttpPost]
    public IActionResult Create(Tablero tablero) {
        tableroRepository.Create(tablero);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id){
        return View(tableroRepository.GetById(id));
    }

    [HttpPost]
    public IActionResult Update(Tablero tablero) {
        tableroRepository.Update(tablero.Id, tablero);
        return RedirectToAction("Index");
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
} 
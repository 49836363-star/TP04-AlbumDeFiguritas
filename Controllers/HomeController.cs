using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP4.Models;

namespace TP4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AbrirSobre()
    {
        List<Jugadores> sobre = BD.AbrirSobre();
        ViewBag.Sobre = sobre;
        return View();
    }
    [HttpPost]
    public IActionResult ConfirmarSobre(List<int> idJugadores)
    {
        BD.ConfirmarSobre(idJugadores);
        return RedirectToAction("Album");
    }

    public IActionResult Album()
    {
        List<Figuritas> album=BD.ObtenerFiguritas();
        ViewBag.Album = album; 
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

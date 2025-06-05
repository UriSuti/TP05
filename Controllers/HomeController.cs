using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05.Models;

namespace TP05.Controllers;

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
    public IActionResult RespuestaHabitacion1(string input)
    {
        SalaEscape juego = new SalaEscape();
        juego.Respuesta(input, 1);
        return View();
    }

    public IActionResult Tutorial()
    {
        return View("tutorial");
    }
        public IActionResult Introduccion()
    {
        return View("introduccion");
    }
    public IActionResult SSI()
    {
        return View("SSI");
    }

    public IActionResult Arte()
    {
        HttpContext.Session.SetString("TiempoInicio", DateTime.Now.ToString("o"));
        return View("Arte");
    }

    [HttpPost]
    public IActionResult ArteRespuesta(string respuesta)
    {
        string tiempoInicioStr = HttpContext.Session.GetString("TiempoInicio");
        if (tiempoInicioStr != null && DateTime.TryParse(tiempoInicioStr, out DateTime tiempoInicio))
        {
            TimeSpan tiempoTranscurrido = DateTime.Now - tiempoInicio;
            if (tiempoTranscurrido.TotalSeconds <= 5 && respuesta.ToUpper() == "OK")
            {
                return RedirectToAction("SSI");
            }
        }

        ViewBag.Error = "¡Te vio Mauri o te demoraste!";
        return View("Arte");
    }

}

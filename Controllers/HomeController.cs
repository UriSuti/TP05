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
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        if (juego is null)
        {
            SalaEscape juegoo = new SalaEscape();
            HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juegoo));
        }
        return View();
    }

    [HttpPost]
    public IActionResult RespuestaHabitacion1(string input)
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        int respuesta = juego.Respuesta(input, 1);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        if (respuesta == 1)
        {
            return View("prog");
        } else {
            return View("SSI");
        }
    }

    [HttpPost]
    public IActionResult RespuestaHabitacion2(string input)
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        int respuesta = juego.Respuesta(input, 2);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        if (respuesta == 1)
        {
            return View("arte");
        } else {
            return View("prog");
        }
    }

    [HttpPost]
    public IActionResult RespuestaHabitacion3(string input)
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        int respuesta = juego.Respuesta(input, 3);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        if (respuesta == 1)
        {
            return View("bd");
        } else {
            return View("arte");
        }
    }

    [HttpPost]
    public IActionResult RespuestaHabitacion4(string input)
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        int respuesta = juego.Respuesta(input, 4);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        if (respuesta == 1)
        {
            return View("pf");
        } else {
            return View("bd");
        }
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

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
            ViewBag.notas = juegoo.Nota;
            ViewBag.notis = juegoo.Notificaciones;
            HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juegoo));
        }
        return View();
    }

    [HttpPost]
    public IActionResult RespuestaHabitacion1(string input)
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        ViewBag.nota = juego.Nota;
        ViewBag.notis = juego.Notificaciones;

        int respuesta = juego.Respuesta(input, 0);
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
        int respuesta = juego.Respuesta(input, 1);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
        if (respuesta == 1)
        {
            return View("arte");
        } else {
            return View("prog");
        }
    }

    [HttpPost]
    public IActionResult RespuestaHabitacion3(string input, int puntaje)
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        int respuesta = juego.Respuesta(input.ToLower(), 2);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        juego.Notificaciones = puntaje;
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
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
        int respuesta = juego.Respuesta(input, 3);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
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
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
        return View("introduccion");
    }
    public IActionResult SSI()
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
        return View("SSI");
    }
    public IActionResult Creditos()
    {
        return View("creditos");
    }

    public IActionResult BD()
    {
        return View("bd");
    }

}

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

        int respuesta = juego.Respuesta(input, 0);
        if (respuesta != 1)
        {
            juego.Nota--;
        }
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
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
        if (respuesta != 1)
        {
            juego.Nota--;
        }
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
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
        input = input.ToLower();
        int respuesta = juego.Respuesta(input, 2);
        if (respuesta != 1)
        {
            juego.Nota--;
        }
        ViewBag.notas = juego.Nota;
        juego.Notificaciones = puntaje;
        ViewBag.notis = juego.Notificaciones;
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
        int respuesta = juego.Respuesta(input, 5);
        if (respuesta != 1)
        {
            juego.Nota--;
        }
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
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
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        return View("introduccion");
    }
    public IActionResult SSI()
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        return View("SSI");
    }
    [HttpGet]
    public IActionResult PreguntaCelular()
    {
        return View();
    }

    [HttpPost]
    public IActionResult PreguntaCelular(string input)
    {
        SalaEscape juego = Objeto.StringToObject<SalaEscape>(HttpContext.Session.GetString("juego"));
        int respuesta = juego.Respuesta(input, 3);
        if (respuesta != 1)
        {
            juego.Nota--;
        }
        ViewBag.notas = juego.Nota;
        ViewBag.notis = juego.Notificaciones;
        HttpContext.Session.SetString("juego", Objeto.ObjectToString<SalaEscape>(juego));
        if (respuesta == 1)
        {
            return View("pantallaCelu");
        } else {
            return View("correcto");
        }
    }
    public IActionResult Creditos()
    {
        return View("creditos");
    }
}

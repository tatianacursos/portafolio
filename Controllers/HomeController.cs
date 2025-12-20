using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Habilidades()
        {
            return View();
        }

        public IActionResult Formacion()
        {
            return View();
        }

        public IActionResult Experiencia()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private readonly IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Hablamos()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto (string Nombre, string Email, string Mensaje)
        {
            string contenido =
                    $@"Nuevo mensaje desde el portfolio:

                    Nombre: {Nombre}
                    Email: {Email}

                    Mensaje:
                    {Mensaje}
                    ";

            await _emailSender.SendEmailAsync("tatiana@villaema.es", "Nuevo mensaje desde tu portfolio", contenido);

            ViewBag.Enviado = true;
            return View();
        }

        /* Ya estaba */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

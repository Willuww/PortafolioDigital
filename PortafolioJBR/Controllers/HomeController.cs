using Microsoft.AspNetCore.Mvc;
using PortafolioJBR.Models;
using System.Diagnostics;

namespace PortafolioJBR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //enviar a la vista el metodo utilitario
            var proyectos = GetPtoyectos().Take(3).ToList();
            var modelo = new HomeIndexVM() { Proyectos = proyectos};
            
            ViewBag.Edad = 25;
            //Regresa la vista Index y el modelo (nombre)
            //return View("Index","Joel Bello Romero");

            //ya que el index ahora recive un VM, el nombre se ha modificado en _Presentacion
            //y aqui puede regresar unicamente el modelo

            return View(modelo);
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

        #region Metodo Utilitario
        private List<Proyecto> GetPtoyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto{ Titulo = "Amazon", Descripcion="E-Commerce desarrollado en Net Core", Link="https://amazon.com", ImagenUrl="/img/Amazon.png"},
                new Proyecto{ Titulo="Reddit", Descripcion="Administracion y Desarrollo de Envio de Mails", Link="https://reddit.com", ImagenUrl="/img/reddit.png"},
                new Proyecto{ Titulo="Mercado Libre", Descripcion="E-Commerce con implementacion de JavaScript", Link="https://mercadolibre.com.mx", ImagenUrl="/img/mercadolibre.jpg"},
                new Proyecto{ Titulo="Microsof", Descripcion="Plataforma de aprendizaje Big-Learn", Link="https://microsoft.com", ImagenUrl="/img/microsoft.jpg"},
            };
        }
        #endregion
    }
}

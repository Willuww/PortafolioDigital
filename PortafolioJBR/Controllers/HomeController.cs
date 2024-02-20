using Microsoft.AspNetCore.Mvc;
using PortafolioJBR.Infraestructura;
using PortafolioJBR.Models;
using PortafolioJBR.Servicios;
using System.Diagnostics;

namespace PortafolioJBR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioServicios _servicios;
        private readonly IServiceEmailSendGrid _serviceEmail; 

        public HomeController(ILogger<HomeController> logger, IRepositorioServicios servicios, IServiceEmailSendGrid serviceEmail)
        {
            _logger = logger;
            _servicios = servicios;
            _serviceEmail = serviceEmail;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Iniciamos la Aplicacion en el log");

            //enviar a la vista el metodo utilitario
            var proyectos = _servicios.GetPtoyectos().Take(3).ToList();
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

        public IActionResult Proyectos() {
            var proyectos =  _servicios.GetPtoyectos();
            return View(proyectos);
            
        }


        [HttpGet]
        public IActionResult Contacto() {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Contacto(ContactoVM contactoVM)
        {
            await _serviceEmail.Enviar(contactoVM);
            return RedirectToAction("Gracias");
        }
        [HttpGet]
        public IActionResult Gracias() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}

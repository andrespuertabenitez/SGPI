using Microsoft.AspNetCore.Mvc;

namespace SGPI.Controllers
{
    public class CoordinadorController : Controller
    {
        //Agrego el de buscar coordinador
        public IActionResult BuscarCoordinador()
        {
            return View();
        }
        //Agrego el de programar coordinador
        public IActionResult ProgramarCoordinador()
        {
            return View();
        }
        //Agrego el de homologacion coordinador
        public IActionResult HomologacionCoordinador()
        {
            return View();
        }
        //Agrego el de entrevistas coordinador
        public IActionResult EntrevistasCoordinador()
        {
            return View();
        }
        //Agrego el de reportes coordinador
        public IActionResult ReportesCoordinador()
        {
            return View();
        }
    }
}

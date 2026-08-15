using inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models;
using Microsoft.AspNetCore.Mvc;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Controllers
{
    public class PropietarioController : Controller
    {    

        private RepositorioPropietario repo = new RepositorioPropietario();
        public IActionResult Index()
        {
            var lista= repo.ObtenerTodos();
            return View(lista);
        }
    public IActionResult Create()
        {
            return View();
        }

     [HttpPost] 
     public IActionResult Create(Propietario propietario)
        {
            if(ModelState.IsValid)
            {    
                repo.Alta(propietario);
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }  
    }
}
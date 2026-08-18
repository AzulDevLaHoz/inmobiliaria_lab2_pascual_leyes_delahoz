using inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models;
using Microsoft.AspNetCore.Mvc;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Controllers
{
    public class PropietarioController : Controller
    {    
        private readonly RepositorioPropietario repositorio;
        public PropietarioController(RepositorioPropietario repositorio)
        {
            this.repositorio = repositorio;
        } 
        public IActionResult Index()
        {
            var lista= repositorio.ObtenerTodos();
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
                repositorio.Alta(propietario);
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }  
    }
}
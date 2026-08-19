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
            var listaFicticia = new List<Propietario>
    {
        new Propietario { IdPropietario = 1, Nombre = "Patricio", Apellido = "Pascual", Telefono = "2664000000", Email = "patricio@mail.com" },
        new Propietario { IdPropietario = 2, Nombre = "Ana", Apellido = "Gómez", Telefono = "2664111111", Email = "ana@mail.com" }
    };

            return View(listaFicticia);
        }
        public IActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                repositorio.Alta(propietario);
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }
    }
}
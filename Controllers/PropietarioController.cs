using inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models;
using Microsoft.AspNetCore.Mvc;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Controllers
{
    public class PropietarioController : Controller
    {
        private readonly IRepositorioPropietario repositorio;
        private readonly IConfiguration config;
        private readonly ILogger<PropietarioController> logger;

        public PropietarioController(IRepositorioPropietario repo, IConfiguration config, ILogger<PropietarioController> logger)
        {
            this.repositorio = repo;
            this.config = config;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            var lista = repositorio.ObtenerLista();
            return View(lista);
        }
        public IActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alta(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                repositorio.Alta(propietario);
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }
        public ActionResult Modificar(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
        }

        [HttpPost]
        public ActionResult Modificar(int id, Propietario entidad)
        {
            var i = repositorio.ObtenerPorId(id);
            if (i == null) return NotFound();

            i.Nombre = entidad.Nombre;
            i.Apellido = entidad.Apellido;
            i.Dni = entidad.Dni;
            i.Email = entidad.Email;
            i.Telefono = entidad.Telefono;
            repositorio.Modificar(i);
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            repositorio.Baja(id);
            return RedirectToAction(nameof(Index));
        }
    }
    

}
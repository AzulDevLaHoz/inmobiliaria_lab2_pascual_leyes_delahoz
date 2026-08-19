using inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models;
using Microsoft.AspNetCore.Mvc;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Controllers
{
    public class InquilinoController : Controller
    {
        private readonly RepositorioInquilino repositorio;

        public InquilinoController(RepositorioInquilino repositorio)
        {
            this.repositorio = repositorio;
        }

        public IActionResult Index()
        {
            //var lista = repositorio.ObtenerTodos();
            var listaFicticia = new List<Inquilino>
           {
               new Inquilino { IdInquilino=1, Nombre="Leandro", Apellido = "Leyes", Telefono="2664580458", Email="leandroleyes60@gmail.com" },
               new Inquilino { IdInquilino=2, Nombre="Azul", Apellido = "De La Hoz", Telefono="26641234567", Email="azuldev@gmail.com" }
           };
            return View(listaFicticia);
        }
        public IActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                repositorio.Alta(inquilino);
                return RedirectToAction(nameof(Index));
            }
            return View(inquilino);
        }
    }
}
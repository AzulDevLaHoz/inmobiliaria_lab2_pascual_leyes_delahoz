using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria_.Net_Core.Models; //no se por que se me importa este using solo al poner la interfaz.

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models
{
    public interface IRepositorioPropietario : IRepositorio<Propietario>
    {
        Propietario? ObtenerPorEmail(string email);
        IList<Propietario> BuscarPorNombre (string nombre);
    }
}
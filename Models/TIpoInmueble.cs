using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models
{

    public class TipoInmueble
    {
        [Key]
        public int IdTipoInmueble { get; set; }

        [Required]
        public String Nombre { get; set; } = "";
       
    }
}

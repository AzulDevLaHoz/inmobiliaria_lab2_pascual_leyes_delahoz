using System;
using System.ComponentModel.DataAnnotations;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models
{
    public class TipoInmueble
    {
        [Key]
        [Display(Name = "")]
        public int Id { get; set;}

        [Required]
        public String? Nombre {get; set;}
    }

}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models
{
public class Inmueble

    {
        [Key]
        [Display(Name = "Código Int.")]
        public int Id {get; set;}

        [Required]
        public String? Direccion {get; set;}

        [Required]
        public int Capacidad {get; set;}

        [Required]
        public Decimal Precio {get; set;}
        public Decimal CoordenadaX {get; set;}
        public Decimal CoordenadaY {get; set;}
        public IFormFile? ImagenPortada {get; set;}
        public String Estado {get; set;}
        
        [ForeignKey(nameof(Propietario.IdPropietario))]
        public Propietario Duenio {get; set;}
        //Aca deberia ir la foreign key de tipoInmueble, pero al no tener model de dicha entidad no la puedo colocar. Consultar.
        
    }
}
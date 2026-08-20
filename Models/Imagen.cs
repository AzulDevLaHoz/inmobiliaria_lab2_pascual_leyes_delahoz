using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models
{

    public class Imagen
    {
        [Key]
        public int IdImagen { get; set; }

        [Display(Name = "Imagen Portada")]
        public string ImagenPortada { get; set; } = "";
    
 // --- Relación con Inmueble ---
    [Required]
    [ForeignKey(nameof(Inmueble))]
    public int IdInmueble { get; set; 
    }
}
}

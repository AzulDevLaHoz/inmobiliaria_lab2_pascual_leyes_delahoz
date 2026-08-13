using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models
{

    public class Inquilino
    {
        [Key]
        [Display(Name = "Código Int.")]
        public int idInquilino { get; set; }

        [Required]
        public String Nombre { get; set; } = "";
        [Required]
        public String Apellido { get; set; } = "";
        [Display(Name = "telefono")]
        public String Telefono { get; set; } = "";
        [Required, EmailAddress]
        public String Email { get; set; } = "";

    }
}
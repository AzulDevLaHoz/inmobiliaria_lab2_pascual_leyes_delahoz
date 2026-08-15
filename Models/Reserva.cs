using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models

{
   public class Reserva{
    [Key]
    public int IdReserva { get; set; }

    [Required]
    public decimal MontoDia { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaOriginalMulta { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaEntrada { get; set; } // la pactada al crear la reserva

    // Nullable (el "?") porque solo se completa SI la reserva terminó antes de tiempo
    [DataType(DataType.Date)]
    public DateTime? FechaSalida { get; set; }

    [Required]
    public Boolean Estado { get; set; } = false;

    // --- Relación con Inquilino ---
    [Required]
    [ForeignKey(nameof(Inquilino))]
    public int IdInquilino { get; set; }

    // --- Relación con Inmueble ---
    [Required]
    [ForeignKey(nameof(Inmueble))]
    public int IdInmueble { get; set; }
}
}
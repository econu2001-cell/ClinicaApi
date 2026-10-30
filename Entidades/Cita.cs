
using System.ComponentModel.DataAnnotations;

namespace ClinicaApi.Entidades
{
    public class Cita
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Seleccione un paciente válido")]
        public int PacienteId { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Seleccione un médico válido")]
        public int MedicoId { get; set; }

        [Required(ErrorMessage = "La fecha y hora son obligatorias")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El motivo de la cita es obligatorio")]
        [StringLength(200, MinimumLength = 3,
            ErrorMessage = "El motivo debe tener entre 3 y 200 caracteres")]
        public string Motivo { get; set; } = string.Empty;

        public string Estado { get; set; } = "Programada";
    }
}

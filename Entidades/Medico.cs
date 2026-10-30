
using System.ComponentModel.DataAnnotations;

namespace ClinicaApi.Entidades
{
    public class Medico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del médico es obligatorio")]
        [StringLength(50, MinimumLength = 2)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        public string Especialidad { get; set; } = string.Empty;
    }
}

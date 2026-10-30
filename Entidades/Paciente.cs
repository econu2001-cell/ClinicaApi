
using System.ComponentModel.DataAnnotations;

namespace ClinicaApi.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del paciente es obligatorio")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [RegularExpression(@"^\d{8}$",
            ErrorMessage = "El DNI debe contener 8 números")]
        public string Dni { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        public string Email { get; set; } = string.Empty;
    }
}

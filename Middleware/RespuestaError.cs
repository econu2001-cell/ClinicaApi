
namespace ClinicaApi.Middleware
{
    // Clase que define un formato uniforme para las respuestas de error en JSON.
    public class RespuestaError
    {
        // Guarda el código de estado HTTP, por ejemplo, 400.
        public int CodigoEstado { get; set; }

        // Guarda el mensaje que explica el error ocurrido.
        public string Mensaje { get; set; } = string.Empty;

        // Guarda la ruta del endpoint donde ocurrió el error.
        public string Ruta { get; set; } = string.Empty;
    }
}


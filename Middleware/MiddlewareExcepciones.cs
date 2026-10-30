
using System.Net; // Permite utilizar los códigos de estado HTTP.
using System.Text.Json; // Permite convertir objetos a formato JSON.
using ClinicaApi.Middleware; // Importa la clase RespuestaError.

namespace ClinicaApi.Middlewares
{
    public class MiddlewareExcepciones
    {
        // RequestDelegate representa el siguiente componente de la canalización HTTP.
        private readonly RequestDelegate _siguiente;

        // Constructor que recibe el siguiente componente que procesará la petición.
        public MiddlewareExcepciones(RequestDelegate siguiente)
        {
            _siguiente = siguiente; // Guarda el componente recibido.
        }

        // Ejecuta de forma asíncrona el procesamiento de cada petición HTTP.
        public async Task InvokeAsync(HttpContext contexto)
        {
            try
            {
                // Permite que la petición continúe hacia el controlador correspondiente.
                await _siguiente(contexto);
            }
            catch (Exception ex)
            {
                // Captura las excepciones no controladas de los componentes posteriores.
                await ManejarErroresAsync(contexto, ex);
            }
        }

        // Centraliza la construcción de la respuesta cuando ocurre una excepción.
        private static Task ManejarErroresAsync(HttpContext contexto, Exception excepcion)
        {
            // Indica que la respuesta se enviará en formato JSON.
            contexto.Response.ContentType = "application/json";

            // Establece el código HTTP 400 Bad Request, siguiendo el ejemplo de clase.
            contexto.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            // Construye el objeto con el formato uniforme de error.
            var respuesta = new RespuestaError
            {
                // Incluye el código de estado HTTP.
                CodigoEstado = contexto.Response.StatusCode,

                // Incluye el mensaje de la excepción capturada.
                Mensaje = excepcion.Message,

                // Incluye la ruta solicitada por el cliente.
                Ruta = contexto.Request.Path
            };

            // Convierte el objeto de respuesta en una cadena JSON.
            var json = JsonSerializer.Serialize(respuesta);

            // Envía el JSON al cliente, por ejemplo, Postman.
            return contexto.Response.WriteAsync(json);
        }
    }
}

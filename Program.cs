
using ClinicaApi.Servicios;
using ClinicaApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar los servicios
builder.Services.AddControllers();
builder.Services.AddSingleton<CitaService>();

// 2. Configurar OpenAPI
builder.Services.AddOpenApi();

// 3. Construir la aplicación
var app = builder.Build();

// 4. Configurar el manejo de peticiones HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<MiddlewareExcepciones>();

// 5. Activar los controladores
app.MapControllers();

// 6. Iniciar la aplicación
app.Run();

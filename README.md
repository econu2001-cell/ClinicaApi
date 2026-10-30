# ClinicaApi — API REST para la gestión de citas médicas

## 1. Descripción del proyecto

ClinicaApi es una API REST desarrollada en C# con ASP.NET Core para gestionar citas médicas de una clínica privada.

El proyecto permite registrar, consultar, actualizar y eliminar citas médicas. También utiliza validaciones mediante DataAnnotations y un middleware para centralizar el manejo de excepciones.

## 2. Objetivo

Implementar un servicio web que facilite la gestión de citas médicas mediante peticiones HTTP, aplicando una estructura organizada por controladores, entidades, DTO y servicios.

## 3. Tecnologías utilizadas

- C#
- ASP.NET Core Web API
- .NET SDK compatible con el archivo `ClinicaApi.csproj`
- Visual Studio Code
- Git y GitHub
- Postman para probar los endpoints

## 4. Estructura del proyecto

```text
ClinicaApi/
├── Controllers/
│   └── CitasController.cs
├── Dto/
│   └── CitaDto.cs
├── Entidades/
│   ├── Cita.cs
│   ├── Medico.cs
│   └── Paciente.cs
├── Middleware/
│   ├── MiddlewareExcepciones.cs
│   └── RespuestaError.cs
├── Properties/
├── Servicios/
│   └── CitaService.cs
├── .gitignore
├── ClinicaApi.csproj
├── ClinicaApi.http
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
```

## 5. Funcionalidades principales

- Registrar una cita médica.
- Consultar todas las citas.
- Consultar una cita por su identificador.
- Actualizar una cita existente.
- Eliminar una cita.
- Validar los datos recibidos.
- Gestionar las excepciones mediante un middleware personalizado.

## 6. Responsabilidad de cada componente

### Controllers

`CitasController.cs` recibe las peticiones HTTP y devuelve las respuestas correspondientes al cliente.

### Entidades

- `Cita.cs`: representa una cita médica.
- `Paciente.cs`: representa los datos de un paciente.
- `Medico.cs`: representa los datos de un médico.

### DTO

`CitaDto.cs` define los datos que se reciben al registrar o actualizar una cita.

### Servicios

`CitaService.cs` contiene la lógica para crear, consultar, actualizar y eliminar citas.

### Middleware

- `MiddlewareExcepciones.cs`: captura excepciones producidas durante el procesamiento de las peticiones.
- `RespuestaError.cs`: define la estructura JSON utilizada para responder a los errores.

### Program.cs

Configura los servicios, el middleware y las rutas de los controladores.

## 7. Requisitos previos

Para ejecutar el proyecto se necesita:

- Tener instalado el .NET SDK compatible con el framework indicado en `ClinicaApi.csproj`.
- Tener instalado Visual Studio Code o utilizar una terminal.
- Tener Git instalado si se desea clonar el repositorio.

## 8. Cómo ejecutar el proyecto

### Paso 1. Clonar el repositorio

```bash
git clone https://github.com/econu2001-cell/ClinicaApi.git
```

### Paso 2. Ingresar a la carpeta

```bash
cd ClinicaApi
```

### Paso 3. Restaurar las dependencias

```bash
dotnet restore
```

### Paso 4. Ejecutar la API

```bash
dotnet run
```

La terminal mostrará la dirección local en la que se ejecuta la aplicación. Utiliza el puerto que aparezca en tu propia terminal.

En las pruebas realizadas durante el desarrollo se utilizó:

`http://localhost:5192`

## 9. Endpoints disponibles

La ruta base de los endpoints de citas es `/api/citas`.

| Método HTTP | Endpoint | Descripción | Respuesta esperada |
|---|---|---|---|
| GET | `/api/citas` | Consultar todas las citas | 200 OK |
| GET | `/api/citas/{id}` | Consultar una cita por ID | 200 OK o 404 Not Found |
| POST | `/api/citas` | Registrar una cita | 201 Created |
| PUT | `/api/citas/{id}` | Actualizar una cita | 204 No Content o 404 Not Found |
| DELETE | `/api/citas/{id}` | Eliminar una cita | 204 No Content o 404 Not Found |

## 10. Ejemplo para registrar una cita

En Postman, seleccionar el método `POST` y utilizar la ruta:

`http://localhost:5192/api/citas`

Seleccionar **Body → raw → JSON** y enviar:

```json
{
  "pacienteId": 1,
  "medicoId": 1,
  "fechaHora": "2026-11-02T10:00:00",
  "motivo": "Consulta general"
}
```

Si la solicitud es válida, la API devuelve el código `201 Created` y los datos de la cita creada, incluido su identificador y el estado inicial.

## 11. Ejemplo para actualizar una cita

Seleccionar `PUT` y utilizar:

`http://localhost:5192/api/citas/1`

Enviar en el cuerpo JSON:

```json
{
  "pacienteId": 1,
  "medicoId": 1,
  "fechaHora": "2026-11-03T15:30:00",
  "motivo": "Control médico"
}
```

Si la cita existe y los datos son válidos, la API responde `204 No Content`.

## 12. Validaciones y manejo de errores

El proyecto utiliza DataAnnotations, entre ellas:

- `[Required]`: exige que se proporcione un dato.
- `[Range]`: restringe los valores numéricos permitidos.
- `[StringLength]`: limita la longitud de una cadena.
- `[EmailAddress]`: valida el formato de un correo electrónico.
- `[RegularExpression]`: valida un dato mediante una expresión regular.

El middleware personalizado captura excepciones y devuelve una respuesta JSON con el código de estado, el mensaje y la ruta de la petición.

## 13. Almacenamiento de datos

En esta versión, las citas se almacenan en una lista en memoria. No se utiliza una base de datos.

Por este motivo, los registros pueden perderse cuando la aplicación se reinicia. Los identificadores de pacientes y médicos se validan numéricamente, pero todavía no se comprueba que correspondan a pacientes y médicos registrados.

## 14. Pruebas realizadas

Durante las pruebas con Postman se verificaron las siguientes operaciones:

- Registro de citas mediante POST.
- Consulta de citas mediante GET.
- Consulta de una cita por identificador.
- Actualización mediante PUT.
- Eliminación mediante DELETE.
- Comprobación de la respuesta 404 al consultar una cita eliminada.
- Prueba del middleware mediante una excepción controlada que devuelve una respuesta JSON con código 400.

El endpoint temporal de prueba de excepciones no forma parte de las operaciones CRUD principales y debe mantenerse únicamente para pruebas controladas.

## 15. Repositorio en GitHub

Repositorio del proyecto:

https://github.com/econu2001-cell/ClinicaApi

## 16. Integrantes y responsabilidades

Completar esta sección con los nombres reales de los tres integrantes y las tareas que efectivamente realizó cada uno.

-------INTEGRANTES------

-Abad Gonza Mister
-Córdova Nuñez Eddi
-Ventura Mori Carlos


## 17. Conclusión

ClinicaApi permite aplicar los conceptos fundamentales del desarrollo de servicios web REST con ASP.NET Core, incluyendo operaciones CRUD, validación de datos, separación de responsabilidades y manejo centralizado de excepciones.

El proyecto constituye una base para futuras mejoras, como la integración de una base de datos y la validación de la existencia de pacientes y médicos.

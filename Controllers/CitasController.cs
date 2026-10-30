
using ClinicaApi.Dto;
using ClinicaApi.Entidades;
using ClinicaApi.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    [ApiController]
    [Route("api/citas")]
    public class CitasController : ControllerBase
    {
        private readonly CitaService _servicio;

        public CitasController(CitaService servicio)
        {
            _servicio = servicio;
        }

        // GET: api/citas
        [HttpGet]
        public ActionResult<List<Cita>> Get()
        {
            return Ok(_servicio.ObtenerTodas());
        }

        // GET: api/citas/1
        [HttpGet("{id:int}")]
        public ActionResult<Cita> Get(int id)
        {
            var cita = _servicio.ObtenerPorId(id);

            if (cita == null)
            {
                return NotFound($"La cita con ID {id} no existe.");
            }

            return Ok(cita);
        }

        // POST: api/citas
        [HttpPost]
        public ActionResult<Cita> Post(CitaDto dto)
        {
            var nuevaCita = new Cita
            {
                PacienteId = dto.PacienteId,
                MedicoId = dto.MedicoId,
                FechaHora = dto.FechaHora,
                Motivo = dto.Motivo
            };

            var citaCreada = _servicio.Crear(nuevaCita);

            return CreatedAtAction(
                nameof(Get),
                new { id = citaCreada.Id },
                citaCreada
            );
        }

        // PUT: api/citas/1
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, CitaDto dto)
        {
            var citaActualizada = new Cita
            {
                PacienteId = dto.PacienteId,
                MedicoId = dto.MedicoId,
                FechaHora = dto.FechaHora,
                Motivo = dto.Motivo
            };

            var actualizado = _servicio.Actualizar(id, citaActualizada);

            if (!actualizado)
            {
                return NotFound($"La cita con ID {id} no existe.");
            }

            return NoContent();
        }

        // DELETE: api/citas/1
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var eliminado = _servicio.Eliminar(id);

            if (!eliminado)
            {
                return NotFound($"La cita con ID {id} no existe.");
            }

            return NoContent();
        }

        
    // ENDPOINT PARA PROBAR EL MIDDLEWARE
    [HttpGet("prueba-error")]
    public IActionResult PruebaError()
    {
        throw new Exception("Error de prueba del middleware");
    }



    }

          



}


using ClinicaApi.Entidades;

namespace ClinicaApi.Servicios
{
    public class CitaService
    {
        private static readonly List<Cita> _listaCitas = new();

        private static int _siguienteId = 1;

        public List<Cita> ObtenerTodas()
        {
            return _listaCitas;
        }

        public Cita? ObtenerPorId(int id)
        {
            return _listaCitas.FirstOrDefault(c => c.Id == id);
        }

        public Cita Crear(Cita cita)
        {
            cita.Id = _siguienteId++;
            cita.Estado = "Programada";

            _listaCitas.Add(cita);

            return cita;
        }

        public bool Actualizar(int id, Cita cita)
        {
            var citaExistente = ObtenerPorId(id);

            if (citaExistente == null)
            {
                return false;
            }

            citaExistente.PacienteId = cita.PacienteId;
            citaExistente.MedicoId = cita.MedicoId;
            citaExistente.FechaHora = cita.FechaHora;
            citaExistente.Motivo = cita.Motivo;

            return true;
        }

        public bool Eliminar(int id)
        {
            var cita = ObtenerPorId(id);

            if (cita == null)
            {
                return false;
            }

            _listaCitas.Remove(cita);

            return true;
        }
    }
}

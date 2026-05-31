
namespace GestionCitasMedicas.Entidades
{
    public class Cita
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public DateTime FechaHora { get; set; }
        public EstadoCita Estado { get; set; }

    }
}

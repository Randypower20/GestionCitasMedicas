
using GestionCitasMedicas.Entidades;

namespace GestionCitasMedicas.Servicios
{
    public class PacienteService
    {
        private List<Paciente> pacientes = new List<Paciente>();

        public void Registrar(Paciente paciente)
        {
            pacientes.Add(paciente);
        }

        public List<Paciente> ObtenerTodos()
        {
            return pacientes;
        }

        public Paciente BuscarPorId(int id)
        {
            foreach (Paciente paciente in pacientes)
            {
                if (paciente.Id == id)
                {
                    return paciente;
                }
            }

            return null;
        }
    }

}


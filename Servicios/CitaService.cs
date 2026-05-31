using System.Collections.Generic;
using GestionCitasMedicas.Entidades;

namespace GestionCitasMedicas.Servicios
{
    public class CitaService
    {
        private List<Cita> citas = new List<Cita>();

        public bool RegistrarCita(Cita cita)
        {
            if (!MedicoDisponible(cita.Medico, cita.FechaHora))
            {
                return false;
            }

            cita.Estado = EstadoCita.Programada;
            citas.Add(cita);

            return true;
        }

        public void CancelarCita(int id)
        {
            foreach (Cita cita in citas)
            {
                if (cita.Id == id)
                {
                    cita.Estado = EstadoCita.Cancelada;
                    break;
                }
            }
        }

        public bool ReprogramarCita(int id, DateTime nuevaFecha)
        {
            foreach (Cita cita in citas)
            {
                if (cita.Id == id)
                {
                    if (!MedicoDisponible(cita.Medico, nuevaFecha))
                    {
                        return false;
                    }

                    cita.FechaHora = nuevaFecha;
                    return true;
                }
            }

            return false;
        }

        public List<Cita> ConsultarCitasPorPaciente(int pacienteId)
        {
            List<Cita> resultado = new List<Cita>();

            foreach (Cita cita in citas)
            {
                if (cita.Paciente.Id == pacienteId)
                {
                    resultado.Add(cita);
                }
            }

            return resultado;
        }

        public List<Cita> ConsultarCitasPorMedico(int medicoId)
        {
            List<Cita> resultado = new List<Cita>();

            foreach (Cita cita in citas)
            {
                if (cita.Medico.Id == medicoId)
                {
                    resultado.Add(cita);
                }
            }

            return resultado;
        }

        public List<Cita> ObtenerTodasLasCitas()
        {
            return citas;
        }

        private bool MedicoDisponible(Medico medico, DateTime fechaHora)
        {
            foreach (Cita cita in citas)
            {
                if (cita.Medico.Id == medico.Id &&
                    cita.FechaHora == fechaHora &&
                    cita.Estado != EstadoCita.Cancelada)
                {
                    return false;
                }
            }

            return true;
        }
        public Cita BuscarPorId(int id)
        {
            foreach (Cita cita in citas)
            {
                if (cita.Id == id)
                {
                    return cita;
                }
            }

            return null;
        }

    }
}


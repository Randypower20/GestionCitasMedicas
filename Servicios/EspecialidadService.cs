using GestionCitasMedicas.Entidades;
using System.Collections.Generic;

namespace GestionCitasMedicas.Servicios
{
    public class EspecialidadService
    {
        private List<Especialidad> especialidades = new List<Especialidad>();

        public void Registrar(Especialidad especialidad)
        {
            especialidades.Add(especialidad);
        }

        public List<Especialidad> ObtenerTodas()
        {
            return especialidades;
        }

        public Especialidad BuscarPorId(int id)
        {
            foreach (Especialidad especialidad in especialidades)
            {
                if (especialidad.Id == id)
                {
                    return especialidad;
                }
            }

            return null;
        }


    }
}
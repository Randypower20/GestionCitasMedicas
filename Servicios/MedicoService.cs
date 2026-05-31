using GestionCitasMedicas.Entidades;
namespace GestionCitasMedicas.Servicios

{
    public class MedicoService
    {

        private List<Medico> medicos = new List<Medico>();

        public void Registrar(Medico medico)
        {
            medicos.Add(medico);
        }

        public List<Medico> ObtenerTodos()
        {
            return medicos;
        }
        
    public Medico BuscarPorId(int id)
        {
            foreach (Medico medico in medicos)
            {
                if (medico.Id == id)
                {
                    return medico;
                }
            }

            return null;
        }

    }
}


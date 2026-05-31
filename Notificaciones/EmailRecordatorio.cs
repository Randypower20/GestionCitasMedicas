using GestionCitasMedicas.Entidades;
using GestionCitasMedicas.Interfaces;


namespace GestionCitasMedicas.Notificaciones
{
    public class EmailRecordatorio: IRecordatorio
    {
        public void Enviar(Cita cita)
        {
            Console.WriteLine();
            Console.WriteLine("Correo enviado a " + cita.Paciente.Nombre);
        }


    }
}

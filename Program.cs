using GestionCitasMedicas.Entidades;
using GestionCitasMedicas.Servicios;
using GestionCitasMedicas.Interfaces;
using GestionCitasMedicas.Notificaciones;
namespace GestionCitasMedicas
{
    public class Program
    {
        static void Main(string[] args)
        {
            PacienteService pacienteService = new PacienteService();
            MedicoService medicoService = new MedicoService();
            EspecialidadService especialidadService = new EspecialidadService();
            CitaService citaService = new CitaService();

            IRecordatorio recordatorio = new EmailRecordatorio();

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.WriteLine("===== SISTEMA DE CITAS =====");
                Console.WriteLine("1. Pacientes");
                Console.WriteLine("2. Especialidades");
                Console.WriteLine("3. Medicos");
                Console.WriteLine("4. Citas");
                Console.WriteLine("0. Salir");

                switch (Console.ReadLine())
                {
                    case "1":
                        GestionarPacientes(pacienteService);
                        break;

                    case "2":
                        GestionarEspecialidades(especialidadService);
                        break;

                    case "3":
                        GestionarMedicos(medicoService, especialidadService);
                        break;

                    case "4":
                        GestionarCitas(
                            citaService,
                            pacienteService,
                            medicoService,
                            recordatorio);
                        break;

                    case "0":
                        continuar = false;
                        break;
                }
            }
        }

        static void GestionarPacientes(PacienteService pacienteService)
        {
            Console.Clear();

            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Ver todos");

            switch (Console.ReadLine())
            {
                case "1":

                    Paciente paciente = new Paciente();

                    Console.Write("Id: ");
                    paciente.Id = int.Parse(Console.ReadLine());

                    Console.Write("Nombre: ");
                    paciente.Nombre = Console.ReadLine();

                    Console.Write("Telefono: ");
                    paciente.Telefono = Console.ReadLine();

                    Console.Write("Correo: ");
                    paciente.Correo = Console.ReadLine();

                    pacienteService.Registrar(paciente);

                    break;

                case "2":

                    foreach (Paciente p in pacienteService.ObtenerTodos())
                    {
                        Console.WriteLine($"{p.Id} - {p.Nombre}");
                    }

                    Console.ReadKey();
                    break;
            }
        }

        static void GestionarEspecialidades(EspecialidadService especialidadService)
        {
            Console.Clear();

            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Ver todas");

            switch (Console.ReadLine())
            {
                case "1":

                    Especialidad especialidad = new Especialidad();

                    Console.Write("Id: ");
                    especialidad.Id = int.Parse(Console.ReadLine());

                    Console.Write("Nombre: ");
                    especialidad.Nombre = Console.ReadLine();

                    especialidadService.Registrar(especialidad);

                    break;

                case "2":

                    foreach (Especialidad e in especialidadService.ObtenerTodas())
                    {
                        Console.WriteLine($"{e.Id} - {e.Nombre}");
                    }

                    Console.ReadKey();
                    break;
            }
        }

        static void GestionarMedicos(
            MedicoService medicoService,
            EspecialidadService especialidadService)
        {
            Console.Clear();

            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Ver todos");

            switch (Console.ReadLine())
            {
                case "1":

                    Medico medico = new Medico();

                    Console.Write("Id: ");
                    medico.Id = int.Parse(Console.ReadLine());

                    Console.Write("Nombre: ");
                    medico.Nombre = Console.ReadLine();

                    Console.Write("Id Especialidad: ");
                    int idEspecialidad = int.Parse(Console.ReadLine());

                    medico.Especialidad =
                        especialidadService.BuscarPorId(idEspecialidad);

                    medicoService.Registrar(medico);

                    break;

                case "2":

                    foreach (Medico m in medicoService.ObtenerTodos())
                    {
                        Console.WriteLine($"{m.Id} - {m.Nombre}");
                    }

                    Console.ReadKey();
                    break;
            }
        }

        static void GestionarCitas(
            CitaService citaService,
            PacienteService pacienteService,
            MedicoService medicoService,
            IRecordatorio recordatorio)
        {
            Console.Clear();

            Console.WriteLine("1. Agendar");
            Console.WriteLine("2. Consultar por paciente");
            Console.WriteLine("3. Consultar por medico");
            Console.WriteLine("4. Cancelar");
            Console.WriteLine("5. Reprogramar");
            Console.WriteLine("6. Recordatorio");

            switch (Console.ReadLine())
            {
                case "1":

                    Cita cita = new Cita();

                    Console.Write("Id: ");
                    cita.Id = int.Parse(Console.ReadLine());

                    Console.Write("Id Paciente: ");
                    cita.Paciente =
                        pacienteService.BuscarPorId(
                            int.Parse(Console.ReadLine()));

                    Console.Write("Id Medico: ");
                    cita.Medico =
                        medicoService.BuscarPorId(
                            int.Parse(Console.ReadLine()));

                    Console.Write("Fecha: ");
                    cita.FechaHora =
                        DateTime.Parse(Console.ReadLine());

                    citaService.RegistrarCita(cita);

                    break;

                case "2":

                    foreach (Cita c in citaService
                        .ConsultarCitasPorPaciente(
                            int.Parse(Console.ReadLine())))
                    {
                        Console.WriteLine($"{c.Id} - {c.FechaHora}");
                    }

                    Console.ReadKey();
                    break;

                case "3":

                    foreach (Cita c in citaService
                        .ConsultarCitasPorMedico(
                            int.Parse(Console.ReadLine())))
                    {
                        Console.WriteLine($"{c.Id} - {c.FechaHora}");
                    }

                    Console.ReadKey();
                    break;

                case "4":

                    citaService.CancelarCita(
                        int.Parse(Console.ReadLine()));

                    break;

                case "5":

                    Console.Write("Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Nueva fecha: ");
                    DateTime fecha =
                        DateTime.Parse(Console.ReadLine());

                    citaService.ReprogramarCita(id, fecha);

                    break;

                case "6":

                    Cita citaRecordatorio =
                        citaService.BuscarPorId(
                            int.Parse(Console.ReadLine()));

                    if (citaRecordatorio != null)
                    {
                        recordatorio.Enviar(citaRecordatorio);
                    }

                    Console.ReadKey();
                    break;
            }
        }
    }
}


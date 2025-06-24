
namespace ClinicaPopular
{
    // HOLA UEA - ESTRUCTURAS DE DATOS - TRABAJO PRACTICO 01

    public class Paciente
    {
        public string Nombre { get; set; }
        public string ID { get; set; }

        public Paciente(string id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }
    }

    public class Turno
    {
        public Paciente Paciente { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }

        public override string ToString() =>
            $"{FechaHora:G} - {Paciente.Nombre} ({Paciente.ID}) - {Motivo}";
    }

    public class AgendaTurnos
    {
        private Turno[] turnos;
        private int contador;

        public AgendaTurnos(int capacidad = 10)
        {
            turnos = new Turno[capacidad];
            contador = 0;
        }

        public bool AgregarTurno(Turno t)
        {
            if (contador >= turnos.Length) return false;
            foreach (var ex in turnos)
                if (ex != null && ex.FechaHora == t.FechaHora)
                    return false;
            turnos[contador++] = t;
            return true;
        }

        public bool CancelarTurno(int indice)
        {
            if (indice < 0 || indice >= contador) return false;
            for (int i = indice; i < contador - 1; i++)
                turnos[i] = turnos[i + 1];
            turnos[--contador] = null;
            return true;
        }

        public void MostrarTurnos()
        {
            if (contador == 0)
                Console.WriteLine("No hay turnos agendados.");
            else
                for (int i = 0; i < contador; i++)
                    Console.WriteLine($"{i}: {turnos[i]}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("HOLA UEA");
            Console.WriteLine("ESTRUCTURAS DE DATOS");
            Console.WriteLine("TRABAJO PRACTICO 01\n");

            AgendaTurnos agenda = new AgendaTurnos(10);

            Console.WriteLine("Agendando 10 turnos en Clínica Popular:\n");
            for (int i = 1; i <= 10; i++)
            {
                var p = new Paciente($"P{i:00}", $"Paciente {i}");
                var t = new Turno
                {
                    Paciente = p,
                    FechaHora = DateTime.Today.AddHours(9 + i),
                    Motivo = $"Consulta general #{i}"
                };
                bool ok = agenda.AgregarTurno(t);
                Console.WriteLine(ok ? $"Agendado: {t}" : $"No se pudo agendar turno para {p.Nombre}");
            }

            Console.WriteLine("\nTurnos actuales:");
            agenda.MostrarTurnos();

            Console.WriteLine("\nCancelando turno con índice 4...");
            agenda.CancelarTurno(4);

            Console.WriteLine("\nTurnos actualizados:");
            agenda.MostrarTurnos();

            Console.WriteLine("\nPresione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}

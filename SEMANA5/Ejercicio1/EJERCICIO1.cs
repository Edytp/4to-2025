using System;
using System.Collections.Generic;

namespace MiCursoApp
{
    public class Curso
    {
        public List<string> Asignaturas { get; }

        public Curso(IEnumerable<string> asignaturasIniciales)
        {
            Asignaturas = new List<string>(asignaturasIniciales);
        }

        public void MostrarAsignaturas()
        {
            Console.WriteLine("Las asignaturas del curso son:");
            foreach (var asignatura in Asignaturas)
            {
                Console.WriteLine($"- {asignatura}");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var curso = new Curso(new[]
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            });

            curso.MostrarAsignaturas();

            Console.WriteLine("UNIVERSIDAD UEA");
            Console.ReadKey();
        }
    }
}






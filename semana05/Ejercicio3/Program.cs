using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Crear lista de asignaturas
        List<string> asignaturas = new List<string>
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };

        // 2. Crear diccionario para notas
        Dictionary<string, double> notas = new Dictionary<string, double>();

        // 3. Pedir al usuario la nota de cada asignatura
        foreach (string materia in asignaturas)
        {
            Console.Write($"Nota obtenida en {materia}: ");
            string? entrada = Console.ReadLine();

            if (entrada == null || !double.TryParse(entrada, out double nota) || nota < 0 || nota > 10)
            {
                Console.WriteLine("Nota no válida. Usa un número entre 0 y 10. Se vuelve a solicitar.");
                // Solicitar de nuevo la misma asignatura
                materiarepeat:
                Console.Write($"Nota obtenida en {materia}: ");
                entrada = Console.ReadLine();
                if (entrada == null || !double.TryParse(entrada, out nota) || nota < 0 || nota > 10)
                {
                    Console.WriteLine("Entrada inválida de nuevo. Se asigna 0 automáticamente.");
                    nota = 0;
                }
                notas[materia] = nota;
                continue;
            }

            notas[materia] = nota;
        }

        // 4. Filtrar asignaturas reprobadas
        List<string> porRepetir = new List<string>();

        foreach (var kvp in notas)
        {
            if (kvp.Value < 5.0)
                porRepetir.Add(kvp.Key);
        }

        // 5. Mostrar resultado
        Console.WriteLine("\nAsignaturas que debes repetir:");
        if (porRepetir.Count > 0)
        {
            foreach (string mat in porRepetir)
                Console.WriteLine("- " + mat);
        }
        else
        {
            Console.WriteLine("¡En hora buena! Todo aprobado.");
        }
    }
}

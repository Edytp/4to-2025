using System;
using System.Collections.Generic;
using System.Linq;

class Programa
{
    static void Main()
    {
        const int totalCiudadanos = 500;
        const int numPfizer = 75;
        const int numAstra = 75;

        // Generar la lista de ciudadanos del 1 al 500
        HashSet<int> ciudadanos = new HashSet<int>(Enumerable.Range(1, totalCiudadanos));

        Random rnd = new Random();

        // Seleccionar vacunados con Pfizer
        HashSet<int> pfizer = new HashSet<int>();
        while (pfizer.Count < numPfizer)
        {
            int id = rnd.Next(1, totalCiudadanos + 1);
            pfizer.Add(id);
        }

        // Seleccionar vacunados con AstraZeneca
        HashSet<int> astra = new HashSet<int>();
        while (astra.Count < numAstra)
        {
            int id = rnd.Next(1, totalCiudadanos + 1);
            astra.Add(id);
        }

        // Ciudadanos con ambas dosis (intersección)
        HashSet<int> ambas = new HashSet<int>(pfizer);
        ambas.IntersectWith(astra);

        // Ciudadanos solo Pfizer (sin AstraZeneca)
        HashSet<int> soloPfizer = new HashSet<int>(pfizer);
        soloPfizer.ExceptWith(astra);

        // Ciudadanos solo AstraZeneca (sin Pfizer)
        HashSet<int> soloAstra = new HashSet<int>(astra);
        soloAstra.ExceptWith(pfizer);

        // Ciudadanos no vacunados: todos menos cualquiera vacunado
        HashSet<int> vacunados = new HashSet<int>(pfizer);
        vacunados.UnionWith(astra);
        HashSet<int> noVacunados = new HashSet<int>(ciudadanos);
        noVacunados.ExceptWith(vacunados);

        // Mostrar resultados
        Console.WriteLine($" Ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($" Ciudadanos con ambas dosis: {ambas.Count}");
        Console.WriteLine($" Ciudadanos solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($" Ciudadanos solo AstraZeneca: {soloAstra.Count}");
        Console.WriteLine();

        // Opcional: imprimir algunas IDs como ejemplo
        Console.WriteLine("Ejemplos de IDs:");
        Console.WriteLine($" - No vacunados (primeros 10): {string.Join(", ", noVacunados.Take(10))}");
        Console.WriteLine($" - Ambas dosis (todos): {string.Join(", ", ambas)}");
        Console.WriteLine($" - Solo Pfizer (primeros 10): {string.Join(", ", soloPfizer.Take(10))}");
        Console.WriteLine($" - Solo AstraZeneca (primeros 10): {string.Join(", ", soloAstra.Take(10))}");
    }
}


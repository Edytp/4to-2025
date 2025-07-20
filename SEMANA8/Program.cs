
using System;
using System.Collections.Generic;

class ParqueDiversiones
{
    static void Main()
    {
        const int totalAsientos = 30;
        Queue<string> cola = new Queue<string>();

        Console.WriteLine("Registro de personas en la cola para la atracción");
        Console.WriteLine($"(ingresa nombres; escribe 'FIN' para terminar o presiona ENTER tras ingresar {totalAsientos})");

        // Ingreso dinámico de personas
        while (cola.Count < totalAsientos)
        {
            Console.Write($"Nombre persona {cola.Count + 1}: ");
            string nombre = Console.ReadLine()?.Trim();
            if (string.Equals(nombre, "FIN", StringComparison.OrdinalIgnoreCase))
                break;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Nombre inválido. Intenta nuevamente.");
                continue;
            }
            cola.Enqueue(nombre);  // Encola cada persona
        }

        Console.WriteLine("\nAsignación de asientos desde la cola:");

        int asiento = 1;
        while (asiento <= totalAsientos && cola.Count > 0)
        {
            string persona = cola.Dequeue();  // Extrae la persona en orden FIFO
            Console.WriteLine($"Asiento {asiento}: {persona}");
            asiento++;
        }

        int asignados = asiento - 1;
        int libres = totalAsientos - asignados;

        Console.WriteLine("\n--- Resumen final ---");
        Console.WriteLine($"Asientos totales       : {totalAsientos}");
        Console.WriteLine($"Asientos asignados     : {asignados}");
        Console.WriteLine($"Asientos libres        : {libres}");

        if (libres > 0)
        {
            Console.WriteLine($"\nAsiento libre: {libres}");
        }

        if (cola.Count > 0)
        {
            Console.WriteLine($"\nPersonas sin asiento:");
            foreach (var p in cola)
                Console.WriteLine($"· {p}");
        }
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var numeros = new List<int>();
        Console.Write("¿Cuántos números ganadores desea ingresar? ");
        string? cantStr = Console.ReadLine();

        if (cantStr == null || !int.TryParse(cantStr, out int cantidad) || cantidad <= 0)
        {
            Console.WriteLine("Cantidad inválida.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write($"Ingrese el número {i + 1}: ");
            string? ent = Console.ReadLine();

            if (ent == null || !int.TryParse(ent, out int num))
            {
                Console.WriteLine("Número inválido, inténtalo de nuevo.");
                i--;
                continue;
            }
            numeros.Add(num);
        }

        numeros.Sort();
        Console.WriteLine("\nNúmeros ordenados:");
        foreach (int n in numeros)
            Console.WriteLine(n);
    }
}


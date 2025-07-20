using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese una palabra: ");
        string? palabra = Console.ReadLine()?.ToLower() ?? "";

        int cuentaA = 0, cuentaE = 0, cuentaI = 0, cuentaO = 0, cuentaU = 0;

        foreach (char c in palabra)
        {
            switch (c)
            {
                case 'a': cuentaA++; break;
                case 'e': cuentaE++; break;
                case 'i': cuentaI++; break;
                case 'o': cuentaO++; break;
                case 'u': cuentaU++; break;
            }
        }

        Console.WriteLine("\nCantidad de cada vocal:");
        Console.WriteLine($"A: {cuentaA}");
        Console.WriteLine($"E: {cuentaE}");
        Console.WriteLine($"I: {cuentaI}");
        Console.WriteLine($"O: {cuentaO}");
        Console.WriteLine($"U: {cuentaU}");
    }
}


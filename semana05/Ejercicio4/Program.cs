using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Crear lista con el abecedario
        var abecedario = new List<string>();
        for(char c = 'A'; c <= 'Z'; c++)
            abecedario.Add(c.ToString());

        // 2. Eliminar en orden inverso para no desajustar índices
        for (int i = abecedario.Count - 1; i >= 0; i--)
        {
            // las posiciones múltiples de 3: 3, 6, 9..., es decir índice+1 % 3 == 0
            if ((i + 1) % 3 == 0)
                abecedario.RemoveAt(i);
        }

        // 3. Mostrar resultado
        Console.WriteLine("Abecedario tras eliminar posiciones múltiplos de 3:");
        Console.WriteLine(string.Join(" ", abecedario));
    }
}

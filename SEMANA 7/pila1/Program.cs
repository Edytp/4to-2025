
using System;
using System.Collections.Generic;

class Programa
{
    static bool EstaBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0)
                    return false;

                char tope = pila.Pop();

                if (!Coinciden(tope, c))
                    return false;
            }
        }

        return pila.Count == 0;
    }

    static bool Coinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }

    static void Main()
    {
        Console.WriteLine("Ingrese una expresión matemática:");
        string entrada = Console.ReadLine();

        if (EstaBalanceada("entrada"))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }
}
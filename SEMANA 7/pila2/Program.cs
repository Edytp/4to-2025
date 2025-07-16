
using System;
using System.Collections.Generic;

Stack<int> torreA = new Stack<int>();
Stack<int> torreB = new Stack<int>();
Stack<int> torreC = new Stack<int>();

void MostrarTorres()
{
    Console.WriteLine("Torre A: " + string.Join(", ", torreA.ToArray()));
    Console.WriteLine("Torre B: " + string.Join(", ", torreB.ToArray()));
    Console.WriteLine("Torre C: " + string.Join(", ", torreC.ToArray()));
    Console.WriteLine("----------------------------");
}

void MoverDiscos(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nombreOrigen, string nombreDestino, string nombreAuxiliar)
{
    if (n == 1)
    {
        int disco = origen.Pop();
        destino.Push(disco);
        Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
        MostrarTorres();
    }
    else
    {
        MoverDiscos(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);
        MoverDiscos(1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);
        MoverDiscos(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }
}

Console.Write("Ingrese el número de discos: ");
int n = int.Parse(Console.ReadLine());

// Cargar los discos en la torre A (del más grande al más pequeño)
for (int i = n; i >= 1; i--)
{
    torreA.Push(i);
}

Console.WriteLine("Estado inicial:");
MostrarTorres();

// Resolver el problema
MoverDiscos(n, torreA, torreC, torreB, "A", "C", "B");

Console.WriteLine("¡Resuelto!");

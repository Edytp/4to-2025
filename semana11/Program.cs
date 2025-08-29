using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario con palabras iniciales
    private static Dictionary<string, string> diccionario = new Dictionary<string, string>
    {
        { "Time", "tiempo" },
        { "Person", "persona" },
        { "Year", "año" },
        { "Way", "camino" },
        { "Day", "día" },
        { "Thing", "cosa" },
        { "Man", "hombre" },
        { "World", "mundo" },
        { "Life", "vida" },
        { "Hand", "mano" },
        { "Part", "parte" },
        { "Child", "niño" },
        { "Eye", "ojo" },
        { "Woman", "mujer" },
        { "Place", "lugar" },
        { "Work", "trabajo" },
        { "Week", "semana" },
        { "Case", "caso" },
        { "Point", "punto" },
        { "Government", "gobierno" },
        { "Company", "empresa" }
    };

    // Método para traducir una frase
    public static string TraducirFrase(string frase)
    {
        string[] palabras = frase.Split(' ');
        for (int i = 0; i < palabras.Length; i++)
        {
            // Buscar la palabra en el diccionario sin importar mayúsculas/minúsculas
            foreach (var entrada in diccionario)
            {
                if (string.Equals(palabras[i], entrada.Key, StringComparison.OrdinalIgnoreCase))
                {
                    palabras[i] = entrada.Value;
                    break;
                }
            }
        }
        return string.Join(" ", palabras);
    }

    // Método para agregar una nueva palabra al diccionario
    public static void AgregarPalabra(string palabraIngles, string palabraEspanol)
    {
        if (!diccionario.ContainsKey(palabraIngles))
        {
            diccionario.Add(palabraIngles, palabraEspanol);
            Console.WriteLine("Palabra agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }

    // Menú interactivo
    public static void MostrarMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la frase en inglés: ");
                    string frase = Console.ReadLine();
                    Console.WriteLine("Traducción: " + TraducirFrase(frase));
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("Ingrese la palabra en inglés: ");
                    string palabraIngles = Console.ReadLine();
                    Console.Write("Ingrese la traducción en español: ");
                    string palabraEspanol = Console.ReadLine();
                    AgregarPalabra(palabraIngles, palabraEspanol);
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void Main()
    {
        MostrarMenu();
    }
}

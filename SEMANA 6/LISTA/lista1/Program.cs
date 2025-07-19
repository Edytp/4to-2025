#nullable enable

using System;

namespace MiListaEnlazada
{
    public class Nodo<T>
    {
        public T Dato { get; set; }
        public Nodo<T>? Siguiente { get; set; }

        public Nodo(T dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class ListaEnlazada<T>
    {
        public Nodo<T>? Cabeza { get; private set; }

        public ListaEnlazada()
        {
            Cabeza = null;
        }

        public void Agregar(T dato)
        {
            var nuevo = new Nodo<T>(dato);
            if (Cabeza == null)
            {
                Cabeza = nuevo;
            }
            else
            {
                var actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public int ContarElementos()
        {
            int contador = 0;
            var actual = Cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var lista = new ListaEnlazada<int>();
            lista.Agregar(5);
            lista.Agregar(10);
            lista.Agregar(15);

            Console.WriteLine($"La lista tiene {lista.ContarElementos()} elementos.");

            // Ejemplo adicional: imprimir todos los elementos
            Console.WriteLine("Elementos de la lista:");
            var actual = lista.Cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }
    }
}

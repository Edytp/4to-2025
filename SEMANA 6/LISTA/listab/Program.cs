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
                    actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
        }

        public int ContarElementos()
        {
            int c = 0;
            var actual = Cabeza;
            while (actual != null)
            {
                c++;
                actual = actual.Siguiente;
            }
            return c;
        }

        // ← Este método debe estar aquí, dentro de la clase ListaEnlazada<T>
        public void InvertirIterativo()
        {
            Nodo<T>? prev = null;
            var current = Cabeza;
            while (current != null)
            {
                var next = current.Siguiente;
                current.Siguiente = prev;
                prev = current;
                current = next;
            }
            Cabeza = prev;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var lista = new ListaEnlazada<int>();
            lista.Agregar(1);
            lista.Agregar(2);
            lista.Agregar(3);
            lista.Agregar(4);
            lista.Agregar(5);

            Console.WriteLine($"Antes de invertir ({lista.ContarElementos()}):");
            Imprimir(lista);

            lista.InvertirIterativo();

            Console.WriteLine("Después de invertir:");
            Imprimir(lista);
        }

        static void Imprimir(ListaEnlazada<int> list)
        {
            var cur = list.Cabeza;
            while (cur != null)
            {
                Console.Write(cur.Dato + " ");
                cur = cur.Siguiente;
            }
            Console.WriteLine();
        }
    }
}



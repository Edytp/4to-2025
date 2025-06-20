using System;

namespace FigurasGeometricas
{
    // Clase base Figura que define la interfaz común para todas las figuras geométricas
    public abstract class Figura
    {
        // Método abstracto para calcular el área, debe ser implementado por cada clase derivada
        public abstract double CalcularArea();

        // Método abstracto para calcular el perímetro, debe ser implementado por cada clase derivada
        public abstract double CalcularPerimetro();
    }

    // Clase Círculo que hereda de Figura
    public class Circulo : Figura
    {
        public double Radio { get; set; }

        // Constructor que inicializa el radio del círculo
        public Circulo(double radio)
        {
            Radio = radio;
        }

        // Implementación del método CalcularArea para el círculo
        public override double CalcularArea()
        {
            // El área de un círculo se calcula como π * radio^2
            return Math.PI * Math.Pow(Radio, 2);
        }

        // Implementación del método CalcularPerimetro para el círculo
        public override double CalcularPerimetro()
        {
            // El perímetro de un círculo (circunferencia) se calcula como 2 * π * radio
            return 2 * Math.PI * Radio;
        }
    }

    // Clase Cuadrado que hereda de Figura
    public class Cuadrado : Figura
    {
        public double Lado { get; set; }

        // Constructor que inicializa el lado del cuadrado
        public Cuadrado(double lado)
        {
            Lado = lado;
        }

        // Implementación del método CalcularArea para el cuadrado
        public override double CalcularArea()
        {
            // El área de un cuadrado se calcula como lado^2
            return Math.Pow(Lado, 2);
        }

        // Implementación del método CalcularPerimetro para el cuadrado
        public override double CalcularPerimetro()
        {
            // El perímetro de un cuadrado se calcula como 4 * lado
            return 4 * Lado;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase Circulo con un radio de 5 unidades
            Circulo miCirculo = new Circulo(5);
            Console.WriteLine("Círculo:");
            Console.WriteLine($"Área: {miCirculo.CalcularArea()} unidades cuadradas");
            Console.WriteLine($"Perímetro: {miCirculo.CalcularPerimetro()} unidades");

            // Crear una instancia de la clase Cuadrado con un lado de 4 unidades
            Cuadrado miCuadrado = new Cuadrado(4);
            Console.WriteLine("\nCuadrado:");
            Console.WriteLine($"Área: {miCuadrado.CalcularArea()} unidades cuadradas");
            Console.WriteLine($"Perímetro: {miCuadrado.CalcularPerimetro()} unidades");
        }
    }
}

// Nombre: PAÚL TOAQUIZA
// Página: 1

using System;

namespace RegistroEstudiantes
{
    /// <summary>
    /// Clase que representa un estudiante con 3 teléfonos.
    /// </summary>
    public class Estudiante
    {
        private int id;
        private string nombres;
        private string apellidos;
        private string direccion;
        private string[] telefonos; // Array para almacenar 3 teléfonos

        // Constructor que recibe los datos del estudiante
        public Estudiante(int id, string nombres, string apellidos,
                          string direccion, string[] telefonos)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;

            // Validar que el array tenga exactamente 3 teléfonos
            if (telefonos.Length != 3)
                throw new ArgumentException("Se requieren exactamente 3 teléfonos.");

            this.telefonos = telefonos;
        }

        // Método que devuelve una cadena con los datos completos del estudiante
        public string ObtenerInfo()
        {
            return $"ID: {id}\n" +
                   $"Nombres: {nombres}\n" +
                   $"Apellidos: {apellidos}\n" +
                   $"Dirección: {direccion}\n" +
                   $"Teléfonos: {telefonos[0]}, {telefonos[1]}, {telefonos[2]}";
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            // Creamos un arreglo para manejar varios estudiantes
            Estudiante[] baseDeDatos = new Estudiante[2];

            baseDeDatos[0] = new Estudiante(
                1,
                "María",
                "López",
                "Av. Principal 123",
                new string[] { "0999123456", "0987654321", "0999988877" }
            );

            baseDeDatos[1] = new Estudiante(
                2,
                "Juan",
                "García",
                "Calle Secundaria 45",
                new string[] { "0977123456", "0967654321", "0959988877" }
            );

            // Mostrar los datos de cada estudiante
            for (int i = 0; i < baseDeDatos.Length; i++)
            {
                Console.WriteLine($"--- Estudiante #{i + 1} ---");
                Console.WriteLine(baseDeDatos[i].ObtenerInfo());
                Console.WriteLine();
            }
        }
    }
}


using System;
using System.Linq;
using System.Collections.Generic;

namespace BibliotecaApp
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }  // Ubicación física en la biblioteca
    }

    class Program
    {
        static HashSet<string> isbns = new HashSet<string>();
        static Dictionary<string, Book> library = new Dictionary<string, Book>();

        static void PreloadLibrary()
        {
            var books = new List<(string ISBN, string Title, string Category, string Location)>
            {
                // Aquí van los 100 libros precargados
                ("ISBN0001", "Manual de Automóviles Arias‑Paz", "Mecánica automotriz", "Estantería A1"),
                ("ISBN0002", "Motor 2.0 Litros Volkswagen – Estructura y Diagnóstico", "Mecánica automotriz", "Estantería A1"),
                ("ISBN0003", "Sistema de Inyección Directa de Alta Presión – Manual", "Mecánica automotriz", "Estantería A1"),
                ("ISBN0004", "Manual de Bombas Rotativas de Inyección Diésel", "Mecánica automotriz", "Estantería A1"),
                ("ISBN0005", "Revisión del Transeje – Manual", "Mecánica automotriz", "Estantería A2"),
                ("ISBN0006", "Manual de Motores – Pistones y Bujías", "Mecánica automotriz", "Estantería A2"),
                ("ISBN0007", "Manual de Mecanismos de Transmisión", "Mecánica automotriz", "Estantería A2"),
                ("ISBN0008", "Manual de Sistemas de Refrigeración", "Mecánica automotriz", "Estantería A2"),
                ("ISBN0009", "Arquitectura de Motores de Motocicletas", "Mecánica automotriz", "Estantería A3"),
                ("ISBN0010", "Inmovilizador Electrónico VW/Audi – Diagnóstico", "Mecánica automotriz", "Estantería A3"),
                ("ISBN0011", "EDC Regulación Electrónica de Motores Diésel", "Mecánica automotriz", "Estantería A3"),
                ("ISBN0012", "Sistemas de Climatización – Curso", "Mecánica automotriz", "Estantería A3"),
                ("ISBN0013", "Motores Diésel – Partes y Sobrealimentación", "Mecánica automotriz", "Estantería A4"),
                ("ISBN0014", "Funcionalidad de Motor – Hernández y Navarro", "Mecánica automotriz", "Estantería A4"),
                ("ISBN0015", "Auxiliares del Motor – Pardiñas & Feijoo", "Mecánica automotriz", "Estantería A4"),
                ("ISBN0016", "Elementos de Suspensión de Competición – Fondevila", "Mecánica automotriz", "Estantería A4"),
                ("ISBN0017", "Sistemas de Alimentación, Lubricación y Refrigeración – Crouse", "Mecánica automotriz", "Estantería A5"),
                ("ISBN0018", "Técnicas del Automóvil – Equipo Eléctrico – Alonso Pérez", "Mecánica automotriz", "Estantería A5"),
                ("ISBN0019", "Curso de Electrónica Automotriz 1 (diagramas eléctricos)", "Mecánica automotriz", "Estantería A5"),
                ("ISBN0020", "Sensores Automotrices y Análisis de Osciloscopio", "Mecánica automotriz", "Estantería A5"),
                ("ISBN0021", "Car Electrical & Electronic Systems", "Electricidad", "Estantería B1"),
                ("ISBN0022", "Automobile Mechanical and Electrical Systems", "Electricidad", "Estantería B1"),
                ("ISBN0023", "Automotive Wiring – Dennis W. Parks", "Electricidad", "Estantería B1"),
                ("ISBN0024", "Automotive Wiring and Electrical Systems – Tony Candela", "Electricidad", "Estantería B2"),
                ("ISBN0025", "Competition Car Electrics – Jonathan Lawes", "Electricidad", "Estantería B2"),
                ("ISBN0026", "Moderne Fahrzeugelektrik – Rob Siegel", "Electricidad", "Estantería B2"),
                ("ISBN0027", "Auto‑Elektrik (Zündsysteme, Lichtmaschine etc.)", "Electricidad", "Estantería B2"),
                ("ISBN0028", "Equipo eléctrico y electrónico del automóvil – William Crouse", "Electricidad", "Estantería B3"),
                ("ISBN0029", "Manual de Encendido Eléctrico Automotriz", "Electricidad", "Estantería B3"),
                ("ISBN0030", "Manual de Electrónica del Automóvil", "Electricidad", "Estantería B3"),
                ("ISBN0031", "Curso Reparación de Computadoras Automotrices", "Electricidad", "Estantería B4"),
                ("ISBN0032", "Curso de Electricidad Básica – Automotriz", "Electricidad", "Estantería B4"),
                ("ISBN0033", "Cuaderno de Entrenamiento Eléctrico/Mecánico – Peugeot & Renault", "Electricidad", "Estantería B4"),
                ("ISBN0034", "Manual de Pin Code – GTA", "Electricidad", "Estantería B5"),
                ("ISBN0035", "Manual de Sistema de Encendido Bosch", "Electricidad", "Estantería B5"),
                ("ISBN0036", "Manual de Pruebas Eficaces (Eléctrico)", "Electricidad", "Estantería B5"),
                ("ISBN0037", "Manual de Inyección Electrónica Aveo", "Electricidad", "Estantería B5"),
                ("ISBN0038", "Manual Programación de Llaves VW Jetta", "Electricidad", "Estantería C1"),
                ("ISBN0039", "Manual de Sistemas Eléctricos VW Pointer", "Electricidad", "Estantería C1"),
                ("ISBN0040", "Banco de Prueba ECU Corsa", "Electricidad", "Estantería C1"),
                ("ISBN0041", "Mecanizado básico para electromecánica – Casado", "Electromecánica", "Estantería C2"),
                ("ISBN0042", "Motores Pk 2016 – Escudero Fernández", "Electromecánica", "Estantería C2"),
                ("ISBN0043", "Circuitos de fluidos: suspensión y dirección", "Electromecánica", "Estantería C2"),
                ("ISBN0044", "Motores (Electromecánica)", "Electromecánica", "Estantería C3"),
                ("ISBN0045", "Sistemas de carga y arranque", "Electromecánica", "Estantería C3"),
                ("ISBN0046", "Sistemas de Transmisión y Frenado", "Electromecánica", "Estantería C3"),
                ("ISBN0047", "Sistemas auxiliares del motor", "Electromecánica", "Estantería C4"),
                ("ISBN0048", "Circuitos eléctricos auxiliares del vehículo", "Electromecánica", "Estantería C4"),
                ("ISBN0049", "Sistemas de seguridad y confortabilidad", "Electromecánica", "Estantería C4"),
                ("ISBN0050", "Analogías electromecánicas para dinámica de vehículos", "Electromecánica", "Estantería C5"),
                ("ISBN0051", "Electromagnetismo básico y ejercicios", "Electromecánica", "Estantería C5"),
                ("ISBN0052", "Modelado multifísico de motores eléctricos", "Electromecánica", "Estantería C5"),
                ("ISBN0053", "Electromagnetismo aplicado al automóvil – TMVG0209", "Electromecánica", "Estantería C6"),
                ("ISBN0054", "Mantenimiento eléctrico/habitáculo – TMVG0209", "Electromecánica", "Estantería C6"),
                ("ISBN0055", "Técnicas de mecanizado y metrología – TMVG0409", "Electromecánica", "Estantería C6"),
                ("ISBN0056", "Mantenimiento motores térmicos 2/4 tiempos – TMVG0409", "Electromecánica", "Estantería C7"),
                ("ISBN0057", "Mantenimiento sistemas refrigeración/lubricación – TMVG0409", "Electromecánica", "Estantería C7"),
                ("ISBN0058", "Curso Electricidad Industrial aplicada", "Electromecánica", "Estantería C7"),
                ("ISBN0059", "Ingeniería Automotriz (Ecuador)", "Electromecánica", "Estantería C8"),
                ("ISBN0060", "Desarrollo tecnológico en ingeniería automotriz", "Electromecánica", "Estantería C8"),
                ("ISBN0061", "Desarrollo emocional en la infancia", "Desarrollo infantil integral", "Estantería D1"),
                ("ISBN0062", "Juego y aprendizaje integral", "Desarrollo infantil integral", "Estantería D1"),
                ("ISBN0063", "Pedagogía del niño integral", "Desarrollo infantil integral", "Estantería D1"),
                ("ISBN0064", "Inteligencia emocional en la crianza", "Desarrollo infantil integral", "Estantería D2"),
                ("ISBN0065", "Neurodesarrollo y juego", "Desarrollo infantil integral", "Estantería D2"),
                ("ISBN0066", "Educación holística infantil", "Desarrollo infantil integral", "Estantería D2"),
                ("ISBN0067", "Atención temprana y desarrollo integral", "Desarrollo infantil integral", "Estantería D3"),
                ("ISBN0068", "Educación emocional desde cero", "Desarrollo infantil integral", "Estantería D3"),
                ("ISBN0069", "Desarrollo motor y cognitivo en niños", "Desarrollo infantil integral", "Estantería D3"),
                ("ISBN0070", "Apego y desarrollo infantil", "Desarrollo infantil integral", "Estantería D4"),
                ("ISBN0071", "Juego simbólico y aprendizaje", "Desarrollo infantil integral", "Estantería D4"),
                ("ISBN0072", "Desarrollo lingüístico temprano", "Desarrollo infantil integral", "Estantería D4"),
                ("ISBN0073", "Nutrición y desarrollo infantil", "Desarrollo infantil integral", "Estantería D5"),
                ("ISBN0074", "Crianza respetuosa e integral", "Desarrollo infantil integral", "Estantería D5"),
                ("ISBN0075", "Socialización en la infancia", "Desarrollo infantil integral", "Estantería D5"),
                ("ISBN0076", "Desarrollo de habilidades cognitivas en preescolar", "Desarrollo infantil integral", "Estantería D6"),
                ("ISBN0077", "Familia y desarrollo emocional del niño", "Desarrollo infantil integral", "Estantería D6"),
                ("ISBN0078", "Arte y creatividad infantil", "Desarrollo infantil integral", "Estantería D6"),
                ("ISBN0079", "Educación inclusiva en la primera infancia", "Desarrollo infantil integral", "Estantería D7"),
                ("ISBN0080", "Juego cooperativo y desarrollo social", "Desarrollo infantil integral", "Estantería D7"),
                ("ISBN0081", "Fundamentos de ingeniería automotriz", "Temas adicionales", "Estantería E1"),
                ("ISBN0082", "Innovaciones en sistemas del automóvil", "Temas adicionales", "Estantería E1"),
                ("ISBN0083", "Diagnóstico eléctrico moderno", "Temas adicionales", "Estantería E1"),
                ("ISBN0084", "Teoría de vehículos híbridos", "Temas adicionales", "Estantería E2"),
                ("ISBN0085", "Taller práctico de automoción", "Temas adicionales", "Estantería E2"),
                ("ISBN0086", "Seguridad vial y mecánica", "Temas adicionales", "Estantería E2"),
                ("ISBN0087", "Mecánica básica para estudiantes", "Temas adicionales", "Estantería E3"),
                ("ISBN0088", "Electricidad práctica para técnicos", "Temas adicionales", "Estantería E3"),
                ("ISBN0089", "Mantenimiento preventivo automotor", "Temas adicionales", "Estantería E3"),
                ("ISBN0090", "Documentación técnica vehicular", "Temas adicionales", "Estantería E4"),
                ("ISBN0091", "Manual del joven técnico automotriz", "Temas adicionales", "Estantería E4"),
                ("ISBN0092", "Introducción a la electromecánica aplicada", "Temas adicionales", "Estantería E4"),
                ("ISBN0093", "Nuevas tecnologías en automoción", "Temas adicionales", "Estantería E5"),
                ("ISBN0094", "Emprendimiento en servicios automotriz", "Temas adicionales", "Estantería E5"),
                ("ISBN0095", "Técnicas de reparación modernas", "Temas adicionales", "Estantería E5"),
                ("ISBN0096", "Automatización vehicular", "Temas adicionales", "Estantería E6"),
                ("ISBN0097", "Tecnología del servicio posventa", "Temas adicionales", "Estantería E6"),
                ("ISBN0098", "Gestión de talleres mecánicos", "Temas adicionales", "Estantería E6"),
                ("ISBN0099", "Vehículos eléctricos del futuro", "Temas adicionales", "Estantería E7"),
                ("ISBN0100", "Simulación digital en automoción", "Temas adicionales", "Estantería E7")
            };

            foreach (var (isbn, title, category, location) in books)
            {
                if (isbns.Add(isbn))
                {
                    library[isbn] = new Book
                    {
                        ISBN = isbn,
                        Title = title,
                        Category = category,
                        Location = location
                    };
                }
            }
        }

        static void ShowAllBooks()
        {
            Console.WriteLine("\nListado completo de libros registrados:\n");
            foreach (var book in library.Values)
                Console.WriteLine($"{book.Title} [{book.Category}] – (ISBN: {book.ISBN})");
        }

        static void SearchAndSelectByKeyword()
        {
            Console.Write("\nIngresa una palabra clave para buscar: ");
            string keyword = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                Console.WriteLine("No ingresaste ninguna palabra.");
                return;
            }

            var matches = library.Values
                                 .Where(b => b.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                                 .ToList();

            if (!matches.Any())
            {
                Console.WriteLine("No se encontraron coincidencias.");
                return;
            }

            Console.WriteLine($"\nSe encontraron {matches.Count} coincidencia(s):");
            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {matches[i].Title} [{matches[i].Category}]");
            }

            Console.Write("\nSelecciona el número del libro: ");
            if (int.TryParse(Console.ReadLine(), out int sel) && sel > 0 && sel <= matches.Count)
            {
                var book = matches[sel - 1];
                Console.WriteLine("\n--- Información del libro seleccionado ---");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine($"Título: {book.Title}");
                Console.WriteLine($"Categoría: {book.Category}");
                Console.WriteLine($"Ubicación: {book.Location}");
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
        }

        static void AddBookFromInput()
        {
            Console.WriteLine("\n--- Agregar nuevo libro ---");
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(isbn))
            {
                Console.WriteLine("ISBN inválido.");
                return;
            }

            if (!isbns.Add(isbn))
            {
                Console.WriteLine("Ese ISBN ya existe.");
                return;
            }

            Console.Write("Título: ");
            string title = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Categoría: ");
            string category = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Ubicación: ");
            string location = Console.ReadLine()?.Trim() ?? "";

            var newBook = new Book
            {
                ISBN = isbn,
                Title = title,
                Category = category,
                Location = location
            };

            library[isbn] = newBook;
            Console.WriteLine($"Libro '{title}' agregado exitosamente.");
        }

        static void Main()
        {
            PreloadLibrary();

            while (true)
            {
                Console.WriteLine("\n=== Menú de Biblioteca ===");
                Console.WriteLine("1. Mostrar todos los libros");
                Console.WriteLine("2. Buscar libro por palabra clave");
                Console.WriteLine("3. Agregar un nuevo libro");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción (1-4): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllBooks();
                        break;
                    case "2":
                        SearchAndSelectByKeyword();
                        break;
                    case "3":
                        AddBookFromInput();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intenta nuevamente.");
                        break;
                }
            }
        }
    }
}

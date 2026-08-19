using System;
namespace Calificaciones
{
    class Principal
    {
        static int ValidarDato()
        {
            string input;
            int numero;
            bool esValido;
            do
            {
                Console.Write("Ingrese la cantidad de estudiantes (minimo 1): ");
                input = Console.ReadLine();
                esValido = int.TryParse(input, out numero);
                if (!esValido || numero <= 0)
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido mayor a 0.");
                }
            }
            while (esValido == false && numero <= 0);
            return numero;
        }
        static void Main(string[] args)
        {
            try {
            Console.WriteLine("=== Analizador de Calificaciones ===");
            int cantidadAlumnos = ValidarDato();

            string[] nombres = new string[cantidadAlumnos];
            double[] calificaciones = new double[cantidadAlumnos];
            for (int i = 0; i < cantidadAlumnos; i++)
            {
                Console.Write($"Ingrese el nombre del estudiante {i + 1}: ");
                nombres[i] = Console.ReadLine();
                do
                {
                    Console.Write($"Ingrese la calificación de {nombres[i]} (0-100): ");
                    input = Console.ReadLine();
                    esValido = double.TryParse(input, out calificaciones[i]);
                    if (!esValido || calificaciones[i] < 0 || calificaciones[i] > 100)
                    {
                        Console.WriteLine("Por favor, ingrese una calificación válida entre 0 y 100.");
                    }
                }
                while (!esValido || calificaciones[i] < 0 || calificaciones[i] > 100);
            }
             } catch (FormatException)
            {
                Console.WriteLine("Algo ocurrio, intente de nuevo.");
            }
        }
    }
}
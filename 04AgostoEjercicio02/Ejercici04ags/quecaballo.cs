// MRU 
// v = d/t
// v * t = d
// t = d/V
// No pueden ser 0, -, ni letras

using System;

namespace MRU
{
    class Calc
    {
       
        static void Menu()
        {
            Console.WriteLine("\n=== Menú MRU ===");
            Console.WriteLine("1. Calcular Velocidad");
            Console.WriteLine("2. Calcular Distancia");
            Console.WriteLine("3. Calcular Tiempo");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");
        }

        static double Velocidad(double d, double t)
        {
            return d / t;
        }

        static double Distancia(double v, double t)
        {
            return v * t;
        }

        static double Tiempo(double d, double v)
        {
            return d / v;
        }

        
        static double SolicitarValorPositivo(string mensaje)
        {
            double valor;
            bool esValido;

            do
            {
                Console.WriteLine(mensaje);
                string entrada = Console.ReadLine();

                
                esValido = double.TryParse(entrada, out valor);

                if (!esValido || valor <= 0)
                {
                    Console.WriteLine("Error: Entrada inválida. No se aceptan letras, cero, ni negativos. Intente de nuevo.");
                    esValido = false; 
                }

            } while (!esValido);

            return valor;
        }

        static void Main(string[] args)
        {
            int op = 0;
            double d, v, t;

            do
            {
                Menu();
                string entradaOpcion = Console.ReadLine();

                if (!int.TryParse(entradaOpcion, out op) || op < 1 || op > 4)
                {
                    Console.WriteLine("Opción inválida. Por favor, ingrese un número del 1 al 4.");
                    continue;
                }

                switch (op)
                {
                    case 1:
                        d = SolicitarValorPositivo("Ingrese la distancia:");
                        t = SolicitarValorPositivo("Ingrese el tiempo:");
                        v = Velocidad(d, t);
                        Console.WriteLine($"=> La velocidad es: {v}");
                        break;

                    case 2:
                        v = SolicitarValorPositivo("Ingrese la velocidad:");
                        t = SolicitarValorPositivo("Ingrese el tiempo:");
                        d = Distancia(v, t);
                        Console.WriteLine($"=> La distancia es: {d}");
                        break;

                    case 3:
                        d = SolicitarValorPositivo("Ingrese la distancia:");
                        v = SolicitarValorPositivo("Ingrese la velocidad:");
                        t = Tiempo(d, v);
                        Console.WriteLine($"=> El tiempo es: {t}");
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                }

            } while (op != 4); 
        }
    }
}
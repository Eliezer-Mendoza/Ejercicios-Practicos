// Fahrenheit y celsius. Mostrar las temperaturas registradas por cada una. Si fue celsius etc por cada valor que se registro
// 0 a 34, convierte y posiciona. en uno pone el fahrenheit, otro el celsius el proceso es el convertidor.
// 1ra definir, 2da condicion simple / funcion compuesta fila ++ = fila = fila + 1;
using System;

namespace Prueba26
{
    class Principal
    {
        static int validaropcion()
        {
            do
            {
                string entrada;
                int n;
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out n) && (n >= 1 && n <= 3))
                {
                    return n;
                }
                Console.WriteLine("Entrada no valida. Seleccione rango de 1 a 3.");
            } while (true);
        }

        static double ValidacionTemperatura()
        {
            do
            {
                string entrada;
                double numero;
                entrada = Console.ReadLine();
                if (double.TryParse(entrada, out numero) && (numero >= 0 && numero <= 34))
                {
                    return numero;
                }
                Console.WriteLine("Entrada no valida. Rango permitido de 0 a 34.");
            } while (true);
        }

        static void Main(string[] args)
        {
            try
            {
                int op;
                int contador = 0;
                double[] celsius = new double[10];
                double[] fahrenheit = new double[10];

                do
                {
                    Console.WriteLine("\n--- MENU ---");
                    Console.WriteLine("1. Fahrenheit a Celsius.");
                    Console.WriteLine("2. Celsius a Fahrenheit.");
                    Console.WriteLine("3. Mostrar registros y salir.");
                    Console.Write("Seleccione una opcion: ");
                    op = validaropcion();

                    switch (op)
                    {
                        case 1:
                            if (contador < 10)
                            {
                                Console.Write("Ingrese la temperatura en Fahrenheit (0 a 34): ");
                                double f = ValidacionTemperatura();
                                fahrenheit[contador] = f;
                                celsius[contador] = ConvertirFahrenheitACelsius(f);
                                Console.WriteLine($"Registrado en indice {contador}.");
                                contador++;
                            }
                            else
                            {
                                Console.WriteLine("Se ha alcanzado el límite de 10 registros.");
                            }
                            break;

                        case 2:
                            if (contador < 10)
                            {
                                Console.Write("Ingrese la temperatura en Celsius (0 a 34): ");
                                double c = ValidacionTemperatura();
                                celsius[contador] = c;
                                fahrenheit[contador] = ConvertirCelsiusAFahrenheit(c);
                                Console.WriteLine($"Registrado en indice {contador}.");
                                contador++;
                            }
                            else
                            {
                                Console.WriteLine("Se ha alcanzado el límite de 10 registros.");
                            }
                            break;

                        case 3:
                            Console.WriteLine("\n--- TEMPERATURAS REGISTRADAS ---");
                            for (int i = 0; i < contador; i++)
                            {
                                Console.WriteLine($"Fila {i}: Celsius = {celsius[i]:F2} | Fahrenheit = {fahrenheit[i]:F2}");
                            }
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                    }
                } while (op != 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Algo ocurrio: " + ex.Message);
            }
        }

        static double ConvertirCelsiusAFahrenheit(double celsius)
        {
            return (celsius * 9.0 / 5.0) + 32;
        }

        static double ConvertirFahrenheitACelsius(double fahrenheit)
        {
            return (fahrenheit - 32.0) * 5.0 / 9.0;
        }
    }
}
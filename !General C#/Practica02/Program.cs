// Hacer un programa en el cual vale 60 el pasaje, pero tiene que pasar por n tramos, calcular el valor total incluyendo por los tramos
using System;
using Microsoft.VisualBasic;

namespace Pasaje
{
    class programa
    {
        public static void Menu()
        {
            Console.WriteLine("Bienvenido al programa.");
            Console.WriteLine("1. Calcular el pasaje total por tramo.");
            Console.WriteLine("2. Salir del sistema.");
        }
        static double subTotal (double pasaje, double tramos)
        {
            return pasaje * tramos;
        }
        static double Total (double subTotall)
        {
            return subTotall * 1.05;
        }
        public static void Main(Strings[] args)
        {
            int oP;
            double pasaje, tramos, subTotall;
            try {
                Menu();
                {
                    do
                    {
                        Menu();
                        string entrada = Console.ReadLine();
                        if (int.TryParse(entrada, out oP) && oP <1 || oP>2)
                        {
                            Console.WriteLine("Por favor ingrese un dato valido. (1 o 2");
                        }
                    } while (oP <1 || oP >2);
                }
                switch (oP)
                {
                    case 1:
                    Console.WriteLine("Ingrese el costo del pasaje y tramo. Enter para cada uno.");
                    pasaje = double.Parse(Console.ReadLine()!);
                    if (pasaje <1 || pasaje>100)
                    {
                    Console.WriteLine("El pasaje solo puede estar en el rango mayor a 0 y menor que 100");
                    }
                    tramos = double.Parse(Console.ReadLine()!);
                    if (tramos<0 || tramos >10)
                        {
                            Console.WriteLine("El tramo solo puede estar en el rango mayor a 0 y menor que 10");
                        }
                        else
                        {
                            Console.WriteLine("Se le cobrara un impuesto del 5% a su pasaje total.");
                            subTotall = subTotal(pasaje,tramos);
                            Console.WriteLine("Su pasaje subtotal es de: " + subTotal(pasaje, tramos));
                            Console.WriteLine("El valor total del transporte es de: " + Total(subTotall));
                        }
                     break;
                     case 2:
                        {
                            Console.WriteLine("Cerrando el programa...");
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            }
        }
}

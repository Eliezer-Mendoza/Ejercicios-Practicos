
using System;
using System.Numerics;
using Microsoft.VisualBasic;
namespace PagoTrabajadol
{
    class Principal
    {
        static double ValidarDato()
        {
            string input;
            double dato;
            do {
            input = Console.ReadLine();
            if (double.TryParse (input, out dato) && dato>0)
            {
                return dato;
            }
            Console.WriteLine("Entrada no valida, por favor intente de nuevo. | Ingrese valores positivos | No se admiten letras");
            } while (true);
        }

        static int ValidacionCategoria()
        {
            string input;
            int Categoria;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse (input, out Categoria) && Categoria>=1 && Categoria<=4)
                {
                    return Categoria;
                }
                Console.WriteLine("Por favor ingrese una opcion valida. No se pueden ingresar numeros ni letras.");
            } while (true);
        }
        static double PagoPorHoras(int Categoria, double dato)
        {
            double Categoria1 = 30;
            double Categoria2 = 38;
            double Categoria3 = 50;
            double Categoria4 = 70;
            double subtotal = 0;

            if (Categoria == 1)
            {
                subtotal = Categoria1 * dato;
            }
            else if (Categoria == 2)
            {
                subtotal = Categoria2 * dato;
            } 
            else if ( Categoria == 3)
            {
                subtotal = Categoria3 * dato;
            }
            else if (Categoria == 4)
            {
                subtotal = Categoria4 * dato;
            }
            return subtotal;
        }
        static void Main(string[]args)
        {
            try{
            Console.WriteLine("\t Bienvenido. \n Ingrese su sueldo");
            double sueldo = ValidarDato();
            Console.WriteLine("Ingrese su categoria de trabajador.");
            int Categoria = ValidacionCategoria();
            Console.WriteLine("Ingrese su total de horas extras trabajadas.");
            double horasExtras = ValidarDato();
            double Total = PagoPorHoras(Categoria, horasExtras);
            Console.WriteLine($"Pago por horas extras es de: {Total}");
            double totalTotal = sueldo + Total;
            Console.WriteLine("El total por todo es de: " + totalTotal);
            } catch (FormatException)
            {
                Console.WriteLine("Algo sucedio...");
            }
        }
    }
}
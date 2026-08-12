// Debe mostrar un menu con 3 zonas de envio, pedirle al usuario que elija una zona
// luego preguntarle el peso de su paquete en kg para calcular el costo total.
// zona 1: 5.0 - local
// zona 2: 10.00 nacional
// zona 3: 25.00 internacional
// default : 0
// impuesto de 10% al total / subtotal.
using System.Numerics;
using System;
namespace envios
{
    class Cuerpo
    {

        static void Menu()
        {
            Console.WriteLine("\t Bienvenido. \n Ingrese a la zona de envio deseada. \n 1. Zona 1 - Local \n 2. Zona 2 - Nacional \n 3. Zona 3 - Internacional");
        }
        static double ValidacionDato()
        {
            string input;
            double numero;
            do{
                input = Console.ReadLine();
            if (double.TryParse(input, out numero) && numero>0)
            {
                return numero;
            }
            Console.WriteLine("Por favor, ingrese un tipo de dato valido");
            } while (true);
        }
        static int ValidacionMenu()
        {
            string input;
            int opcion;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out opcion) && opcion>=1 && opcion<=3)
                {
                    return opcion;
                }
                Console.WriteLine("Por favor ingrese una opcion valida. No pueden ser letras.");
            } while(true);
        }
       static double CostoPorZonaYTotal(int opcion, double kg)
        {
            double Zona1 = 5.00;
            double Zona2 = 10.00;
            double Zona3 = 25.00;
            double subtotal = 0;
           
            if (opcion == 1)
            {
                subtotal = Zona1 * kg;
              
            }
            else if(opcion == 2)
            {
                subtotal = Zona2 * kg;
               
            }
            else if (opcion == 3)
            {
                subtotal = Zona3 * kg;
              
            }
            return subtotal * 1.10;
        }
        static void Main(string[]args)
        {
            try
            {
             
                Menu();
                int opcion = ValidacionMenu();
                Console.WriteLine("Ingrese el peso | KG: ");
                double kg = ValidacionDato();
                double total = CostoPorZonaYTotal(opcion, kg);
                Console.WriteLine($"El costo total es de (incluyendo impuestos del 10%): ${total:F2}");
            } catch (FormatException)
            {
                Console.WriteLine("Algo ocurrio...");
            }
        
        }
    }
}
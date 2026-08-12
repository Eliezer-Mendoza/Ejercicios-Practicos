// Ejercicio 3
// Escribir una funcion que calcule el area de un circulo y otra que calcule el volumen de un cilindro usando la primera funcion}}

using System;
using System.ComponentModel;
using System.Formats.Asn1;

namespace Funcion
{
    class Program
    {
        static void Menu()
        {
             Console.WriteLine("\t Bienvenido al menu. Seleccione una opcion.  1. Area de un ciculo.  2. Volumen de un cilindro.  3. Salir. \t");
        }
        static double Validacion()
{
    double numero;
    string input;
    do
    {
        input = Console.ReadLine();
        
        if (double.TryParse(input, out numero) && numero > 0)
        {
            return numero;
        }
        
        Console.WriteLine("Entrada no valida, por favor intentelo de nuevo. Ingrese numeros positivos | No se admiten letras");
    } while (true);
}
        static double CAC (double radio)
        {
            return (radio * radio) * 3.14;
        }
        static double ValidacionMenu()
        {
            int opcion;
            string entrada;
            do{
            entrada = Console.ReadLine();
            if (int.TryParse(entrada, out opcion) && opcion>=1 && opcion <=3)
                {
                    return opcion;
                }
                Console.WriteLine("Entrada no valida. Por favor escoja una opcion del 1 al 3.");
            }while (true);
        }
        static double CVC (double radio, double altura)
        {
            return CAC(radio)*altura;
        }
        public static void Main(string[] args)
        {
            try {
           Menu();
          int opcion = (int)ValidacionMenu();


            switch (opcion)
                {
                    case 1:
                        {
                               double radio;
                            Console.WriteLine("Por favor ingrese el radio");
                             radio = (double)Validacion();
                            double area = CAC(radio);
                             Console.WriteLine("El area del circulo es de: " + area);
                            break;
                        }
                        case 2:
                        {
                            double radio;
                            double altura;
                            Console.WriteLine("Por favor ingrese el radio");
                            radio = (double)Validacion();
                            Console.WriteLine("Por favor ingrese la altura");
                            altura = (double)Validacion();
                            double volumen = CVC(radio,altura);
                            Console.WriteLine("El volumen del cilindro es de: " + volumen);
                            break;
                        }
                        case 3:
                        {
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        }
                }
        } catch (FormatException)
            {
                Console.WriteLine("Algo ocurrio...");
            }
    }
    } 
}
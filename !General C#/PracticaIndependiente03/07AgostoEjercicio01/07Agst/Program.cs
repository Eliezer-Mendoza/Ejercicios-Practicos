// Practica 7 de agosto
// Escriba una funcion que reciba un numero entero positivo y devuelva su factorial
using System;

namespace ClasePractica
{
    class Document
    {
        public static int Validar()
        {
            int numero;
            if (int.TryParse(Console.ReadLine(), out numero) && numero > 0)
            {
                return numero;
            }
            Console.WriteLine("No se admiten letras, 0 ni negativo.");
            return -1;
        }
        public static double Factorial(int numero)
        {
            double factorial = 1;
            for (int i = 1; i <= numero; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

       /// public static int ValidarOpcion()
        //{
           // int opcion;
            //if (int.TryParse(Console.ReadLine(), out opcion) && (opcion == 1 || opcion == 2))
            //{
               // return opcion;
            //}
          //  Console.WriteLine("Opción inválida. Ingrese 1 o 2.");
           // return -1;
        //}


        static void Main(string[] args)
        {
            try
            {
                int numero;
                do
                {
                    Console.WriteLine("Ingrese un numero entero positivo: ");
                    numero = Validar();
                } while (numero <= 0);

                double factorial = Factorial(numero);
                Console.WriteLine($"El factorial de {numero} es: {factorial}");


                Console.WriteLine("Saliendo del sistema...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            }
        }
    }


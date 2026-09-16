// Ejercicio 1: El Cajero Automático (Condicionales)

// Escribe un programa que simule un cajero automático. El usuario tiene un saldo inicial de $1000.

// El programa debe pedirle cuánto dinero quiere retirar.

// Si intenta retirar más de lo que tiene, debe mostrar un mensaje de "Fondos insuficientes".

// Si la cantidad es válida, debe restarla del saldo y mostrar el saldo restante.

// Extra: Verifica que no pueda retirar cantidades negativas.
using System;
namespace Ahora
{
    class ñññ
    {
        static double Cajero = 1000;
        static void Menu()
        {
            Console.WriteLine($"\t Bienvenido al Cajero Automatico. \n Usted posee un saldo de: {Cajero}");
        }
        static void Main(string[] args)
        {
           Menu();
            do
            {
                RetirarDinero();
                Console.WriteLine("\n¿Desea hacer otro retiro? Ingrese el monto:");
            } while (true);
        }
        static double ValidarDato()
        {
            string entrada;
            double n;
            do
            {
                entrada = Console.ReadLine();
                if(double.TryParse(entrada, out n) && n>0)
                {
                    return n;
                }
                Console.WriteLine("No puede ingresar cantidades negativas ni letras. Intentelo de nuevo.");
            } while (true);
        }
        static void RetirarDinero()
        {
             double retirar = ValidarDato();
                if (retirar > Cajero)
                {
                    Console.WriteLine($"Usted no puede retirar mas dinero del que tiene en su cuenta. | {Cajero}");
                }
                else
                {
                      Cajero = Cajero - retirar;
                      Console.WriteLine($"Usted retiro la cantidad de: {retirar}, saldo pendiente: {Cajero}");
                }
        }
    }
}
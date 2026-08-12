
using System;
namespace VentadeEntradas
{
    class Bloque
    {
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
            Console.WriteLine("Entrada no valida. Por favor intente numeros mayor a 0 y que no sean letras.");
           } while(true);
        }
        static double ValidacionEdad()
        {
            string input;
            int edad;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out edad) && edad>0 && edad<=100)
                {
                    return edad;
                }
                Console.WriteLine("Entrada no valida. Ingrese numeros positivos  (1 al 100) y que no sean letras.");
            } while (true);
        }
        static double Descuentos(int edad, double ValorEntrada)
        {
    if (edad < 12)
    {
      
        return ValorEntrada * 0.5; 
    }
    if (edad>= 65)
    {
        return ValorEntrada * 0.3;
    }

    return 0; 
}
 static double Total(int entradas, double ValorEntrada, double descuentos)
        {
           double subtotal = ValorEntrada * entradas;
           return subtotal - descuentos;
        }
        static void Main(string[] args)
        {
            try {
            Console.WriteLine("\t Bienvenido! ");
            Console.WriteLine("\t Cuantas entradas desea comprar?");
            int entradas = (int)ValidacionDato();
            Console.WriteLine("Ingrese su edad");
            int edad = (int)ValidacionEdad();
            double ValorEntrada = 10;
            double subtotal = entradas * ValorEntrada;
            double descuentito = Descuentos(edad, subtotal);
            double totalcito = Total(entradas, ValorEntrada, descuentito);
            Console.WriteLine("\n--- RESUMEN DE COMPRA ---");
                Console.WriteLine("Entradas: " + entradas);
                Console.WriteLine("Subtotal: $" + subtotal);
                Console.WriteLine("Descuento aplicado: $" + descuentito);
                Console.WriteLine("Total a pagar: $" + totalcito);
                }
            catch (Exception)
            {
                Console.WriteLine("Algo ocurrio...");
            }
            
        }
    }
} 
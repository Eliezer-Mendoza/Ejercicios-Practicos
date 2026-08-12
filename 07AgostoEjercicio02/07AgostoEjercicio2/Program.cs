// Ejercicio 2
// Escribir una funcion que calcule el total de una factura tras aplicarle el IVA. La funcion debe recibir kla cantidad sin iva y el porcentaje de IVA  a aplicar, y devolver el total de la factora. Si se invoca la funcion sin pasarle el porcentaje de IVA, debera aplicar un 15%
using System;

namespace ClasePractica
{
    class Document
    {
        public static int Validar()
        {
            int numero;
            if (int.TryParse(Console.ReadLine(), out numero) && numero >= 0)
            {
                return numero;
            }
            Console.WriteLine("Entrada inválida. No se admiten letras ni negativos.");
            return -1;
        }

        public static double ValidarIVA()
        {
          
            double iva;
            var userInput = Console.ReadKey();

            if (double.TryParse(Console.ReadLine(), out iva) && iva >= 0)
            {
                return iva;
            }
            if (userInput.Key == ConsoleKey.Enter)
            {
                return iva;
            }
            
        Console.WriteLine("Entrada de IVA inválida. Introduzca un número mayor o igual que 0.");
            return -1;
        }
        public static double Factura(int numero, double iva = 0.15)
        {

            if (iva > 1 && iva <= 100)
            {
                iva = iva / 100.0;
            }

            if (iva <= 0)
            {
                Console.WriteLine("IVA negativo no permitido. Se aplicará el 15% por defecto.");
                iva = 0.15;
            }
            
            {
                Console.WriteLine("IVA invalido. Se aplicará el 15% por defecto.");
                iva = 0.15;
            }

            if (iva >= 0.30)
            {
                Console.WriteLine("El IVA máximo permitido es 30%. Se aplicará 30%.");
                iva = 0.30;
            }

            double subtotal = numero;
            double total = subtotal + (subtotal * iva);

            return total;
        }

        static void Main(string[] args)
        {
            try
            {
                int numero;
                do
                {
                    Console.WriteLine("Ingrese un número (mayor o igual que 0): ");
                    numero = Validar();
                } while (numero < 0);

                double ivaValor;
        
                do
                {
                    Console.WriteLine("Ingrese el porcentaje de IVA a aplicar (ej: 15 o 0.15). Si introduce >100 se aplicará 15% por defecto:");
                    ivaValor = ValidarIVA();
                } while (ivaValor < 0);

                
                if (ivaValor > 100)
                {
                    Console.WriteLine("IVA mayor que 100. Se aplicará 15% por defecto.");
                    ivaValor = 0.15;
                }

                double total = Factura(numero, ivaValor);
                Console.WriteLine($"El total de la factura es: {total}");

                Console.WriteLine("Saliendo del sistema...");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ocurrió un error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }
        }
    }
}
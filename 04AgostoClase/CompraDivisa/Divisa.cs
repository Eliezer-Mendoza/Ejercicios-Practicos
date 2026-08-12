// Compra de divisa 
// Comprar dolares a 37.2
// Vender un dolar a 36.62
// 11mil el maximo de dolares a comprar
// 11mil el maximo de dolares a vender
using System;

namespace divisa
{
    class divissas
    {
        static void Menu()
        {
            Console.WriteLine("\n=== Casa de Cambio ===");
            Console.WriteLine("1. Comprar dólares (Ingresar córdobas)");
            Console.WriteLine("2. Vender dólares (Ingresar córdobas)");
            Console.WriteLine("3. Salir");
        }

        static double comprar(double cantidadCordobas, double precio)
        {
            return cantidadCordobas / precio;
        }

        static double vender(double cantidadCordobas, double precio)
        {
            return cantidadCordobas / precio;
        }

        static void Main(string[] args)
        {
            const double precioCompra = 37.2;
            const double precioVenta = 36.62;
            const double maxDolares = 11000; 

            while (true)
            {
                Menu();
                Console.WriteLine("Ingrese una opcion: ");
                
                if (!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Opcion invalida");
                    continue;
                }

                if (opcion == 3)
                {
                    Console.WriteLine("Saliendo...");
                    break;
                }

                switch (opcion)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("Ingrese la cantidad de cordobas con los que va a comprar dólares: ");
                            if (!double.TryParse(Console.ReadLine(), out double cantidadCordobas))
                            {
                                Console.WriteLine("Ingrese un valor valido (solo números).");
                                continue;
                            }
                            if (cantidadCordobas < 1)
                            {
                                Console.WriteLine("El valor debe ser mayor a 0.");
                                continue;
                            }

             
                            double totalDolares = comprar(cantidadCordobas, precioCompra);

                        
                            if (totalDolares > maxDolares)
                            {
                                Console.WriteLine($"El limite maximo es de {maxDolares} dolares. Con esa cantidad de córdobas estás intentando comprar {totalDolares:F2} dolares.");
                                continue;
                            }

                         
                            Console.WriteLine($"Con {cantidadCordobas} córdobas, compras: {totalDolares} dólares");
                            break; 
                        }
                        break;

                    case 2:
                        while (true)
                        {
                            Console.WriteLine("Ingrese la cantidad de cordobas a los que equivalen los dólares a vender: ");
                            if (!double.TryParse(Console.ReadLine(), out double cantidadCordobas))
                            {
                                Console.WriteLine("Ingrese un valor valido (solo números).");
                                continue;
                            }
                            if (cantidadCordobas < 1)
                            {
                                Console.WriteLine("El valor debe ser mayor a 0.");
                                continue;
                            }

                            double totalDolares = vender(cantidadCordobas, precioVenta);

                            if (totalDolares > maxDolares)
                            {
                                Console.WriteLine($"El limite maximo es de {maxDolares} dolares. Ese monto en córdobas equivale a {totalDolares:F2} dolares.");
                                continue;
                            }

                            Console.WriteLine($"Esos {cantidadCordobas} córdobas equivalen a: {totalDolares} dólares");
                            break; 
                        }
                        break;

                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            }
        }
    }
}
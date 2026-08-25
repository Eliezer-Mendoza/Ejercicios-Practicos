namespace Practica07
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                double[] n1 = new double[4];
                double precio = 0;
                int cantidad = 0;
                double total = 0;
                double subtotal = 0;

                Console.WriteLine("Ingrese cuantos productos va a llevar");
                int agarrarProducto = validarProductos();
                n1[0] = agarrarProducto;

                for (int j = 0; j < n1[0]; j++)
                {
                    Console.WriteLine($"Producto {j + 1}");
                    Console.WriteLine("Ingrese la cantidad del producto");
                    cantidad = validarCantidad();
                    n1[1] = cantidad;

                    Console.WriteLine("Ingrese el precio del producto");
                    precio = validarPrecio();
                    n1[2] = precio;

                    n1[3] = n1[1] * n1[2];
                    subtotal = n1[1] * n1[2];

                    Console.WriteLine("El subtotal de estos productos fue de: " + subtotal);
                }
                Console.WriteLine("El total es: " + total);
                Console.WriteLine("La cantidad de productos que llevó: " + n1[0]);
            } 
            catch (OverflowException)
            {
                Console.WriteLine("se ha producido un desbordamiento");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("se intento acceder a una posicionm inexistente en el arreglo.");
            }
            catch (Exception)
            {
                Console.WriteLine("algo sucedio");
            }
        }
        static int validarCantidad()
        {
            string input;
            int cantidad;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out cantidad))
                {
                    if (cantidad > 0 && cantidad <= 8)
                    {
                        return cantidad;
                    }
                    Console.WriteLine("Ingrese un valor entre 1 y 8");
                }
                else
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (true);
        }
        static int validarProductos()
        {
            string input;
            int productos;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out productos))
                {
                    if (productos > 0 && productos <= 10)
                    {
                        return productos;
                    }
                    Console.WriteLine("Ingrese un valor entre 1 y 10");
                }
                else
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (true);
        }
        static double validarPrecio()
        {
            string input;
            double precio;
            do
            {
                input = Console.ReadLine();
                if (double.TryParse(input, out precio))
                {
                    if (precio > 0 && precio <= 1800)
                    {
                        return precio;
                    }
                    Console.WriteLine("Ingrese un valor entre 1 y 1800");
                }
                else
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (true);
        }
    }
}
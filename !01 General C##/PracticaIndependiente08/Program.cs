// lo mismo de la otra vez pero esta vez mostrando los datos como si fuera tabulador (?
namespace Independiente08
{
    class Principal
    {
        static void Main(string[] args)
        {
            try
            {
                double[] n1 = new double[4];
                double precioProducto;
                int cantidadProducto;
                int agarrarProducto;
                double total;
                double subtotal;
                Console.WriteLine("Ingrese cuantos productos va a llevarse.");
                agarrarProducto = ValidarProductosPorAgarrar();
                n1[0] = agarrarProducto;
                for (int j = 0; j < n1[0]; j++)
                {
                    Console.WriteLine($"Producto n: {j + 1}");
                }
            } catch
            {
                Console.WriteLine("Algo ocurrio/");
            }
        }
        static int CantidadDelProducto()
        {
            string input;
            int cantidadProducto;
            do
            {
                input = Console.ReadLine();
                if(int.TryParse(input, out cantidadProducto) && (cantidadProducto>0 || cantidadProducto<=10))
                {
                    return cantidadProducto;
                }
                Console.WriteLine("Ingrese una cantidad mayor a 0 o menor igual a 10.");
            } while(true);
        }
        static int ValidarProductosPorAgarrar()
        {
            string input;
            int agarrarProducto = 0;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out agarrarProducto) && (agarrarProducto>0 || agarrarProducto<10))
                {
                    return agarrarProducto;
                }
                Console.WriteLine("Ingrese un valor entre 0 y 10.");
            } while (true);
        }
        static double PrecioProducto()
        {
            string input;
            double precioProducto;
            do
            {
                input = Console.ReadLine();
                if (double.TryParse(input, out precioProducto) && (precioProducto>0 || precioProducto<1800))
                {
                    return precioProducto;
                }
                Console.WriteLine("Ingrese un precio mayor a 0 y menor que 1800.");
            } while (true);
        }
    }
}
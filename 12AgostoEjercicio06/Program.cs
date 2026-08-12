namespace llamandinhas
{
    class Programa
    {
        static double ValidacionDatos()
        {
            string input;
            double numero;
            do{
            input = Console.ReadLine();
            if (double.TryParse(input, out numero) && numero>0)
                {
                    return numero;
                }
                Console.WriteLine("Entrada no valida. No se aceptan letras ni numeros negativos.");
            } while (true);
        }
        static int ValidacionZona()
        {
            string input;
            int Zona;
            do {
            input = Console.ReadLine();
            if (int.TryParse(input, out Zona) && (Zona==12 || Zona ==15 || Zona == 18 || Zona == 19 || Zona == 23 || Zona == 25 || Zona == 29))
            {
                return Zona;
            }
            Console.WriteLine("Ingrese una zona correcta. Intentelo de nuevo");
            } while (true);
        }
        static double CostoPorZona(double minutos, int Zona)
        {
            double subtotal = 0;
            if (Zona == 12)
            {
                subtotal = 2 * minutos;
            }
            else if (Zona == 15)
            {
                subtotal = 2.2 * minutos;
            }
            else if (Zona == 18)
            {
                subtotal = 4.5 * minutos;
            }
            else if (Zona == 19)
            {
                subtotal = 3.5 * minutos;
            }
            else if (Zona == 23)
            {
                subtotal = 6 * minutos;
            }
            else if (Zona == 25)
            {
                subtotal = 6 * minutos;
            }
            else if (Zona == 29)
            {
                subtotal = 5 * minutos;
            }
            return subtotal;
        }
        static void Main(string[] args)
        {
            try {
            Console.WriteLine("ingrese la clave de la zona (12, 15, 18, 19, 23, 25 o 29):");
            int Zona = ValidacionZona();

            Console.WriteLine("ingrese el numero de minutos hablados:");
            double minutos = ValidacionDatos();

            double subtotal = CostoPorZona(minutos, Zona);

            Console.WriteLine($"el costo total de la llamada es: {subtotal}");
            } catch (FormatException)
            {
                Console.WriteLine("no seas pendejo y pone la mierda bien hpta animal");
            }
        }
    }
}
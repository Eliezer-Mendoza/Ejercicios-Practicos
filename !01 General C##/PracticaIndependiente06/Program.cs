// // Una pequeña sala de cine necesita un programa en C# que permita procesar la información de venta de entradas
namespace Practica06
{
    class Programa
    {

        static int Validacion()
        {
            string input;
            int numero;
            do{
            input = Console.ReadLine();
            if(int.TryParse(input, out numero) && numero>0)
            {
                return numero;
            }
            Console.WriteLine("Ingrese un dato valido | No se admiten letras o negativos");
            } while(true);
        }

        static double PromedioEntradas(int entradas, double precio)
        {
            return precio/entradas;
        }
        static double ValidacionPrecio()
        {
            string input;
            double precio;
            do
            {
                input = Console.ReadLine();
                if(!double.TryParse(input, out precio) && precio>0)
                {
                    return precio;
                }
                Console.WriteLine("Por favor ingrese un tipo de dato valido. Intentelo de nuevo");
            } while(true);
        }

        static double ventaspordiaypromedio()
        {
            double promedio = 0;
            int ventas = 0;
            double precio = 0;
            double ingreso = 0;
            ingreso = ventas * precio;
            
        }

        static void SumaRecaudada()
        {
            double suma = 0;
            for (int i = 0; i < 7; i++)
            {
                suma += ventaspordiaypromedio(i);
            }
            return suma;
        }   

        static void DiaMayorRecaudacion()
        {
            double mayor = 0;
            for (int i = 0; i < 7; i++)
            {
                if (ventaspordiaypromedio(i) > mayor)
                {
                    mayor = ventaspordiaypromedio(i);
                }
            }
            return mayor;
        }
        static void DiaMenorRecaudacion()
        {
            double menor = 0;
            for (int i = 0; i < 7; i++)
            {
                if (ventaspordiaypromedio(i) < menor)
                {
                    menor = ventaspordiaypromedio(i);
                }
            }
            return menor;
        }
        static void CantidadDiasConRecaudacionSuperiorA1000()
        {
            int cantidad = 0;
            for (int i = 0; i < 7; i++)
            {
                if (ventaspordiaypromedio(i) > 1000)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }
        static void Main(string[] args)
        {
            try
            {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Ingrese la cantidad de entradas vendidas");
                int entradas = Validacion();
                Console.WriteLine("Ingrese el precio promedio por entrada");
                double precio = ValidacionPrecio();
                ventaspordiaypromedio(entradas, precio);
                Console.WriteLine();
            } 
            Console.WriteLine("El promedio de entradas vendidas es: " + PromedioEntradas()); 
            Console.Writeline("La suma recaudada fue de: " + SumaRecaudada());
            Console.Writeline("El dia con mayor recaudacion fue: " + DiaMayorRecaudacion());
            Console.Writeline("El dia con menor recaudacion fue: " + DiaMenorRecaudacion());
            Console.Writeline("La cantidad de dias con recaudacion superior a 1000 es: " + CantidadDiasConRecaudacionSuperiorA1000());
                
            } catch (OverflowException)
            {
                Console.WriteLine("Alfog ocurrio");
            }
        }
    }
}
// Elaborar una aplicacion consola en C# que seleccione entre las siguientes opciones:

// 1.- Convertir de K a F

// 2.- Convertir de F a C

// 3.- Salir

// utilizar modularidad, manejo de errores, manejo de excepciones y validar todo lo que este sujeto a validacion.
namespace Practica
{
    class Principal
    {
        static void Main(string[] args)
        {
            int op = 0;
            do
            {
                try{          
             op = ValidarMenu();
             switch(op)
                {
                    case 1:
                           System.Console.WriteLine("Por favor, ingrese la temperatura en Kelvin");
                            ConvertirKaF();
                    break;
                    case 2:System.Console.WriteLine("Por favor, ingrese la temperatura en Fahrenheit: "); ConvertirFaC();
                    break;
                    case 3: System.Console.WriteLine("Saliendo del sistema...");
                    break;
                    default: System.Console.WriteLine("Por favor ingrese un numero del 1 al 3."); break;
                }
                } catch (Exception ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}");
                }
            } while(op != 3);
        }
        static void ConvertirKaF()
        {
            double k;
            double KaF;
                k = ValidarDato();
                KaF = ((k - 273.15) * 1.8) +32;
                System.Console.WriteLine($"Su resultado en Fahrenheit es: {KaF}");
        }
        static void ConvertirFaC()
        {
            double F;
            double CaF;
                F = ValidarDato();
                CaF = (F - 32) / 1.8;
                System.Console.WriteLine($"Su resultado en Celsius es de : {CaF}");
        }
        static double ValidarDato()
        {
            string entrada;
            double n;
            do
            {
                entrada = Console.ReadLine();
                if (double.TryParse(entrada,out n))
                {
                    return n;
                }
            } while(true);
        }
        static int ValidarMenu()
        {
            string entrada;
            int op;
            do
            {
             System.Console.WriteLine("Bienvenido al convertiror. \n 1. Convertir de Kelvin a Fahrenheit. \n 2. Convertir de Fahrenheit a Celsius. \n 3. Salir del programa.");
                entrada = Console.ReadLine();
              if(int.TryParse(entrada, out op) && op >= 1 && op <= 3)
                {
                    return op;
                }
                System.Console.WriteLine("Entrada no valida. Seleccione del 1 al 3.");
            } while (true);
        }
    }
}
// 1.- Elaborar una aplicación consola en C# que gestione el año de ingreso de los empleados entre 1961 a 2026.
//  Calcule la antigüedad retomando el año actual de la fecha del sistema. 
// Pida el salario entre 7188 y 500000. Basado en la antigüedad calcule la antigüedad económica como ((2n+1)/100)+salario.
//  El resultado ingresarlo en una pila denominada Ingresos de tipo decimal. Validar todo lo que este sujeto a validación.
//  Manejar excepciones. Utilizar modularidad.
namespace PruebaEj1
{
    class Principal
    {
     static  Stack<decimal> Ingresos = new Stack<decimal>();
        static void Main(string[] args)
        {     
            try {
            do
            {
            Menu();
            int opcion = ValidarNum(1, 3);
            switch (opcion)
                {
            case 1: break;
            case 2: break;
            case 3:
            Console.WriteLine("Saliendo del sistema...");return;
            default:Console.WriteLine("Entrada no valida. Escoja una opcion del 1 al 3");break;
            }
            } while (true);
            }
                catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error en la pila: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Error de desbordamiento numérico: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error de formato en la entrada: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        } 
        static int ValidarNum(int min, int max)
        {
            string entrada;
            int numero;
            do{
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out numero) && numero >= min && numero <= max)
            {
                return numero;
            }
            Console.WriteLine("Ingrese una entrada valida. No se aceptan simbolos o letras");
            } while(true);
        }
        static void Menu()
        {
            Console.WriteLine("Bienvenido al menu. \n 1. Calcular antiguedad empleado. \n 2. Ver resultados de antiguedad. \n 3. Salir del sistema");
        }
    }
}
// 1.- Elaborar una aplicación consola en C# que declare una matriz denominada MesaCambio de 5x3.
//  Entre la primera columna deberá gestionar los valores en dólares entre 1 y 11.
//  En la segunda deberá convertir esos dólares de la primera columna en euros con una tasa de cambio de 1.2456. 
// En la tercera columna convertirá los dólares a córdobas con una tasa de cambio de 36.62.
namespace MesaCambio
{
    class Principal
    {
        static void Main(string[] args)
        {
            try{
            double[,] MesaCambio = new double [5,3];
            Console.WriteLine("Por favor ingrese los dolares | 1 a 11 |");
            for (int i = 0; i < MesaCambio.GetLength(0); i++)
            {
                System.Console.WriteLine($"Dato: {i+1}");
                MesaCambio[i,0] = ValidarDato();
            }
            ConvertirDolaresaCordobas(MesaCambio);
            ConvertirDolaresAEuros(MesaCambio);
            System.Console.WriteLine("==========================");
            System.Console.WriteLine(" = MESA DE CAMBIO =");
            System.Console.WriteLine("==========================");
            for (int i = 0; i < MesaCambio.GetLength(0); i++)
            {
                System.Console.WriteLine($"USD: {MesaCambio[i, 0]:F2} | EUR: {MesaCambio[i, 1]:F2} | NIO: {MesaCambio[i, 2]:F2}");
            }
            } catch(Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
        static double ValidarDato()
        {
            string entrada;
            double n;
            do
            {
                entrada = Console.ReadLine();
                if(double.TryParse(entrada,out n) && (n>=1 && n<=11))
                {
                    return n;
                }
                Console.WriteLine("Entrada no valida. No se aceptan letras ni negativos. | Ingrese numeros de rango 1 a 11 |. Por favor intentelo de nuevo.");
            } while (true);
        }
        static void ConvertirDolaresAEuros(double[,] MesaCambio)
        {
            for (int i = 0; i < MesaCambio.GetLength(0); i++)
{
    MesaCambio[i, 1] = MesaCambio[i, 0] * 1.2456; 
}
        }
        static void ConvertirDolaresaCordobas(double[,] MesaCambio)
        {
           for (int i = 0; i < MesaCambio.GetLength(0); i++ )
            {
                MesaCambio[i,2] = MesaCambio[i,0] * 36.62;
            }
        }
    }
}
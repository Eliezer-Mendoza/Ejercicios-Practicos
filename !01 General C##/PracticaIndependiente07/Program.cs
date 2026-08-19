using System;
namespace principal
{
    class programa
    {
        static void Main(string[]args)
        {
            
        }
        static void Validar()
        {
            string input;
            double numero;
            do
            {
                input = Console.ReadLine();
                if(double.TryParse(input, out numero) && numero>0)
                {
                    return numero;
                }
                Console.WriteLine("Error. Entrada no válida");
            } while(true);
        }
    }
}
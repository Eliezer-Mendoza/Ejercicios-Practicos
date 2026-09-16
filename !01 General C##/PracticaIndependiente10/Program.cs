using System;
namespace Mierdaporquemelevantepensandoporesonoduermobienfuck
{
    class QuieroDormir
        {
        static void Main(string[] args)
        {
          // yo que recuerde se declaraba asi int[] lados = new int lados, si ya me di cuenta xd
          int[] lados = new int[4]; 
          int suma;
          int resultado;
          for (int i = 0; i <lados.Length; i++)
            {
                Console.WriteLine("Ingrese los 4 lados");
               Console.WriteLine("Lado1:"); lados[0] = PedirDato();
                Console.WriteLine("Lado2:");   lados[1] = PedirDato();
                  Console.WriteLine("Lado3:");   lados[2] = PedirDato();
                     Console.WriteLine("Lado4:");  lados[3] = PedirDato();
                     suma = lados[0] + lados[1] + lados [2] + lados[3];
                     resultado = suma/4;
                     if (resultado == lados[0])
                {
                    Console.WriteLine("Los 4 lados son iguales");
                }
                else
                {
                    Console.WriteLine("No son iguales los lados.");
                }
            }
        }
        static int PedirDato()
        {
            string entrada;
            int n;
            do
            {
                entrada = Console.ReadLine();
                if(int.TryParse(entrada, out n) && n>0)
                {
                    return n;
                }
                Console.WriteLine("Asigne un numero valido.");
            } while(true);
        }
    }
}
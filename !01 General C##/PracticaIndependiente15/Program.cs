using System;
namespace Eje
{
    class Principal
    {
        static void Main(string[] args)
        {
            int[] nums = new int[5];
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"Ingrese el número {i + 1}: ");
                nums[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("\nAhora ingrese el pbjetivo: ");
            int target = int.Parse(Console.ReadLine());
            int[] resultado = TwoSums(nums, target);
            if (resultado != null)
            {
                int pos1 = resultado[0];
                int pos2 = resultado[1];
                Console.WriteLine("\n=================================");
                Console.WriteLine($"Existe combinacion");
                Console.WriteLine($"Posiciones en el arreglo: [{pos1}, {pos2}]");
                Console.WriteLine($"Operacion: {nums[pos1]} + {nums[pos2]} = {target}");
                Console.WriteLine("=================================");
            }
            else
            {
                Console.WriteLine("\nNo existe ninguna combinacion en el arreglo que sume el objetivo.");
            }
        }
        static int[] TwoSums(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j }; 
                    }
                }
            }
            return null; 
        }
    }
}
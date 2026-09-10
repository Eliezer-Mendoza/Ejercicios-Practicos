// DINAMICA DE HACER UN EJERCICIO DE C# LO MAS RAPIDO POSIBLE DENTRO DEL RANGO DE 10 MINUTOS.
namespace Programm
{
    class Princiaplñ
    {
        static void Main(string[] args)
        {
            do{
                try{
            Console.WriteLine("Ingrese numeros en los arreglos.");
            int[] numero = new int[5];
            for (int i = 0; i < numero.Length; i++)
            {
                Console.Write("Ingrese el numero {0}: ", i + 1);
                numero[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("El arreglo invertido es: ");
            for (int i = numero.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(numero[i]);
            }
                } catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese un número válido.");
                }
            } while (true);
            
        }
    }
}

// Como debió ser:namespace Programm
// {
//     class Principal
//     {
//         static void Main(string[] args)
//         {
//             do {
//                 try {
//                     Console.WriteLine("Ingrese números en los arreglos.");
//                     int[] numero = new int[5];
                    
//                     // 1. Llenar el arreglo (Tu código original, perfecto)
//                     for (int i = 0; i < numero.Length; i++)
//                     {
//                         Console.Write("Ingrese el numero {0}: ", i + 1);
//                         numero[i] = Convert.ToInt32(Console.ReadLine());
//                     }

//                     // 2. INVERTIR EL ARREGLO EN MEMORIA (La magia algorítmica)
//                     int limite = numero.Length / 2; // Solo llegamos a la mitad
//                     for (int i = 0; i < limite; i++)
//                     {
//                         int temp = numero[i]; // Guardamos el valor actual
                        
//                         // Sobrescribimos el actual con su espejo al final del arreglo
//                         numero[i] = numero[numero.Length - 1 - i]; 
                        
//                         // Sobrescribimos el espejo con el valor que guardamos
//                         numero[numero.Length - 1 - i] = temp; 
//                     }

//                     // 3. Comprobar que realmente se invirtió
//                     Console.WriteLine("\nEl arreglo internamente ahora es: ");
//                     // Fíjate que ahora lo imprimimos de izquierda a derecha (i++), 
//                     // porque el arreglo en sí ya está volteado.
//                     for (int i = 0; i < numero.Length; i++) 
//                     {
//                         Console.WriteLine(numero[i]);
//                     }
                    
//                     Console.WriteLine("-------------------------");
                    
//                 } catch (FormatException) {
//                     Console.WriteLine("Error: Ingrese un número válido.\n");
//                 }
//             } while (true);
//         }
//     }
// }

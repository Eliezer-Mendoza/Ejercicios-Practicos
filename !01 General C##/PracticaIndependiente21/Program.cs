using System;
using System.Collections.Generic; // Obligatorio para usar List<T>

class Program
{
    static void Main()
    {
        List<string> pets = new List<string>(); //[cite: 2]
        
        pets.Add("gato"); //[cite: 2]
        pets.Add("perro"); //[cite: 2]
        pets.Add("conejo"); //[cite: 2]
        pets.Add("hamster"); //[cite: 2]

        // Tu línea comentada en la imagen para eliminar un elemento por su valor:
        // pets.Remove("hamster");[cite: 2]

        // AQUÍ HARÁS LOS EJERCICIOS
        Console.WriteLine(pets[2]);
        Console.WriteLine("Total de elementos: " + pets.Count);
        pets.Insert(3, "loro");
        if (pets.Contains("perro"))
        {
            pets.Sort();
        }
        // Forma rápida de mostrar todos los elementos para ver tus resultados:
        Console.WriteLine("\nMascotas actuales:");
        foreach (string pet in pets) 
        { 
            Console.WriteLine("- " + pet); 
        }
    }
}
// Lo de la pila, ahora hacerlo en cola.
using System;
using System.Collections.Generic;
namespace PilasAColas{
class EjPilas
{
    static Queue<int> edades = new Queue<int>();
    static void Main()
    {
        int op;
        do
        {
            Console.WriteLine("\n1. Agregar\n2. Remover\n3. Remover todos\n4. Buscar\n5. Modificar \n6. Mostar \n7. Salir");
            Console.Write("Opción: ");
            op = LeerEntero();

            switch (op)
            {
                case 1: Agregar(); break;
                case 2: Remover(); break;
                case 3: RemoverTodos(); break;
                case 4: Buscar(); break;
                case 5: Modificar(); break;
                case 6: MostrarCola(); break;
                case 7: Console.WriteLine("Fin del programa."); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        } while (op != 7);
    }

    static int LeerEntero()
    {
        int n;
        while (!int.TryParse(Console.ReadLine(), out n))
            Console.Write("Ingrese un número válido: ");
        return n;
    }
    static int LeerEdad()
    {
        int edad;
        do
        {
            Console.Write("Edad (2-99): ");
            edad = LeerEntero();
            if (edad <= 1 || edad >= 100)
                Console.WriteLine("Error: la edad debe ser mayor que 1 y menor que 100.");
        } while (edad <= 1 || edad >= 100);
        return edad;
    }
    static void Agregar()
    {
        edades.Enqueue(LeerEdad());
        Console.WriteLine("Edad agregada.");
    }

    static void Remover()
    {
        if (edades.Count == 0) Console.WriteLine("La pila está vacía.");
        else Console.WriteLine($"Removida: {edades.Dequeue()}");
    }

    static void RemoverTodos()
    {
        edades.Clear();
        Console.WriteLine("Se removieron todas las edades.");
    }

    static void Buscar()
    {
        Console.Write("Edad a buscar: ");
        int edad = LeerEdad();
        Console.WriteLine(edades.Contains(edad) ? "Edad encontrada." : "Edad no encontrada.");
    }
    static void Modificar()
    {
        if (edades.Count == 0) { Console.WriteLine("La cola está vacía."); return; }

        Console.Write("Nueva edad: ");
        int nueva = LeerEdad();
        edades.Dequeue();
        edades.Enqueue(nueva);
        Console.WriteLine("Edad modificada.");
    }
    static void MostrarCola()
{
    if (edades.Count == 0)
    {
        Console.WriteLine("\nLa cola está vacía.");
        return;
    }

    Console.WriteLine("\n===== Cola =====");

    bool esPrimero = true;

    foreach (int edad in edades)
    {
            if (esPrimero)
        {
            Console.Write($"Primero -> | {edad} |");
            esPrimero = false;
        }
        else
        {
            Console.Write($"| {edad} |");
        }

        Console.Write(" ");
    }
    Console.WriteLine($" Cantidad de elementos: {edades.Count}");
}
}
}
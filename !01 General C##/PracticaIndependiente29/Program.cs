// Imagina que tienes una matriz bidimensional (un tablero de $N \times M$) llena de números enteros. 
// Tu misión es escribir un método en C# que recorra esta matriz en espiral,
//  comenzando desde la esquina superior izquierda (en el sentido de las agujas del reloj)
//  y devuelva una lista con todos los números en el orden exacto en que fueron visitados.

using System;
using System.Collections.Generic;

public class Program
{
    public static List<int> RecorrerEnEspiral(int[,] matriz)
    {
        List<int> resultado = new List<int>();
        
        // Usar un for y usando pivotes por cada uno para que haga la lista en espiral

        
        return resultado;
    }

    public static void Main()
    {
        int[,] matriz = {
            { 1,  2,  3,  4 },
            { 5,  6,  7,  8 },
            { 9, 10, 11, 12 },
            {13, 14, 15, 16 }
        };

        List<int> resultado = RecorrerEnEspiral(matriz);
        Console.WriteLine(string.Join(", ", resultado));
    }
}
// Crea una List<string> con los días de la semana de lunes a viernes.
// Escribe el código para imprimir los días en orden inverso (de viernes a lunes) sin utilizar el método nativo Reverse().
using System.ComponentModel;

namespace DiasSemana
{
    class Princiapl
    {
        static void Main(string[] args)
        {
            List <string> diasSemana = new List<string> {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes"};
            for( int i = 4; i >= 0;  i--)
            {
                System.Console.WriteLine("Arreglo inverso: " + diasSemana[i]);
            }
         }
    }
}
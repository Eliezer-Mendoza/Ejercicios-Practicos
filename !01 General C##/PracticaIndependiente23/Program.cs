// Ejercicio 2: El mejor y el peor
// Crea una List<double> con 6 calificaciones aleatorias (por ejemplo: 85.5, 90.0, 78.2, etc.).
// Escribe el código para encontrar y mostrar en consola exclusivamente la calificación más alta y la calificación más baja de esa lista.
using System.Reflection.Metadata;

namespace Lista2
{
    class Principal
    {
        static void Main(string[] args)
        {
            List<double> calificaciones = new List<double> {85.5, 90.0, 78.2, 20.3, 10.2, 99.8,};
            double alta, baja;
            alta = calificaciones.Max();
            baja = calificaciones.Min();
            System.Console.WriteLine($"Total de notas:    LA MAS ALTA: {alta},  LA MAS BAJA: {baja}");
        }
    }
}
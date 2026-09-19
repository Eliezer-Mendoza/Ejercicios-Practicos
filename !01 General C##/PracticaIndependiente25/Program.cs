// Ejercicio 4: Inventario inteligente
// Crea una List<string> con artículos de supermercado iniciales (ejemplo: "pan", "leche", "queso").
// El código debe evaluar el artículo "huevos". Si "huevos" ya existe en la lista, el programa debe imprimir en qué posición (índice) 
// se encuentra. Si no existe, debe agregarlo al final.
namespace Solucion
{
    class Principal
    {
        static void Main(string[] args)
        {
                List<string> supermercadoInicial = new List<string> {"pan", "leche", "queso", "huevos"};
                if (supermercadoInicial.Contains("huevos"))
            {
                System.Console.WriteLine("La palabra esta en el indice: " + supermercadoInicial.IndexOf("huevos"));
            }
            else
            {
                supermercadoInicial.Add("huevos");
                System.Console.WriteLine($"Se agrego a la lista dado que no existia inicialmente.");
            }
        }
    }
}
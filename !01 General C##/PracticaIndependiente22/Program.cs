// Crea una List<int> que contenga los siguientes números: 15, -5, 20, -1, 0, -10, 8.
// Escribe el código necesario para eliminar todos los números negativos de la lista. Al finalizar, imprime la lista resultante.
namespace Practica
{
    class Principal
    {
       
      static void Main(string[] args)
      {
         List<int> numeros = new List<int> { 15, -5, 20, -1, 0, -10, 8 };
         numeros.RemoveAll(numero => numero < 0);
         Console.WriteLine(string.Join(", ", numeros));
      }
    }
}
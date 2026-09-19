// Crea una List<string> con al menos 7 nombres de personas.
// El programa debe analizar esa lista y guardar en una nueva List<string> únicamente los nombres que tengan más de 5 letras. 
// Imprime los elementos de esta nueva lista.\
namespace ListaNombre
{
    class Principal
    {
      static void Main(string[] args)
      {
          List<string> Nombres = new List<string> {"Pepito", "Lolo", "Muneca", "Tonito", "Aurelio", "Ste", "Nanel"};
               List<string> MayorA5 = new List<string> {};
          foreach(string nombres in Nombres)
            {
                if (nombres.Length > 5)
                {
                    MayorA5.Add(nombres);
                }
            }
                System.Console.WriteLine($"Nombres con mas de 5 letras: " + string.Join(", ",MayorA5));
      }
    }
}

// Verificar de una cadena de substring si esa cadena es considerada palindrome o no.
// Para que una funcion sea considerada palindrome se tiene que tener en cuenta lo siguiente:
// que la palabra sea la misma cuando se lee de ambas formas, izquierda o derecha.
namespace Ejercicio12
{
    class Principal
    {
        static string Validar()
        {
            while(true)
            {
                string entrada;
                entrada = Console.ReadLine() ?? "";
                if (EsAlfabetica(entrada))
                {
                    return entrada;
                }
                Console.WriteLine("No se permiten numeros o símbolos. Por favor ingrese una palabra de orden alfabetico");
            }
        }
         static bool EsAlfabetica(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
            {
                return false;
            }

            return cadena.All(char.IsLetter);
        }
        static string Invertir(string palabra)
        {
            if(string.IsNullOrEmpty(palabra))
            {
                return palabra;
            }
            char[] caracteres = palabra.ToCharArray();
            Array.Reverse(caracteres);
            return new string(caracteres);
        }
    static bool EsPalindrome(string palabra, string invertida)
        {
            return palabra.Equals(invertida, StringComparison.OrdinalIgnoreCase);
        }
        static string MostrarResultado(bool esPalindrome)
        {
            if (esPalindrome == true)
            {
                return "Es palindrome";
            }
            return "No es palindromo";
        }
        static void Main(string[] args)
        {
            try
            {
                string palabra;
                Console.WriteLine("Ingrese una palabra.");
                palabra = Validar();
                string invertida = Invertir(palabra);
                bool resultado = EsPalindrome(palabra, invertida);
                Console.WriteLine(MostrarResultado(resultado));
            }
            catch (Exception)
            {
                Console.WriteLine("Algo ocurrio");
            }
        }
    }
}
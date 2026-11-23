// Lo que tenia en mente en la mañana, algoritmo de aleatoriedad con juego del impostor 
namespace Aleatoriedad
{
    class Im
    {
        static void Main(string[] args)
        {
                List<string> Jugadores = new List<string>();

                System.Console.WriteLine("Bienvenido al juego del impostor. Por favor ingrese la cantidad de jugadores a jugar");
                int cantidadJugadores = ValidarDato();

                for(int i=1; i<cantidadJugadores; i++)
            {
                string Nombre = VerificarNombres();
                Jugadores.Add(Nombre);
            }
            // usar libreria de c# "Random" o hacer el algoritmo de 0. 
            // tambien pensar en las variables para retornar el impostor. huh
        }
        static string  VerificarNombres()
        {
            string input;
            bool check;
            do
            {
                System.Console.WriteLine("Ingrese el nombre del jugador: {numeroJugador}");
                input = Console.ReadLine();
                check = !string.IsNullOrEmpty(input);
                if (!check)
                {
                    System.Console.WriteLine("El jugador no puede tener caracteres vacios.");
                }
            } while(!check);
            return input.Trim();
        }
        static int ValidarDato()
        {
            int n;
            string entrada;
            do
            {
                entrada = Console.ReadLine();
                if(int.TryParse(entrada, out n) && n>0)
                {
                    return n;
                }
                System.Console.WriteLine("No se pueden ingresar jugadores negativos o letras. Vuelva a intentarlo de nuevo");
            } while(true);
        }
    }
}
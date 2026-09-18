// // No me gusta declarar lista asi fak las odio 
// Intenta agregar estos métodos dentro de la clase ListaBasica. Resuélvelos uno por uno y pruébalos en el Main.

// Ejercicio 1: Contar los elementos (Nivel Básico)
// Crea un método llamado Contar() que devuelva un número entero con la cantidad de nodos que hay en la lista.

// Pista: Necesitas un contador en 0, un nodo actual que empiece en inicio, y un while que sume +1 al contador cada vez que 
// salte al siguiente nodo.

// Prueba en el Main: Console.WriteLine("Total: " + miLista.Contar());
namespace FokinLista
{
    class Nodo
    {
        public int Contador;
        public Nodo Siguiente;
        public Nodo(int contador)
        {
            Contador = contador;
            Siguiente = null;
        }
    }
    class ListaSimpleEnlazadaxd
    {
        private Nodo inicio;

        public void Agregar()
        {
            
        }
    }
}
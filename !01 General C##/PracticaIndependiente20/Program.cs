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

        public void Agregar(int contador)
        {
            Nodo nuevo = new Nodo(contador);
            nuevo.Siguiente = inicio;
                inicio = nuevo;
        }
        public void Mostrar()
        {
            Nodo actual = inicio;
            Console.WriteLine("Lista actual: ");
            while(actual != null)
            {

                Console.WriteLine(actual.Contador + "--->");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null\n");
        }
        public int Contar()
{
    int total = 0;           // Empezamos a contar desde cero
    Nodo actual = inicio;    // Nos paramos en el primer vagón

    while(actual != null)    // Mientras haya un vagón donde pisar...
    {
        total++;                   // Sumamos 1 a nuestra cuenta
        actual = actual.Siguiente; // Saltamos al siguiente vagón
    }

    return total; // Cuando el while termina (llegó a null), devolvemos el total
}
    }
    class Principal
    {
        static void Main(string[] args)
        {
            ListaSimpleEnlazadaxd miLista = new ListaSimpleEnlazadaxd();
            miLista.Agregar(12);
            miLista.Agregar(14);
            miLista.Agregar(19);
            Console.WriteLine("Datos: "); miLista.Mostrar();
            Console.WriteLine("Contador: " + miLista.Contar());
        }
    }
}
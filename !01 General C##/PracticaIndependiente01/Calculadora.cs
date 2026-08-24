using System;

namespace espacio
{
    class Publica
    {
        // Método que recibe un parámetro por valor (crea una copia)
        static void ProbarValor(int num)
        {
            num = 20; // Esto solo cambia la copia local
        }

        // Método que recibe un parámetro por referencia (modifica el original)
        static void ProbarReferencia(ref int num)
        {
            num = 25; // Esto modifica la variable original en memoria
        }

        public static void Main(string[] args)
        {
            int numeroValor = 10;
            int numeroReferencia = 10;

            // Llamamos al método por valor
            ProbarValor(numeroValor);
            
            // Llamamos al método por referencia (es obligatorio usar la palabra 'ref' aquí también)
            ProbarReferencia(ref numeroReferencia);

            // Resultados en consola
            Console.WriteLine("Este es un numero por valor: " + numeroValor);       // Imprimirá 10 (no cambió)
            Console.WriteLine("Este es un numero por referencia: " + numeroReferencia); // Imprimirá 25 (sí cambió)
        }
    }
}
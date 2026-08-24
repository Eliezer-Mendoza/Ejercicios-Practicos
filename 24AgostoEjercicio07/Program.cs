// Reforzamiento de Arreglos
// Manejados a través de subíndices. 
// Ya sea en 0... n-1 o 1....n
// Vector ya sean en x
// Matriz en x por y
// 2 Subindices en matriz en ciertos casos
// No realizan almacenamiento permanentemente. 
// Entrada, proceso, salida. Retroalimentacion si no se cumple. Eso se le llama enfoque sistemico.
// otras estructuras de datos: Estructuras de Datos
// 1. Pilas, Apilar. Desapilar. Lllena, luego desllena, desbordamiento o insuficiente pilas, Last in, last out.
// Agregar, remover, remover todo, buscar elementos de la pila, etc.
// se usa a nivel de sistema operativo.
// 2. Colas. Es fijo, first in, first out. agotamiento de cola.
// se usa en redes. comunicaciones. 
// 3. Listas dinamicas, las otras 2 son estáticas.
// meter donde quiera, sacar donde quiera.
// lista enlazada, lista doblemente enlazada, lista circular, lista circular doblemente enlazada.
// voy metiendo registro.
// con lista / arraylist simular una base de datos. y las listas son utilizadas en ambitos de desarrollo.
// mecanismo de almacenamiento permanente.
// usar excepciones para evitar desbordamientos.

// hacer un programa de vector, en ese vector el primer indice va ser la cantidad entre 1 y 8
// el 2do mayor a 1 y menor a 1800
// el 3ro caer el 1ro con el 2do. al menos 8
// el 1ro es la cantidad de producto y el 2do va ser el precio, se multiplica la cantidad de 
// producto por el precio
// Dimension[]
// 1 a 8 cantidad, 1 a 1800 precio. no pueden ser negativos. manejo de excepciones 
// Un vector de 3 posiciones, para empezar hay que hacer un catch de desborde. En 4 no en 3, para cada producto, maximo 10 productos, cuantos va a llevar del 1 a 10.
// hasta despues por aninado, para la 1ra, gestiono la cantidad 1 a 8, 2da posicion precio, 3ra multiplico 1 a 2, hasta que termine la cantidad. 10 veces, etc.
// mecanismos de validacion con repetitiva.
namespace Practica07
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
           int[] n1 = new int[4];
            int precio = 0;
            int cantidad = 0;
            int total = 0;
            int agarrarProducto = 0;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Ingrese cuantos productos va a agarrar");
                agarrarProducto = validarProductos();
                n1[0] = agarrarProducto;
                for (int j = 0; j < agarrarProducto; j++)
                {
                Console.WriteLine("Ingrese la cantidad");
                cantidad = validarCantidad();
                n1[1] = cantidad;
                Console.WriteLine("Ingrese el precio");
                precio = validarPrecio();
                n1[2] = precio;
                n1[3] = n1[1] * n1[2];
                total = n1[3];
                Console.WriteLine("El total es: " + total);
                Console.WriteLine("La cantidad es: " + n1[0]);
                Console.WriteLine("El precio es: " + n1[1]);
            } 
            }
            } catch (OverflowException)
            {
                Console.WriteLine("Algo ocurrio");
            }
        }
        static int validarCantidad()
        {
            string input;
            int cantidad;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out cantidad))
                {
                    if (cantidad > 0 && cantidad <= 10)
                    {
                        return cantidad;
                    }
                    Console.WriteLine("Ingrese un valor entre 1 y 10");
                }
                else
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (true);
        }
        static int validarProductos()
        {
            string input;
            int productos;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out productos))
                {
                    if (productos > 0 && productos <= 4)
                    {
                        return productos;
                    }
                    Console.WriteLine("Ingrese un valor entre 1 y 4");
                }
                else
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (true);
        }
        static int  validarPrecio()
        {
            string input;
            int precio;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out precio))
                {
                    if (precio > 0 && precio <= 1800)
                    {
                        return precio;
                    }
                    Console.WriteLine("Ingrese un valor entre 1 y 1800");
                }
                else
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (true);
        }
    }
}

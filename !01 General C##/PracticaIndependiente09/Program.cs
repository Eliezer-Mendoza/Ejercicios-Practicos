using System;
using System.Collections.Generic;
// Un simulador modular para la atención de clientes en un banco.
// Los clientes entran a una cola de atención (atendidos según orden de llegada, FIFO)
// Por cada transacción realizada, se genera un comprobante de auditoría que se apila en una pila física de papeleo
//  de la oficina (auditoría en orden LIFO)

// Una cola que agregue estudiantes y muestre el que se este atendiendo y ya.
namespace Practica09
{
    class Principal
    {
          Queue<string> nombresEstudiantes = new Queue<string>();
        static void Main(string[] args)
        {
            int opcion;
          
            Console.WriteLine("Bienvenido al control de estudiantes de la UNI");
            Console.WriteLine("Por favor, escoja unas opciones. \n 1. Anadir estudiante. \n 2. Ver cola. \n 3. Borrar cola. \n 4. Salir del programa");
            opcion = Validar();
            switch(opcion)
            {
                case 1:
                AgregarEstudiante();
                case 2:

                case 3:

                case 4: Console.WriteLine("Saliendo del programa...");
                 break;
            }
        }
        static void AgregarEstudiante()
        {
            nombresEstudiantes.Enqueue();

        }
        static int Validar()
        {
            string entrada;
            int numero;
            while(true)
            {
                entrada = Console.ReadLine();
                if(int.TryParse(entrada, out numero) && numero>0)
                {
                    return numero;
                }
                Console.WriteLine("Entrada no valida, por ingrese un numero mayor que cero. No se aceptan letras o caracteres especiales");
            }
        }
        static string ValidarChar()
        {
            string 
            {
                Console.WriteLine("La cadena no puede contener caracteres especiales o numeros.";
            }
        }
    }
}
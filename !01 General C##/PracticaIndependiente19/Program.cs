// Simulacion de Navegador web:
// Pedir al usuario un link, luego eso se agrega a la pila
// Elimina la pila actual con pop para retroceder a la anterior.
// Que muestre la pagina actual con Peek
// Salir del programa.
using System.Collections.Generic;
using System;
using System.Net;
namespace PilasWeb
{
    class Principal
    {
       
        static void Main(string[] args)
        {
             Stack<string>Pagina = new Stack<string>();
            int op = 0;
            do
            { try{
                System.Console.WriteLine("Seleccione una opcion: \n 1. Agregar una pagina web. \n 2. Eliminar la web actual. \n 3. Ver la pagina actual. \n 4. Ver todas las paginas. \n 5. Salir del programa.");
              if (!int.TryParse(Console.ReadLine(), out op))
                    {
                        System.Console.WriteLine("Por favor ingrese una entrada valida, no se admiten letras.");
                    }
                switch(op)
                {
                    case 1: AgregarWeb(Pagina); break;
                    case 2: RemoverPaginaActual(Pagina); break;
                    case 3: VerPaginaActual(Pagina); break;
                    case 4: VerTodasLasPaginas(Pagina); break;
                    case 5: System.Console.WriteLine("Saliendo del sistema..."); break;
                    default: System.Console.WriteLine("Por favor ingrese un numero del 1 al 4."); break;
                }
            } catch (Exception ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}. Intentelo de nuevo.");
                }
            } while(op!=5);
        }
        static void VerTodasLasPaginas(Stack<string> Pagina)
        {
            if(Pagina.Count>0)
            {
                System.Console.WriteLine("Historial de las paginas anadidas: ");
                foreach(string web in Pagina)
                {
                    Console.Write($"\t - {web} - \n ");
                }
            }
            else
            {
                System.Console.WriteLine("No hay paginas por mostrar...");
            }
        }
        static void VerPaginaActual(Stack<string> Pagina)
        {
            if (Pagina.Count > 0)
            {
                System.Console.WriteLine($"Pagina Actual: {Pagina.Peek()}");
            }
            else
            {
                System.Console.WriteLine("No hay historial o paginas para ver en este momento, por favor agregue una...");
            }
        }
        static void AgregarWeb(Stack<string> Pagina)
        {
            string web;
            do{
            System.Console.WriteLine("Ingrese la URL que desea agregar: ");
            web = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(web))
                {
                    Pagina.Push(web);
                    System.Console.WriteLine($"Pagina {web} agregada.");
                    break;
                }
            System.Console.WriteLine("Por favor, agregue una URL valida, no puede contener espacios o null.");
            } while(true);
        }
        static void RemoverPaginaActual(Stack<string> Pagina)
        {
            if (Pagina.Count > 0)
            {
                String removida = Pagina.Pop();
                 System.Console.WriteLine($"Se ha removido {removida}.");
            if (Pagina.Count > 0)
            {
                System.Console.WriteLine($"Pagina Actual: {Pagina.Peek()}");
            }
            else
            {
                System.Console.WriteLine("El historial esta vacio");
            }
        }
            else
            {
                System.Console.WriteLine("No hay elementos para remover.");
            }
        }
    }
}
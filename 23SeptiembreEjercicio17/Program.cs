using System;
using System.Collections;
using System.ComponentModel.Design;
namespace OrdenamientoBurbuja
{
    class Burbuja
    {
        const int MIN_TAMANIO = 1;
        const int MAX_TAMANIO = 100;

        const int MIN_VALOR = 1;
        const int MAX_VALOR = 1000000;
        
        static void Menu()
        {
            System.Console.WriteLine("Bienvenido al menu. Seleccione un algortimo de ordenamiento: \n 1. Burbuja. \n 2. Insercion. \n 3. Seleccion. \n 4. Salir");
        }

        static void Main(string[] args)
        {
               int Opcion = 0;
            do {
             
                try
                {
                    
                    Console.Clear();

                    Console.WriteLine("==============================================");
                    Console.WriteLine("    Algoritmos de Ordenamiento  ");
                    Console.WriteLine("==============================================");
                    Console.WriteLine();
                    Menu();
                    System.Console.WriteLine("Su opcion: ");
                     Opcion = LeerOpcion();
                    switch (Opcion)
                    {
                        case 1:
                        MetodoBurbuja();
                        break;
                        case 2: 
     MetodoInsercion();
     break;
                        case 3:
MetodoPorSeleccion();
break;
                        case 4: System.Console.WriteLine("Saliendo del sistema."); break;
                    }
                }
            

                catch (OverflowException)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: El valor introducido es demasiado grande.");
                    Pausar();
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: Se introdujo un formato no válido.");
                    Pausar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR INESPERADO: " + ex.Message);
                    Pausar();
                }
            } while (Opcion !=4);
            

            Console.WriteLine();
            Console.WriteLine("Programa finalizado correctamente.");
        }
        static void MetodoInsercion()
        {
                                  Console.Clear();

                    Console.WriteLine("==============================================");
                    Console.WriteLine("       ORDENAMIENTO POR INSERCIÓN - C#");
                    Console.WriteLine("==============================================");
                    Console.WriteLine();
                    int tamano = LeerTamanio();
                    int[] v = new int[tamano];
                    LeerVector(v);
                    Console.WriteLine();
                    Console.WriteLine("Vector original:");
                    MostrarVector(v);
                    OrdenarInsercion(v);
                    Console.WriteLine();
                    Console.WriteLine(
                        "Vector ordenado de forma ascendente:"
                    );
                    MostrarVector(v);
        }
        static void MetodoBurbuja()
        {
                    int tamanio = LeerTamanio();
                    int[] vector = new int[tamanio];
                    LeerVector(vector);
                    Console.WriteLine();
                    Console.WriteLine("Vector original:");
                    MostrarVector(vector);
                    OrdenarBurbuja(vector);
                    Console.WriteLine();
                    Console.WriteLine("Vector ordenado de forma ascendente:");
                    MostrarVector(vector);
        }
        static void MetodoPorSeleccion()
        {     
                    Console.Clear();
                    Console.WriteLine("==============================================");
                    Console.WriteLine("       ORDENAMIENTO POR SELECCIÓN - C#");
                    Console.WriteLine("==============================================");
                    Console.WriteLine();
                    int taman = LeerTamanio();
                    int[] vec = new int[taman];
                    LeerVector(vec);
                    Console.WriteLine();
                    Console.WriteLine("Vector original:");
                    MostrarVector(vec);
                    OrdenarSeleccion(vec);
                    Console.WriteLine();
                    Console.WriteLine("Vector ordenado de forma ascendente:");
                    MostrarVector(vec);  
        }
        static void OrdenarSeleccion(int[] vector)
        {
            int n = vector.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int posicionMenor = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (vector[j] < vector[posicionMenor])
                    {
                        posicionMenor = j;
                    }
                }
                if (posicionMenor != i)
                {
                    Intercambiar(
                        vector,
                        i,
                        posicionMenor
                    );
                }
            }
        }
        static int LeerTamanio()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el tamaño del vector (1-100): ");
                    string entrada = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        Console.WriteLine("ERROR: No puede dejar el campo vacío.");
                        continue;
                    }
                    int tamanio = int.Parse(entrada);

                    if (tamanio < MIN_TAMANIO || tamanio > MAX_TAMANIO)
                    {
                        Console.WriteLine(
                            $"ERROR: El tamaño debe estar entre {MIN_TAMANIO} y {MAX_TAMANIO}."
                        );

                        continue;
                    }
                    return tamanio;
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "ERROR: Debe introducir únicamente números enteros."
                    );
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "ERROR: El número introducido es demasiado grande."
                    );
                }
            }
        }
        static void LeerVector(int[] vector)
        {
            Console.WriteLine();
            Console.WriteLine("Ingrese los elementos del vector.");
            Console.WriteLine(
                $"Los valores permitidos están entre {MIN_VALOR} y {MAX_VALOR}."
            );
            Console.WriteLine();

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = LeerElemento(i);
            }
        }
        static int LeerElemento(int posicion)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Ingrese el elemento [{posicion}]: ");
                    string entrada = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        Console.WriteLine(
                            "ERROR: El valor no puede estar vacío."
                        );

                        continue;
                    }
                    // ----------------------------------------------
                    foreach (char caracter in entrada)
                    {
                        if (char.IsLetter(caracter))
                        {
                            Console.WriteLine(
                                "ERROR: No se permiten letras."
                            );

                            entrada = null;
                            break;
                        }
                    }

                    if (entrada == null)
                    {
                        continue;
                    }
                    int valor = int.Parse(entrada);
                    if (valor < 0)
                    {
                        Console.WriteLine(
                            "ERROR: No se permiten valores negativos."
                        );

                        continue;
                    }
                    if (valor == 0)
                    {
                        Console.WriteLine(
                            "ERROR: El valor cero no está permitido."
                        );

                        continue;
                    }
                    if (valor < MIN_VALOR || valor > MAX_VALOR)
                    {
                        Console.WriteLine(
                            $"ERROR: El valor debe estar entre " +
                            $"{MIN_VALOR} y {MAX_VALOR}."
                        );

                        continue;
                    }

                    return valor;
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "ERROR: Debe introducir únicamente números enteros."
                    );
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "ERROR: El número introducido excede el límite permitido."
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "ERROR inesperado: " + ex.Message
                    );
                }
            }
        }
        static void OrdenarBurbuja(int[] vector)
        {
            int n = vector.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool huboIntercambio = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        Intercambiar(vector, j, j + 1);

                        huboIntercambio = true;
                    }
                }
                if (!huboIntercambio)
                {
                    break;
                }
            }
        }
        static void Intercambiar(int[] vector, int posicion1, int posicion2)
        {
            int auxiliar = vector[posicion1];

            vector[posicion1] = vector[posicion2];

            vector[posicion2] = auxiliar;
        }
        static void MostrarVector(int[] vector)
        {
            Console.Write("[ ");

            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i]);

                if (i < vector.Length - 1)
                {
                    Console.Write(" | ");
                }
            }

            Console.WriteLine(" ]");
        }

static void OrdenarInsercion(int[] vector)
        {
            for (int i = 1; i < vector.Length; i++)
            {
                int elementoActual = vector[i];
                int j = i - 1;
                while (j >= 0 &&
                       vector[j] > elementoActual)
                {
                    vector[j + 1] = vector[j];

                    j--;
                }
                vector[j + 1] = elementoActual;
            }
        }
        static int LeerOpcion()
        {
            while (true)
            {
                try
                {
                    Console.Write("Seleccione una opción: ");

                    string entrada = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        Console.WriteLine(
                            "ERROR: Debe seleccionar una opción."
                        );

                        continue;
                    }

                    int opcion = int.Parse(entrada);

                    if (opcion<1 || opcion>4)
                    {
                        Console.WriteLine(
                            "ERROR: Seleccione un rangod de 1 a 4"
                        );

                        continue;
                    }

                    return opcion;
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "ERROR: Debe introducir un número."
                    );
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "ERROR: El número introducido es demasiado grande."
                    );
                }
            }
        }
        static void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

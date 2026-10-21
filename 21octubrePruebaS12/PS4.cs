// Elaborar una aplicación consola en C# capaz de captar en un vector denominado prueba con longitud de 30, 
// las letras del alfabeto entre la a y z minúscula o entre la A y Z mayúscula, la inserción deberá garantizar 
// que no se incluyan números ni caracteres especiales en el vector. Primeramente deberá consultar al usuario que cantidad de letras 
// deberá insertar entre 2 y 30. Luego en un menú permítale seleccionar el método de ordenamiento entre quick sort y merge sort
//  ya sea de manera ascendente o de manera descendente. Validar todo lo que este sujeto a validación. 
// Manejar todas las excepciones necesarias y trabajar con modularidad.
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            char[] prueba = new char[30];
            bool repetirPrograma = true;

            while (repetirPrograma)
            {
                int cantidad = SolicitarCantidad();
                IngresarLetras(prueba, cantidad);

                int opcion = 0;
                bool opcionValida = false;
                while (!opcionValida)
                {
                    try
                    {
                        Console.WriteLine("\n--- Menu de ordenamiento ---");
                        Console.WriteLine("1. Quick Sort");
                        Console.WriteLine("2. Merge Sort");
                        Console.Write("Seleccione una opcion: ");

                        string entradaOpcion = Console.ReadLine();
                        if (entradaOpcion == null)
                        {
                            Environment.Exit(0);
                        }

                        if (string.IsNullOrEmpty(entradaOpcion))
                        {
                            Console.WriteLine("Error: La opcion no puede estar vacia.");
                            continue;
                        }

                        opcion = Convert.ToInt32(entradaOpcion);
                        if (opcion == 1 || opcion == 2)
                        {
                            opcionValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Error: Opcion invalida.");
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Error: La entrada no puede ser nula.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Formato de entrada incorrecto.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Error: El valor ingresado es demasiado grande o pequeño.");
                    }
                }

                int orden = 0;
                bool ordenValido = false;
                while (!ordenValido)
                {
                    try
                    {
                        Console.WriteLine("1. Ascendente");
                        Console.WriteLine("2. Descendente");
                        Console.Write("Seleccione el orden: ");
                        
                        string entradaOrden = Console.ReadLine();
                        if (entradaOrden == null)
                        {
                            Environment.Exit(0);
                        }

                        if (string.IsNullOrEmpty(entradaOrden))
                        {
                            Console.WriteLine("Error: El orden no puede estar vacio.");
                            continue;
                        }

                        orden = Convert.ToInt32(entradaOrden);
                        if (orden == 1 || orden == 2)
                        {
                            ordenValido = true;
                        }
                        else
                        {
                            Console.WriteLine("Error: Opcion de orden invalida.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Formato de entrada incorrecto.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Error: El valor ingresado es demasiado grande o pequeño.");
                    }
                }

                char[] copia = new char[cantidad];
                Array.Copy(prueba, copia, cantidad);

                if (opcion == 1)
                {
                    QuickSort(copia, 0, cantidad - 1, orden == 1);
                }
                else
                {
                    MergeSort(copia, 0, cantidad - 1, orden == 1);
                }

                Console.WriteLine("Vector ordenado:");
                MostrarVector(copia, cantidad);

                bool respuestaValida = false;
                while (!respuestaValida)
                {
                    Console.Write("\n¿Desea ingresar nuevos valores? (SI/NO): ");
                    string respuesta = Console.ReadLine();
                    
                    if (respuesta == null)
                    {
                        Environment.Exit(0);
                    }

                    if (string.IsNullOrEmpty(respuesta))
                    {
                        Console.WriteLine("Error: La respuesta no puede estar vacia.");
                        continue;
                    }

                    string respuestaTrim = respuesta.Trim().ToLower();
                    if (respuestaTrim == "si" || respuestaTrim == "s")
                    {
                        repetirPrograma = true;
                        respuestaValida = true;
                    }
                    else if (respuestaTrim == "no" || respuestaTrim == "n")
                    {
                        repetirPrograma = false;
                        respuestaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Debe ingresar SI o NO.");
                    }
                }
            }
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Error critico: Memoria insuficiente en el sistema.");
        }
        catch (System.IO.IOException)
        {
            Console.WriteLine("Error critico: Fallo en el flujo de entrada y salida de datos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrio un error critico: " + ex.Message);
        }
    }

    static int SolicitarCantidad()
    {
        int cantidad = 0;
        bool valido = false;
        while (!valido)
        {
            try
            {
                Console.Write("Ingrese la cantidad de letras a insertar (entre 2 y 30): ");
                string entrada = Console.ReadLine();
                if (entrada == null)
                {
                    Environment.Exit(0);
                }

                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Error: La entrada no puede estar vacia.");
                    continue;
                }

                cantidad = Convert.ToInt32(entrada);
                if (cantidad >= 2 && cantidad <= 30)
                {
                    valido = true;
                }
                else
                {
                    Console.WriteLine("Error: La cantidad debe estar entre 2 y 30.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un numero entero valido.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Numero fuera del rango permitido.");
            }
        }
        return cantidad;
    }

    static void IngresarLetras(char[] vector, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            bool valido = false;
            while (!valido)
            {
                try
                {
                    Console.Write($"Ingrese la letra {i + 1}: ");
                    string entrada = Console.ReadLine();

                    if (entrada == null)
                    {
                        Environment.Exit(0);
                    }

                    if (string.IsNullOrEmpty(entrada))
                    {
                        Console.WriteLine("Error: La entrada no puede estar vacia.");
                        continue;
                    }

                    if (entrada.Length != 1)
                    {
                        Console.WriteLine("Error: Debe ingresar exactamente un caracter.");
                        continue;
                    }

                    char letra = entrada[0];
                    if ((letra >= 'a' && letra <= 'z') || (letra >= 'A' && letra <= 'Z') || letra == 'ñ' || letra == 'Ñ')
                    {
                        vector[i] = letra;
                        valido = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Solo se permiten letras de la a a la z y la ñ.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error al procesar la entrada.");
                }
            }
        }
    }

    static void QuickSort(char[] vector, int inicio, int fin, bool ascendente)
    {
        if (inicio < fin)
        {
            int pivoteIndex = Particionar(vector, inicio, fin, ascendente);
            QuickSort(vector, inicio, pivoteIndex - 1, ascendente);
            QuickSort(vector, pivoteIndex + 1, fin, ascendente);
        }
    }

    static int Particionar(char[] vector, int inicio, int fin, bool ascendente)
    {
        char pivote = vector[fin];
        int i = inicio - 1;

        for (int j = inicio; j < fin; j++)
        {
            bool condicion = ascendente ? (vector[j] <= pivote) : (vector[j] >= pivote);
            if (condicion)
            {
                i++;
                char temp = vector[i];
                vector[i] = vector[j];
                vector[j] = temp;
            }
        }

        char temp2 = vector[i + 1];
        vector[i + 1] = vector[fin];
        vector[fin] = temp2;

        return i + 1;
    }

    static void MergeSort(char[] vector, int inicio, int fin, bool ascendente)
    {
        if (inicio < fin)
        {
            int medio = inicio + (fin - inicio) / 2;
            MergeSort(vector, inicio, medio, ascendente);
            MergeSort(vector, medio + 1, fin, ascendente);
            Merge(vector, inicio, medio, fin, ascendente);
        }
    }

    static void Merge(char[] vector, int inicio, int medio, int fin, bool ascendente)
    {
        int n1 = medio - inicio + 1;
        int n2 = fin - medio;

        char[] izq = new char[n1];
        char[] der = new char[n2];

        for (int i = 0; i < n1; i++)
            izq[i] = vector[inicio + i];
        for (int j = 0; j < n2; j++)
            der[j] = vector[medio + 1 + j];

        int k = inicio;
        int x = 0, y = 0;

        while (x < n1 && y < n2)
        {
            bool condicion = ascendente ? (izq[x] <= der[y]) : (izq[x] >= der[y]);
            if (condicion)
            {
                vector[k] = izq[x];
                x++;
            }
            else
            {
                vector[k] = der[y];
                y++;
            }
            k++;
        }

        while (x < n1)
        {
            vector[k] = izq[x];
            x++;
            k++;
        }

        while (y < n2)
        {
            vector[k] = der[y];
            y++;
            k++;
        }
    }

    static void MostrarVector(char[] vector, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            Console.Write(vector[i] + " ");
        }
        Console.WriteLine();
    }
}
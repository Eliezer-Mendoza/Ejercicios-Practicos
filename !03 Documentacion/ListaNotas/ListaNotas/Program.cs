    using System;

namespace ListaSimplementeEnlazada
{
    // Clase que representa cada nodo de la lista
    class Nodo
    {
        public double Nota;
        public Nodo Siguiente;

        public Nodo(double nota)
        {
            Nota = nota;
            Siguiente = null;
        }
    }

    // Clase que administra la lista simplemente enlazada
    class ListaEnlazada
    {
        private Nodo inicio;

        // Constructor
        public ListaEnlazada()
        {
            inicio = null;
        }

        // 1. Agregar al inicio
        public void AgregarInicio(double nota)
        {
            Nodo nuevo = new Nodo(nota);

            nuevo.Siguiente = inicio;
            inicio = nuevo;

            Console.WriteLine("Nota agregada correctamente al inicio.");
        }

        // 2. Agregar en cualquier posición
        public void AgregarPosicion(double nota, int posicion)
        {
            if (posicion < 0)
            {
                throw new ArgumentException("La posición no puede ser negativa.");
            }

            // Si la posición es 0, se agrega al inicio
            if (posicion == 0)
            {
                AgregarInicio(nota);
                return;
            }

            Nodo actual = inicio;

            // Avanzar hasta el nodo anterior a la posición
            for (int i = 0; i < posicion - 1 && actual != null; i++)
            {
                actual = actual.Siguiente;
            }

            if (actual == null)
            {
                throw new ArgumentException("La posición no existe en la lista.");
            }

            Nodo nuevo = new Nodo(nota);

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;

            Console.WriteLine("Nota agregada correctamente en la posición " + posicion + ".");
        }

        // 3. Agregar al final
        public void AgregarFinal(double nota)
        {
            Nodo nuevo = new Nodo(nota);

            // Si la lista está vacía
            if (inicio == null)
            {
                inicio = nuevo;
                Console.WriteLine("Nota agregada correctamente al final.");
                return;
            }

            Nodo actual = inicio;

            // Recorrer hasta el último nodo
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;

            Console.WriteLine("Nota agregada correctamente al final.");
        }

        // 4. Eliminar de cualquier posición
        public void EliminarPosicion(int posicion)
        {
            if (inicio == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            if (posicion < 0)
            {
                throw new ArgumentException("La posición no puede ser negativa.");
            }

            // Eliminar el primer elemento
            if (posicion == 0)
            {
                inicio = inicio.Siguiente;
                Console.WriteLine("Elemento eliminado correctamente.");
                return;
            }

            Nodo actual = inicio;

            // Buscar el nodo anterior
            for (int i = 0; i < posicion - 1 && actual != null; i++)
            {
                actual = actual.Siguiente;
            }

            if (actual == null || actual.Siguiente == null)
            {
                throw new ArgumentException("La posición no existe en la lista.");
            }

            actual.Siguiente = actual.Siguiente.Siguiente;

            Console.WriteLine("Elemento eliminado correctamente.");
        }

        // 5. Modificar una nota
        public void Modificar(int posicion, double nuevaNota)
        {
            if (inicio == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            if (posicion < 0)
            {
                throw new ArgumentException("La posición no puede ser negativa.");
            }

            Nodo actual = inicio;

            for (int i = 0; i < posicion && actual != null; i++)
            {
                actual = actual.Siguiente;
            }

            if (actual == null)
            {
                throw new ArgumentException("La posición no existe en la lista.");
            }

            actual.Nota = nuevaNota;

            Console.WriteLine("Nota modificada correctamente.");
        }

        // 6. Buscar una nota
        public void Buscar(double nota)
        {
            if (inicio == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo actual = inicio;
            int posicion = 0;
            bool encontrada = false;

            while (actual != null)
            {
                if (actual.Nota == nota)
                {
                    Console.WriteLine(
                        $"La nota {nota} se encuentra en la posición {posicion}."
                    );

                    encontrada = true;
                }

                actual = actual.Siguiente;
                posicion++;
            }

            if (!encontrada)
            {
                Console.WriteLine("La nota no se encuentra en la lista.");
            }
        }

        // 7. Mostrar los elementos
        public void Mostrar()
        {
            if (inicio == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo actual = inicio;
            int posicion = 0;

            Console.WriteLine("\n===== ELEMENTOS DE LA LISTA =====");

            while (actual != null)
            {
                Console.WriteLine($"Posición [{posicion}] -> Nota: {actual.Nota}");

                actual = actual.Siguiente;
                posicion++;
            }

            Console.WriteLine("=================================");
        }

        // Obtener cantidad de elementos
        public int Cantidad()
        {
            int cantidad = 0;
            Nodo actual = inicio;

            while (actual != null)
            {
                cantidad++;
                actual = actual.Siguiente;
            }

            return cantidad;
        }
    }

    class EjLSE
    {
        // Validar y leer una nota
        static double LeerNota()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese una nota (0 - 100): ");
                    string entrada = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        throw new FormatException(
                            "No puede dejar el campo vacío."
                        );
                    }

                    double nota;

                    if (!double.TryParse(entrada, out nota))
                    {
                        throw new FormatException(
                            "Debe ingresar únicamente números."
                        );
                    }

                    if (nota < 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            "nota",
                            "La nota no puede ser negativa."
                        );
                    }

                    if (nota > 100)
                    {
                        throw new ArgumentOutOfRangeException(
                            "nota",
                            "La nota no puede ser mayor que 100."
                        );
                    }

                    return nota;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inesperado: " + ex.Message);
                }
            }
        }

        // Validar y leer una posición
        static int LeerPosicion()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese la posición: ");
                    string entrada = Console.ReadLine();

                    int posicion;

                    if (!int.TryParse(entrada, out posicion))
                    {
                        throw new FormatException(
                            "La posición debe ser un número entero."
                        );
                    }

                    if (posicion < 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            "posicion",
                            "La posición no puede ser negativa."
                        );
                    }

                    return posicion;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inesperado: " + ex.Message);
                }
            }
        }

        // Mostrar el menú
        static void MostrarMenu()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("     LISTA SIMPLEMENTE ENLAZADA");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Agregar al inicio");
            Console.WriteLine("2. Agregar en cualquier posición");
            Console.WriteLine("3. Agregar al final");
            Console.WriteLine("4. Eliminar de cualquier posición");
            Console.WriteLine("5. Modificar");
            Console.WriteLine("6. Buscar");
            Console.WriteLine("7. Ver los elementos de la lista");
            Console.WriteLine("8. Salir");
            Console.WriteLine("======================================");
        }

        // Leer una opción válida del menú
        static int LeerOpcionMenu()
        {
            while (true)
            {
                try
                {
                    Console.Write("Seleccione una opción (1-8): ");
                    string entrada = Console.ReadLine();

                    int opcion;

                    if (!int.TryParse(entrada, out opcion))
                    {
                        throw new FormatException(
                            "Debe ingresar un número entero."
                        );
                    }

                    if (opcion < 1 || opcion > 8)
                    {
                        throw new ArgumentOutOfRangeException(
                            "opcion",
                            "La opción debe estar entre 1 y 8."
                        );
                    }

                    return opcion;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inesperado: " + ex.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            int opcion=0;

            Console.WriteLine("======================================");
            Console.WriteLine("   SISTEMA DE NOTAS");
            Console.WriteLine("   Lista Simplemente Enlazada");
            Console.WriteLine("======================================");

            do
            {
                try
                {
                    MostrarMenu();
                    opcion = LeerOpcionMenu();

                    switch (opcion)
                    {
                        case 1:
                            {
                                double nota = LeerNota();
                                lista.AgregarInicio(nota);
                                break;
                            }

                        case 2:
                            {
                                double nota = LeerNota();
                                int posicion = LeerPosicion();

                                lista.AgregarPosicion(nota, posicion);
                                break;
                            }

                        case 3:
                            {
                                double nota = LeerNota();
                                lista.AgregarFinal(nota);
                                break;
                            }

                        case 4:
                            {
                                if (lista.Cantidad() == 0)
                                {
                                    Console.WriteLine("La lista está vacía.");
                                    break;
                                }

                                lista.Mostrar();

                                int posicion = LeerPosicion();
                                lista.EliminarPosicion(posicion);
                                break;
                            }

                        case 5:
                            {
                                if (lista.Cantidad() == 0)
                                {
                                    Console.WriteLine("La lista está vacía.");
                                    break;
                                }

                                lista.Mostrar();

                                int posicion = LeerPosicion();
                                double nuevaNota = LeerNota();

                                lista.Modificar(posicion, nuevaNota);
                                break;
                            }

                        case 6:
                            {
                                double nota = LeerNota();
                                lista.Buscar(nota);
                                break;
                            }

                        case 7:
                            {
                                lista.Mostrar();
                                break;
                            }

                        case 8:
                            {
                                Console.WriteLine("\nSaliendo del programa...");
                                Console.WriteLine("¡Gracias por utilizar el sistema!");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "\nSe produjo un error: " + ex.Message
                    );
                }

                if (opcion != 8)
                {
                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (opcion != 8);
        }
    }
}

 // Crear una lista enlazada que administre las mascotas.
 // Que salgan los tipos de animales de tipo string.
    using System;

namespace ListaSimplementeEnlazada
{
    class Nodo
    {
        public String Mascotas;
        public Nodo Siguiente;

        public Nodo(string Mascotas)
        {
            Mascotas = Mascotas;
            Siguiente = null;
        }
    }

    class ListaEnlazada
    {
        private Nodo inicio;

        public ListaEnlazada()
        {
            inicio = null;
        }

        public void AgregarInicio(string Mascotas)
        {
            Nodo nuevo = new Nodo(Mascotas);

            nuevo.Siguiente = inicio;
            inicio = nuevo;

            Console.WriteLine("Mascota agregada correctamente al inicio.");
        }

        public void AgregarPosicion(string Mascotas, int posicion)
        {
            if (posicion < 0)
            {
                throw new ArgumentException("La posición no puede ser negativa.");
            }


            if (posicion == 0)
            {
                AgregarInicio(Mascotas);
                return;
            }

            Nodo actual = inicio;

            for (int i = 0; i < posicion - 1 && actual != null; i++)
            {
                actual = actual.Siguiente;
            }

            if (actual == null)
            {
                throw new ArgumentException("La posición no existe en la lista.");
            }

            Nodo nuevo = new Nodo(Mascotas);

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;

            Console.WriteLine("Mascota agregada correctamente en la posición " + posicion + ".");
        }

        public void AgregarFinal(string       Mascotas)
        {
            Nodo nuevo = new Nodo(Mascotas);

            if (inicio == null)
            {
                inicio = nuevo;
                Console.WriteLine("Mascotas agregada correctamente al final.");
                return;
            }

            Nodo actual = inicio;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;

            Console.WriteLine("Mascota agregada correctamente al final.");
        }

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

            if (posicion == 0)
            {
                inicio = inicio.Siguiente;
                Console.WriteLine("Elemento eliminado correctamente.");
                return;
            }

            Nodo actual = inicio;

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

            actual.Mascotas = nuevaMascotas;

            Console.WriteLine("Mascota modificada correctamente.");
        }
        public void Buscar(string Mascotas)
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
                if (actual.Mascotas == Mascotas)
                {
                    Console.WriteLine(
                        $"La mascota {Mascotas} se encuentra en la posición {posicion}."
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
                Console.WriteLine($"Posición [{posicion}] -> Mascota: {actual.Mascotas}");

                actual = actual.Siguiente;
                posicion++;
            }

            Console.WriteLine("=================================");
        }
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
        static double LeerNota()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese una mascota. ");
                    string entrada = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        throw new FormatException(
                            "No puede dejar el campo vacío."
                        );
                    }

                    double nota;

                    if (!string.TryParse(entrada, out Mascota))
                    {
                        throw new FormatException(
                            "Debe ingresar únicamente números."
                        );
                    }

                    if (nota < 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            "",
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
            Console.WriteLine("   SISTEMA DE ANIMALES ");
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

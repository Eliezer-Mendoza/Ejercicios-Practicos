// 1.-Elaborar una aplicación consola en C# auxiliándose de LIST que gestione los datos de empleados (IdEmpleado, Nombre, Cargo, AñoIngreso y Salario).
//  La cantidad de empleados a gestionar debe estar entre 1 y 50. El año de ingreso debe estar entre 1926 y 2026. El Salario debe estar entre 7188 y 120000.
//  Debe existir un menu 1.- Agregar 2.- Eliminar 3.- Buscar 4.- Modificar 5.- Mostrar 6.- Salir. Implementar las excepciones que considere adecuada.
//  Validar todo lo que este sujeto a validación. Utilizar modularidad.
using System;
using System.Collections.Generic;

namespace EXP1
{
    class Empleado
    {
        public string IdEmpleado;
        public string Nombre;
        public string Cargo;
        public int AñoIngreso;
        public double Salario;
    }
    class Gestion
    {
        static void Main(string[] args)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            int opcion = 0;

            do
            {
                try 
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido al sistema fde gestion de empleados");
                    Console.WriteLine($"Empleados registrados: {listaEmpleados.Count}/50\n");
                    Console.WriteLine("Seleciones una opcion del menu: \n 1. Agregar. \n 2. Eliminar. \n 3. Buscar. \n 4. Modificar. \n 5. Mostrar. \n 6. Salir.");
                    opcion = ValidacionInt(1, 6);

                    switch (opcion)
                    {
                        case 1:
                            AgregarEmpleado(listaEmpleados);
                            break;
                        case 2:
                            EliminarEmpleado(listaEmpleados);
                            break;
                        case 3:
                            BuscarEmpleado(listaEmpleados);
                            break;
                        case 4:
                            ModificarEmpleado(listaEmpleados);
                            break;
                        case 5:
                            MostrarEmpleados(listaEmpleados);
                            break;
                        case 6:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                    }
                    if (opcion != 6)
                    {
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Error: Operación inválida. Intente de nuevo.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Error: Índice fuera de rango. Intente de nuevo.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error: Opción fuera de rango. Intente de nuevo.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: Número demasiado grande o pequeño. Intente de nuevo.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Entrada no válida. Por favor, ingrese un número.");
                } 
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (opcion != 6);
        }

        static void AgregarEmpleado(List<Empleado> lista)
        {
            if (lista.Count >= 50)
            {
                Console.WriteLine("Error: Se ha alcanzado el límite máximo de 50 empleados.");
                return;
            }
            Empleado nuevo = new Empleado();
            Console.WriteLine("Agregar Empleado:");

            bool idValido = false;
            do
            {
                Console.Write("IdEmpleado (Máx 5 caracteres, letras y números): ");
                nuevo.IdEmpleado = ValidacionId(5);
                if (lista.Exists(e => e.IdEmpleado == nuevo.IdEmpleado))
                {
                    Console.WriteLine("Ese ID ya pertenece a otro empleado. Intente otro.");
                }
                else
                {
                    idValido = true;
                }
            } while (!idValido);
            Console.Write("Nombre: ");
            nuevo.Nombre = ValidacionString();

            Console.Write("Cargo: ");
            nuevo.Cargo = ValidacionString();

            Console.Write("Año de Ingreso (1926 - 2026): ");
            nuevo.AñoIngreso = ValidacionInt(1926, 2026);

            Console.Write("Salario (7188 - 120000): ");
            nuevo.Salario = ValidacionDouble(7188, 120000);

            lista.Add(nuevo);
            Console.WriteLine("Empleado agregado");
        }

        static void EliminarEmpleado(List<Empleado> lista)
        {
            if (VerificarVacia(lista)) return;

            Console.Write(" Ingrese el IdEmpleado a eliminar: ");
            string idBuscado = ValidacionId(5);

            Empleado emp = lista.Find(e => e.IdEmpleado == idBuscado);

            if (emp != null)
            {
                lista.Remove(emp);
                Console.WriteLine($"Empleado '{emp.Nombre}' eliminado.");
            }
            else
            {
                Console.WriteLine("Error: Empleado no encontrado.");
            }
        }

        static void BuscarEmpleado(List<Empleado> lista)
        {
            if (VerificarVacia(lista)) return;

            Console.Write(" Ingrese el IdEmpleado a buscar: ");
            string idBuscado = ValidacionId(5);

            Empleado emp = lista.Find(e => e.IdEmpleado == idBuscado);

            if (emp != null)
            {
                Console.WriteLine(" Datos del Empleado: ");
                Console.WriteLine($"ID:       {emp.IdEmpleado}");
                Console.WriteLine($"Nombre:   {emp.Nombre}");
                Console.WriteLine($"Cargo:    {emp.Cargo}");
                Console.WriteLine($"Ingreso:  {emp.AñoIngreso}");
                Console.WriteLine($"Salario:  C${emp.Salario}");
            }
            else
            {
                Console.WriteLine("Error: Empleado no encontrado.");
            }
        }
        static void ModificarEmpleado(List<Empleado> lista)
        {
            if (VerificarVacia(lista)) return;

            Console.Write("Ingrese el IdEmpleado a modificar: ");
            string idBuscado = ValidacionId(5);
            Empleado emp = lista.Find(e => e.IdEmpleado == idBuscado);

            if (emp != null)
            {
                Console.WriteLine($" Modificando datos de: {emp.Nombre}");

                Console.Write("Nuevo Cargo: ");
                emp.Cargo = ValidacionString();

                Console.Write("Nuevo Salario (7188 - 120000): ");
                emp.Salario = ValidacionDouble(7188, 120000);

                Console.WriteLine("Datos modificados ");
            }
            else
            {
                Console.WriteLine("Error: Empleado no encontrado.");
            }
        }
        static void MostrarEmpleados(List<Empleado> lista)
        {
            if (VerificarVacia(lista)) return;

            Console.WriteLine(" Lista de Empleados: ");
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10} {4,-15}", "ID", "Nombre", "Cargo", "Ingreso", "Salario");
            Console.WriteLine(new string('-', 75));

            foreach (var emp in lista)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10} C${4,-13}", 
                    emp.IdEmpleado, emp.Nombre, emp.Cargo, emp.AñoIngreso, emp.Salario);
            }
        }
        static bool VerificarVacia(List<Empleado> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("La lista esta vacía. Debe agregar empleados primero.");
                return true;
            }
            return false;
        }
        static string ValidacionId(int maxLongitud)
        {
            string entrada;
            do
            {
                entrada = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrada) && entrada.Length <= maxLongitud)
                {
                    bool esValido = true;
                    foreach (char c in entrada)
                    {
                        if (!char.IsLetterOrDigit(c))
                        {
                            esValido = false;
                            break;
                        }
                    }
                    if (esValido)
                    {
                        return entrada.ToUpper();
                    }
                }
                Console.Write($"Error. Ingrese un ID válido (máx {maxLongitud} caracteres, sin espacios ni símbolos): ");
            } while (true);
        }
        static int ValidacionInt(int min, int max)
        {
            string entrada;
            int n;
            do
            {
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out n) && n >= min && n <= max)
                {
                    return n;
                }
                Console.Write($"Error. Ingrese un número válido entre {min} y {max}: ");
            } while (true);
        }
        static double ValidacionDouble(double min, double max)
        {
            string entrada;
            double n;
            do
            {
                entrada = Console.ReadLine();
                if (double.TryParse(entrada, out n) && n >= min && n <= max)
                {
                    return n;
                }
                Console.Write($"Error. Ingrese un salario válido entre {min} y {max}: ");
            } while (true);
        }
        static string ValidacionString()
        {
            string entrada;
            do
            {
                entrada = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    return entrada;
                }
                Console.Write("Error. El campo no puede estar vacío. Intente de nuevo: ");
            } while (true);
        }
    }
}
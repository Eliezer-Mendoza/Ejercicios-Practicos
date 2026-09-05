using System;
namespace PruebaEj2
{
    class Nodo
    {
        public decimal Valor;
        public Nodo Siguiente;
        public Nodo(decimal valor)
        {
            Valor = valor;
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
        public void AgregarInicio(decimal valor)
        {
            Nodo nuevo = new Nodo(valor);
            nuevo.Siguiente = inicio;
            inicio = nuevo;
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
        public void Mostrar()
        {
            if (inicio == null)
            {
                Console.WriteLine("No hay registros de ingresos.");
                return;
            }
            Console.WriteLine("\nResultados de antiguedad economica:");
            Nodo actual = inicio;
            int numUsuario = Cantidad();
            while (actual != null)
            {
                Console.WriteLine($"- Usuario {numUsuario}: Calculo Total: {actual.Valor:C}");
                actual = actual.Siguiente;
                numUsuario--;
            }
            Console.WriteLine();
        }
    }
    class Principal
    {
        static ListaEnlazada Ingresos = new ListaEnlazada();
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Menu();
                    switch (ValidarNum(1, 3))
                    {
                        case 1: ProcesarAntiguedad(); break;
                        case 2: Ingresos.Mostrar(); break; 
                        case 3: Console.WriteLine("Saliendo del sistema..."); return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }
            } while (true);
        }
        static void ProcesarAntiguedad()
        {
            int añoActual = DateTime.Now.Year;
            Console.WriteLine($"Ingrese su año de ingreso | Rango 1961 a {añoActual}");
            int añoIngresado = ValidarNum(1961, añoActual);
            Console.WriteLine("Ingrese su salario | Rango 7188 a 500000");
            decimal salario = ValidarDecimal(7188m, 500000m);
            int antiguedad = añoActual - añoIngresado;
            decimal bonoAntiguedad = salario * ((2m * antiguedad + 1m) / 100m);
            decimal antiguedadEconomica = salario + bonoAntiguedad;
            Ingresos.AgregarInicio(antiguedadEconomica);
            Console.WriteLine("\n--- Resultados del Calculo ---");
            Console.WriteLine($"Antiguedad: {antiguedad} años | Salario base: {salario:C}");
            Console.WriteLine($"Bono: {bonoAntiguedad:C} | Total: {antiguedadEconomica:C}");
            Console.WriteLine("------------------------------\n");
        }
        static int ValidarNum(int min, int max)
        {
            do
            {
                if (int.TryParse(Console.ReadLine(), out int numero) && numero >= min && numero <= max)
                    return numero;
                    
                Console.WriteLine($"Entrada invalida. El numero debe estar entre {min} y {max}.");
            } while (true);
        }
        static decimal ValidarDecimal(decimal min, decimal max)
        {
            do
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal numero) && numero >= min && numero <= max)
                    return numero;
                    
                Console.WriteLine($"Entrada invalida. El valor debe estar entre {min} y {max}.");
            } while (true);
        }
        static void Menu()
        {
            Console.WriteLine("Bienvenido al menu.\n 1. Calcular antiguedad empleado.\n 2. Ver resultados de antiguedad.\n 3. Salir del sistema");
        }
    }
}
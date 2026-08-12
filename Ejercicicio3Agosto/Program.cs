using System;

// Calcular el area de cuadrados, rectangulo y triangulos usando funciones
namespace geometria
{
    class Program
    {
        public static void Menu()
        {
            Console.WriteLine("Bienvenido al sistema, por favor ingrese la opcion deseada:");
            Console.WriteLine("1. Calcular el area de un cuadrado");
            Console.WriteLine("2. Calcular el area de un rectangulo");
            Console.WriteLine("3. Calcular el area de un triangulo");
        }

        static double CCuadrado(double lados)
        {
            return lados * lados;
        }

        static double CRectangulo(double b, double altura)
        {
            return b * altura;
        }

        static double CTriangulo(double b, double altura)
        {
            return (b * altura) / 2;
        }

        static void Main(string[] args)
        {
            double lados = 0, b = 0, altura = 0, area;
            int tB = 0;

            try
            {
                Menu();
                do
                {
                    Console.Write("Valor: ");
                    string entrada = Console.ReadLine();
                    if (!int.TryParse(entrada, out tB) || tB < 1 || tB > 3)
                    {
                        Console.WriteLine("Opcion no valida");
                        tB = 0; 
                    }
                } while (tB < 1 || tB > 3);

                switch (tB)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("Ingrese el lado:");
                            string entrada = Console.ReadLine();
                            if (!double.TryParse(entrada, out lados) || lados < 0)
                            {
                                Console.WriteLine("El lado tiene que ser un número mayor o igual a 0");
                                lados = -1;
                            }
                        } while (lados < 0);

                        area = CCuadrado(lados);
                        Console.WriteLine("El area del cuadrado es: " + area);
                        break;

                    case 2:
                        do
                        {
                            Console.Write("Ingrese la longitud de la base del rectangulo: ");
                            string bStr = Console.ReadLine();
                            if (!double.TryParse(bStr, out b) || b < 0)
                            {
                                Console.WriteLine("La base del rectangulo no puede ser negativa o inválida");
                                b = -1;
                            }
                        } while (b < 0);

                        do
                        {
                            Console.Write("Ingrese la altura del rectangulo: ");
                            string alturaStr = Console.ReadLine();
                            if (!double.TryParse(alturaStr, out altura) || altura < 0)
                            {
                                Console.WriteLine("La altura del rectangulo no puede ser negativa o inválida");
                                altura = -1;
                            }
                        } while (altura < 0);

                        Console.WriteLine("El area del rectangulo es: " + CRectangulo(b, altura));
                        break;

                    case 3:
                        do
                        {
                            Console.Write("Ingrese la base del triangulo: ");
                            string bStr = Console.ReadLine();
                            if (!double.TryParse(bStr, out b) || b < 0)
                            {
                                Console.WriteLine("La base del triangulo no puede ser negativa o inválida");
                                b = -1;
                            }
                        } while (b < 0);

                        do
                        {
                            Console.Write("Ingrese la altura del triangulo: ");
                            string alturaStr = Console.ReadLine();
                            if (!double.TryParse(alturaStr, out altura) || altura < 0)
                            {
                                Console.WriteLine("La altura del triangulo no puede ser negativa o inválida");
                                altura = -1;
                            }
                        } while (altura < 0);

                        Console.WriteLine("El area del triangulo es: " + CTriangulo(b, altura));
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Error al ejecutar el programa. Ingrese un valor valido por favor");
            }
        }
    }
}
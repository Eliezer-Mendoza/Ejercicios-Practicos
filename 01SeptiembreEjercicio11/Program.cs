// Elaborar una aplicacion consola en c# que pida al usuario su numero de cedula
// Debe abstraer con el metodo substring el año de nacimiento.
// Debe obtener el año actual del sistema, convertirlo a entero y calcular la edad del ciudadano.
// solo pueden entrar cedulas desde 1926 a 2010
using System;
namespace Cedula
{
    class Principal
    {
        static string VACYA()
        {
            do
            {
                Console.Write("Ingrese su número de cédula: ");
                string cedula = Console.ReadLine();
                if (cedula.Length < 14)
                {
                    Console.WriteLine("Cédula inválida. Debe tener al menos 14 caracteres.\n");
                    continue;
                }

                // 001 28 10 07-10
                string diaNaS = cedula.Substring(4, 2);
                string mesNaS = cedula.Substring(6, 2);
                string añoNaS = cedula.Substring(7, 2);

                int dia;
                int mes;
                int año2Digitos;
                if (!int.TryParse(diaNaS, out dia) || dia < 1 || dia > 31 ||
                    !int.TryParse(mesNaS, out mes) || mes < 1 || mes > 12 ||
                    !int.TryParse(añoNaS, out año2Digitos))
                {
                    Console.WriteLine("La cédula no es válida.\n");
                    continue;
                }

                int añoCompleto = (año2Digitos >= 26) ? 1900 + año2Digitos : 2000 + año2Digitos;
                if (añoCompleto < 1926 || añoCompleto > 2010)
                {
                    Console.WriteLine("El año de nacimiento debe estar entre 1926 y 2010.\n");
                    continue;
                }

                return cedula;
            } while (true);
        }

        static int ObtenerEdad(string cedula)
        {
            string añoNaS = cedula.Substring(7, 2);
            int año2Digitos = int.Parse(añoNaS);
            int añoNacimiento = (año2Digitos >= 26) ? 1900 + año2Digitos : 2000 + año2Digitos;
            int anioActual = DateTime.Now.Year; 
            int edad = anioActual - añoNacimiento;
            return edad;
        }
        static void Main(string[] args)
        {
            try
            {
                
                string cedula = VACYA(); 
                
                int edad = ObtenerEdad(cedula);
                Console.WriteLine($"\n Su edad es: {edad} años.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio un error inesperado: {ex.Message}");
            }
        }
    }
}
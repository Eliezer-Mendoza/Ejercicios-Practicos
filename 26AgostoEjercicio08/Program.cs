// Elaborar una aplicacion consola en la que declare un vector denominado Notas de longitud 4. Consultar primeramente 
// cuantos estudiantes se evaluaran entre 1 y 39
// en el vector 1 la nota parcial 1 entre 0 y 50
// en el vector 2 la nota parcial 2 entre 0 y 50
// en el vector 3 representa el valor del indice 1 y 2, verificar siel estudiante aprobo o no
// valdar que los datos no sean negativos ni letras ni ayor a 100, usar modularidad.

namespace PruebasNotas
{
    class Principal
    {
        static void Main (string[] args)
        {
            try
            {
                int sumatoria;
                double promedio;
                int[] n1= new int[4];
                Console.WriteLine("Por favor, ingrese por favor cuantos estudiantes va a evaluar.");
                n1[0] = Validacion();
                for (int j = 0; j < n1[0]; j++)
                {
                    Console.WriteLine($"Ingrese la nota del primer parcial del estudiante: {j + 1}");
                    n1[1] = Validacion();
                    Console.WriteLine($"Ingrese la nota del segundo parcial del estudiante: {j + 1}");
                    n1[2] = Validacion();
                    n1[3] = n1[1] + n1[2];
                    sumatoria = n1[3];
                    promedio = sumatoria / 2;
                    if (AproboONoAprobo(sumatoria))
                    {
                        Console.WriteLine($"El estudiante {j + 1} aprobo la materia.");
                    }
                    else
                    {
                        Console.WriteLine($"El estudiante {j + 1} no aprobo la materia.");
                    }
                    Console.WriteLine($"La nota final del estudiante {j + 1} es: {promedio}");
                }
                
            }catch
            {
            Console.WriteLine("Algo ocurrio.");
            }
        }
        static int Validacion()
        {
            do
            {
                string entrada;
                int numero;
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out numero) && (numero>0 || numero <=50))
                {
                    return numero;
                }
                Console.WriteLine("Entrada no valida. Por favor intentelo de nuevo.");
            } while (true);
        }
        static bool AproboONoAprobo(int sumatoria)
        {
            bool aprobado;
            aprobado = false;
            if (sumatoria>60)
            {
                return !aprobado;
            }
            else
            {
                return aprobado;
            }
        }
    }
}
// // Una pequeña sala de cine necesita un programa en C# que permita procesar la información de venta de entradas
// //  durante una semana completa (7 días). El sistema debe desarrollarse bajo el paradigma de programación estructurada, 
// // utilizando métodos independientes para organizar la lógica de ejecución y el procesamiento de datos.
// //Requerimientos detallados del problema:
//     // Ingreso y Validación de Datos:
//     // El programa debe solicitar y registrar para cada uno de los 7 días de la semana:
//       //  La cantidad de entradas vendidas.
//        // El precio promedio por entrada.
//    // Mediante el uso de estructuras repetitivas, el sistema debe validar que los datos ingresados sean lógicos
//  (la cantidad de entradas no puede ser negativa y el precio debe ser mayor a cero). 
// En caso de ingresar un valor incorrecto, el programa debe obligar al usuario a ingresarlo nuevamente.
//    // Procesamiento y Cálculos (mediante funciones o métodos):
//     El sistema debe calcular y retornar los siguientes valores utilizando métodos especializados:
//         Ingreso Total: La suma total recaudada durante toda la semana.
//         Promedio Diario: El promedio de entradas vendidas por día a lo largo de la semana.
//         Extremos de Recaudación: Identificar cuál fue el día con mayor recaudación y cuál registró la menor recaudación.
//         Conteo Condicional: Calcular cuántos días de la semana tuvieron una recaudación superior a un monto de referencia (por ejemplo, $1,000).
//     Reporte en Consola:
//     Al finalizar el procesamiento de los datos, el programa debe mostrar por pantalla un resumen estructurado que incluya 
// el detalle diario (día, entradas, precio e ingresos de ese día) y las estadísticas globales calculadas por el sistema.
namespace Practica06
{
    class Programa
    {

        static int Validacion()
        {
            string input;
            int numero;
            do{
            input = Console.ReadLine();
            if(int.TryParse(input, out numero) && numero>0)
            {
                return numero;
            }
            Console.WriteLine("Ingrese un dato valido | No se admiten letras o negativos");
            } while(true);
        }

        static double PromedioEntradas(int entradas, double precio)
        {
            return precio/entradas;
        }

        static double PrecioAltoYBajo (double precio)
        {
            precio = 8888888888888;
            if ()
        }
        static double ValidacionPrecio()
        {
            string input;
            double precio;
            do
            {
                input = Console.ReadLine();
                if(!double.TryParse(input, out precio) && precio>0)
                {
                    return precio;
                }
                Console.WriteLine("Por favor ingrese un tipo de dato valido. Intentelo de nuevo");
            } while(true);
        }
        static void Main(string[] args)
        {
            try
            {
            Console.WriteLine("Ingrese ")
                
            } catch (OverflowException)
            {
                Console.WriteLine("Alfog ocurrio");
            }
        }
    }
}
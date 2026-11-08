// Contexto: Una tienda de suministros electrónicos desea procesar las facturas de una fila de N clientes.
// Enunciado:
// El algoritmo debe preguntar primero cuántos clientes se procesarán. solicitará el monto_compra de cada uno:
// * Si la compra es < : 0% de descuento.
// * Si la compra es entre  y : 5% de descuento.
// * Si la compra es > : 10% de descuento.
// Al final de cada iteración, mostrar el total a pagar del cliente actual y, 
// al finalizar el ciclo, mostrar el gran total de dinero recaudado por la tienda.
namespace TiendaSuministros
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Bienvenido al sistema de procesamiento de facturas. \n Cuantos clientes desea procesar? ");
            int[] cl = new int [ValidarClientes()];
            for i=0; i<ValidarClientes().
        }
        static int ValidarClientes()
        {
            string entrada;
            int cl;
            do
            {
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out cl) && cl>0)
                {
                    return cl;
                }
                System.Console.WriteLine("Entrada no validaa. No se aceptan clientes negativos o letras. Vuelva a intentarlo");
            } while(true);
        }
        static double ValidarMonto()
        {
            string entrada;
            double v;
            do
            {
                entrada = Console.ReadLine();
                if(double.TryParse(entrada, out v) && v>0 )
                {
                    return v;
                }
                System.Console.WriteLine("Entrada no valida. No se aceptan montos negativos o letras. Vuelva a intentarlo.");
            } while(true);
        }
    }
}
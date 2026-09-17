// Elaborar una aplicación consola en C# que declare dos vectores de longitud 5, uno denominado Km y el otro Mts.
//  Debe pedir para el vector Km los valores y calcular la conversión en metros para posicionarlo en el otro vector Mts.
// Validar negativos, cero y letras. Manejar excepciones. Aplicar modularidad.
namespace Vector
{
    class Principal
    {
        static void Main(string[] args)
        {
                try{
            double[]kms = new double[5];
            double[]mts = new double[5];
            for (int i = 0; i < kms.Length; i++)
            {
                System.Console.WriteLine($"Ingrese 5 datos en KMS. Dato: {i+1}");
                kms[i] = ValidarDato();
            }
            mts = ConvertirKmAMts(kms, mts);
            Console.WriteLine("Sus datos convertidos son: ");
          for (int i = 0; i < mts.Length; i++)
                    {
                        System.Console.WriteLine($"{mts[i]} metros");
                    }
                } catch (Exception ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}");
                }
        }
        static double ValidarDato()
        {
            string entrada;
            double n;
            do
            {
                entrada = Console.ReadLine();
                if(double.TryParse(entrada,out n) && n>0)
                {
                    return n;
                }
                System.Console.WriteLine("Entrada no valida, no se aceptan negativos ni letras. Intentelo de nuevo.");
            } while (true);
        }
        static double[] ConvertirKmAMts(double[] kms, double[] mts)
        {
            for (int i = 0; i < kms.Length; i++)
            {
                mts[i] = kms[i] * 1000;
            }
            return mts;
        }
    }
}
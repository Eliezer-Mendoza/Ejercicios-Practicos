using System;

namespace EjercicioLogica
{
    class Problema
    {
        const int CAPACIDAD_A = 5;
        const int CAPACIDAD_B = 3;

        static void Main(string[] args)
        {
            int garrafaA = 0;
            int garrafaB = 0;
            int paso = 1;
            Console.WriteLine("==================================================");
            Console.WriteLine(" SIMULACIÓN: PROBLEMA DE LAS GARRAFAS DE AGUA");
            Console.WriteLine("==================================================");
            Console.WriteLine($"Estado inicial -> A: {garrafaA}L / B: {garrafaB}L\n");
            garrafaA = CAPACIDAD_A;
            MostrarPaso(paso++, "Llenar Garrafa A de la fuente", garrafaA, garrafaB);
            Verter(ref garrafaA, ref garrafaB, CAPACIDAD_B);
            MostrarPaso(paso++, "Verter agua de A a B (hasta llenar B)", garrafaA, garrafaB);
            garrafaB = 0;
            MostrarPaso(paso++, "Vaciar Garrafa B en el suelo", garrafaA, garrafaB);
            Verter(ref garrafaA, ref garrafaB, CAPACIDAD_B);
            MostrarPaso(paso++, "Pasar los 2L restantes de A hacia B", garrafaA, garrafaB);
            garrafaA = CAPACIDAD_A;
            MostrarPaso(paso++, "Llenar Garrafa A de la fuente", garrafaA, garrafaB);
            Verter(ref garrafaA, ref garrafaB, CAPACIDAD_B);
            MostrarPaso(paso++, "Verter de A a B hasta llenar B", garrafaA, garrafaB);
            if (garrafaA == 4)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("La Garrafa A contiene exactamente 4 Litros.");
                Console.WriteLine("--------------------------------------------------");
            }
        }
        static void Verter(ref int origen, ref int destino, int capacidadMaxDestino)
        {
            int espacioDisponible = capacidadMaxDestino - destino;
            int cantidadAVerter = Math.Min(origen, espacioDisponible);
            origen -= cantidadAVerter;
            destino += cantidadAVerter;
        }
        static void MostrarPaso(int numeroPaso, string accion, int a, int b)
        {
            Console.WriteLine($"Paso {numeroPaso}: {accion}");
            Console.WriteLine($"      -> Estado actual: Garrafa A = {a}L | Garrafa B = {b}L\n");
        }
    }
}
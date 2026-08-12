
using System;
using Microsoft.VisualBasic;
namespace Goty
{
    class Juego
    {
        static int VidaJugador = 100;
        static int vidaEnemigo = 50;
        static void Main (string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n Te vas a enfrentar al enemigo! \n 1. Dispararle. \n 2. Curarte.");
                Console.WriteLine($"\t ===== VIDA GENERAL === \t \n 1. Jugador: {VidaJugador} \n 2. Enemigo: {vidaEnemigo}");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out opcion) && opcion >0 && opcion <3)
                {
                    if (opcion == 1)
                    {
                        Disparar();
                    Console.WriteLine($"Le quitaste: 15 de vida a tu enemigo. Vida total: {vidaEnemigo}");
                    if (vidaEnemigo>0)
                        {
                             Atacarte();
                    Console.WriteLine($"El enemigo te ataco y te bajo 20 puntos de vida. Vida total {VidaJugador}");
                        }
                    }
                    else if (opcion == 2)
                    {
                        Curarte();
                        Console.WriteLine($"Te has curado, tu vida total es de: {VidaJugador}");
                              Atacarte();
                    Console.WriteLine($"El enemigo te ataco y te bajo 20 puntos de vida. Vida total {VidaJugador}");
                    }
                    else
                    {
                        Console.WriteLine("Opcion invalida, pierdes tu turno.");
                    }
                } else
                {
                    Console.WriteLine("Opcion no valida. Intentelo de nuevo.");
                }
            } while (VidaJugador>0 && vidaEnemigo>0);
            
            if (VidaJugador>0)
            {
                Console.WriteLine("\n Has sobrevivido! Felicidades");
            }
            if (VidaJugador<=0)
            {
                Console.WriteLine("\n No has sobrevivido. Intentalo de nuevo");
            }
        }
        
        static int Disparar()
        {
            return vidaEnemigo -=15;
        }
        static int Curarte()
        {
            return VidaJugador += 20;
        }
        static int Atacarte()
        {
            return VidaJugador-=20;
        }
    }
}
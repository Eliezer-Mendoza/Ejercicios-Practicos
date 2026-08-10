// // El Reto: Simulador de Combate Básico
// Tu misión es crear un programa que simule un combate por turnos 1 contra 1:
//     Las variables iniciales: Crea dos variables de tipo entero (int). Una para tu vida (vidaJugador = 100) y otra para la del enemigo (vidaEnemigo = 50).
//     El ciclo de combate: Inicia un ciclo while que se siga repitiendo mientras tu vida sea mayor a 0 y (en C# el "y" se escribe &&) la vida del enemigo sea mayor a 0.
//     El turno del jugador: Dentro del ciclo, muéstrale al usuario cuánta vida tiene cada uno y dale a elegir dos opciones:
//         Presionar 1 para Disparar (le resta 15 de vida al enemigo).
//         Presionar 2 para Curarse (te suma 20 de vida a ti).
//         (Recuerda usar int.Parse(Console.ReadLine()) para leer la opción y un bloque if/else para aplicar los efectos).
//     El turno del enemigo: Aún dentro del ciclo while, justo después de tu acción, el enemigo te ataca automáticamente (te resta 10 de vida). ¡Ojo! El enemigo solo debería atacarte si su vida sigue siendo mayor a 0 después de tu turno.
//     El final: Cuando el ciclo termine (porque alguno de los dos llegó a 0 o menos), usa un if/else fuera del ciclo para imprimir un mensaje: "¡Has sobrevivido!" si ganaste, o "Fin del juego..." si perdiste.
using System;
using Microsoft.VisualBasic;
namespace Goty
{
    static void Main(string[] args)
    {
        
    }
}
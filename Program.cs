using System;
using juego;
using jugador;

namespace Gato_4enLinea
{
    class Program
    {
        static void Main(string[] args)
        {
            CuatroEnLinea cuatroEnLinea = new CuatroEnLinea();
            Gato gato = new Gato();
            ConsoleColor fichaColor = ConsoleColor.Red;
            ConsoleColor fichaColorB = ConsoleColor.Blue;
            Jugador jugador1= new Jugador("Manuel",'X', fichaColor);
            Jugador jugador2= new Jugador("Angel",'O', fichaColorB);
            gato.iniciarJuego();
            gato.colocarFicha(jugador1);
            gato.colocarFicha(jugador2);
            gato.imprimirTablero();


        }
    }
}

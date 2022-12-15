using System;
using juego;
using jugador;
using tablero;

namespace Gato_4enLinea
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor fichaColor = ConsoleColor.Red;
            ConsoleColor fichaColorB = ConsoleColor.Blue;
            Jugador jugador1= new Jugador("Manuel",'X', fichaColor);
            Jugador jugador2= new Jugador("Angel",'O', fichaColorB);
            CuatroEnLinea cuatroEnLinea = new CuatroEnLinea(jugador1, jugador2);
            Gato gato = new Gato(jugador1, jugador2);
            int turno = 0;
            do{
                gato.jugarTurno(jugador1);
                turno++;
                gato.jugarTurno(jugador2);
                turno++;
            }while(turno < gato.getTablero().getLength());
        }
    }
}

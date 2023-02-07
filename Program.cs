using System;
using menu;

namespace Gato_4enLinea
{
    ///<summary>
    /// Clase Program
    ///</summary>
    class Program
    {
        ///<summary>
        /// Método principal del programa
        ///</summary>
        static void Main(string[] args)
        {

            // ConsoleColor fichaColor = ConsoleColor.Red;
            // ConsoleColor fichaColorB = ConsoleColor.Blue;
            // Jugador jugador1 = new Jugador("Manuel", 'X', fichaColor);
            // Jugador jugador2 = new Jugador("Angel", 'O', fichaColorB);
            // Tablero tablero = new Tablero(3,3);
            // ReglaTableroLleno reglaTableroLleno = new ReglaTableroLleno();
            // ReglaGanador reglaGanador = new ReglaGanador(3);
            
            // tablero.casillas[0,2] = jugador1.ficha;
            // tablero.casillas[1,1] = jugador1.ficha;
            // tablero.casillas[2,0] = jugador1.ficha;
                
            
            // Console.WriteLine(reglaTableroLleno.evaluar(tablero, jugador1.ficha));
            // reglaGanador.evaluar(tablero, jugador1.ficha);

            JuegoGato gato = new JuegoGato();
            gato.init();
            gato.run();
            gato.result();



        }
    }
}

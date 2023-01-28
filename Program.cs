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
            string titulo = "- - - - - Bienvenido al juego del gato y 4 en linea - - - - -";
            int opcMenu;
            // Se crea un arreglo con las opciones de nuestro menú interactivo
            string[] opcionesMenu = {
                "Gato",
                "Cuatro en linea",
                "Salir"
            };
            String nombreJugador1;
            String nombreJugador2;
            char fichaJugador1;
            char fichaJugador2;
            int turno = 0;
            ConsoleColor fichaColor = ConsoleColor.Red;
            ConsoleColor fichaColorB = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
            Console.WriteLine(titulo);
            Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
            Console.WriteLine("Ingrese el nombre del jugador 1:");
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto
            nombreJugador1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
            Console.WriteLine("Ingrese el nombre del jugador 2:");
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto
            nombreJugador2 = Console.ReadLine();
            opcMenu = Menu.menuToPosition(titulo,"Seleccione el modo de juego:", opcionesMenu);
            if (opcMenu == 0)
            {
                fichaJugador1 = 'X';
                fichaJugador2 = 'O';
                Jugador jugador1 = new Jugador(nombreJugador1, fichaJugador1, fichaColor);
                Jugador jugador2 = new Jugador(nombreJugador2, fichaJugador2, fichaColorB);
                Gato gato = new Gato(jugador1, jugador2);
                do
                {
                    turno += gato.seleccionarColumna(jugador1);
                    turno += gato.seleccionarColumna(jugador2);
                } while (turno != 9);
            }
            else if(opcMenu == 1)
            {
                fichaJugador1 = 'O';
                fichaJugador2 = 'O';
                Jugador jugador1 = new Jugador(nombreJugador1, fichaJugador1, fichaColor);
                Jugador jugador2 = new Jugador(nombreJugador2, fichaJugador2, fichaColorB);
                CuatroEnLinea cuatroEnLinea = new CuatroEnLinea(jugador1, jugador2);
                do
                {
                    turno += cuatroEnLinea.seleccionarColumna(jugador1);

                    turno += cuatroEnLinea.seleccionarColumna(jugador2);
                } while (turno != 42);
            }
        }
    }
}

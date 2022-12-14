/* ---------- Ayuda!! ----------
*    Clase Juego
*   Se modela el objeto Juego con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
using ficha;
using jugador;
//-Contenido:
namespace juego{    
    public class Juego{
        private Ficha[,] tablero { get; set;}
        public Juego(int filas, int columnas)
        {
            this.tablero = new Ficha[filas,columnas];
        }
        public void iniciarJuego()
        {
            imprimirTablero();
        }

        public void colocarFicha(Jugador jugador)
        {
            Console.WriteLine("Jugador: {0}", jugador.getNombre());
            //todo: tablero interactivo

        }
        public void imprimirTablero()
        {
            for (int j = 0; j < this.tablero.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("----");
            }
            Console.Write("-\n");
            for (int i = 0; i < this.tablero.GetLength(0); i++)
            {
                
                for (int j = 0; j < this.tablero.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("| ");

                    if(tablero[i,j] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                    }
                    else
                    {
                        tablero[i,j].colocar();
                    }
                    Console.Write(" ");

                }
                Console.Write("|\n");
                for (int j = 0; j < this.tablero.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("----");
                }
                Console.Write("-\n");
            }
        }
    }
    public class Gato:Juego
    {
        public Gato():base(3, 3)
        {
            
        }
    }

    public class CuatroEnLinea:Juego
    {
        public CuatroEnLinea():base(6, 7)
        {
            
        }
    }    
   
}

//-Importaciones:
using System;

//-Contenido:

namespace Gato_4enLinea
{
    /// <summary>
    /// Clase Tablero
    /// </summary>
    public class Tablero{

        /// <summary>
        /// Almacenamiento de las fichas del tablero
        /// </summary>
        private Ficha[,] _casillas;
        /// <summary>
        /// Almacenamiento de los marcadores del tablero
        /// </summary>
        private int[] _marcadores = new int[2];

        /// <summary>
        /// Constructor de la clase Tablero
        /// </summary>
        /// <param name="filas">Filas del tablero</param>
        /// <param name="columnas">Columnas del tablero</param>        
        public Tablero(int filas, int columnas)
        {
            this.casillas = new Ficha[filas,columnas];
            this.marcadores[0] = 0;
            this.marcadores[1] = 0;
        }  

        /// <summary>
        /// Matriz de fichas
        /// </summary>
        public Ficha[,] casillas
        {
            get { return _casillas; }
            set { _casillas = value; }
        }

        /// <summary>
        /// Marcadores del tablero
        /// </summary>
        public int[] marcadores
        {
            get { return _marcadores; }
            set { _marcadores = value; }
        }

       
        /// <summary>
        /// Método para imprimir el tablero donde se muestra la ficha que se va a colocar
        /// </summary>
        /// <param name="marcadorX">Marcador de la fila</param>
        /// <param name="marcadorY">Marcador de la columna</param>        
        public void imprimir(int marcadorX, int marcadorY)
        {
            marcadores[0] = marcadorX;
            marcadores[1] = marcadorY;
            for(int x = 0; x < this.casillas.GetLength(1); x++){
                if (x == marcadorX)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  ▼\n");
                    break;
                }
                else
                {
                    Console.Write("    ");
                }
            }
            for (int j = 0; j < this.casillas.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("----");
            }
            Console.Write("-\n");
            for (int i = 0; i < this.casillas.GetLength(1); i++)
            {
                
                for (int j = 0; j < this.casillas.GetLength(0); j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("| ");

                    if(casillas[i,j] == null)
                    {                        
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");                        
                    }
                    else
                    {
                        casillas[i,j].imprimir();
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");

                }
                Console.Write("|");
                if(i == marcadorY)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" ◄\n");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }else
                    Console.Write("\n");
                for (int j = 0; j < this.casillas.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("----");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("-\n");
            }
        }        
    }
}
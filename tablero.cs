
//-Importaciones:
using System;

//-Contenido:

namespace Gato_4enLinea
{
    /// <summary>
    /// Clase que representa el tablero del juego
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
        /// Método para imprimir el tablero
        /// </summary>       
        public void imprimir()
        {
            for(int x = 0; x < this.casillas.GetLength(1); x++){
                if (x == marcadores[0])
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  ▼");
                    break;
                }
                else
                {
                    Console.Write("    ");
                }
            }
            Console.Write("\n");
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
                if(i == marcadores[1])
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
         /// <summary>
        /// Obtiene las posiciones válidas en el tablero del eje X
        /// </summary>
        /// <returns>Arreglo con las posiciones válidas</returns>
        public int[] getPosicionesValidasX()
        {
            int[] posicionesX = new int[casillas.GetLength(1)];
            for (int x = 0; x < casillas.GetLength(1); x++)
            {
                posicionesX[x] = 0;
                for (int y = 0; y < casillas.GetLength(0); y++)
                {
                    if (casillas[y, x] == null)
                    {
                        posicionesX[x] = 1;
                        break;
                    }
                }
            }            
            return posicionesX;                
        }

          

        /// <summary>
        /// Método para obtener las posiciones válidas en el tablero del eje Y
        /// </summary>
        /// <returns>Arreglo con las posiciones válidas</returns>
        public int[] getPosicionesValidasY()
        {            
            int[] posicionesY = new int[casillas.GetLength(1)];
            for (int y = 0; y < casillas.GetLength(1); y++)
            {                       
                if(casillas[y,marcadores[0]] == null)
                {
                    posicionesY[y] = 1;
                }
                else
                {
                    posicionesY[y] = 0;
                }                       
            }
            return posicionesY;
        }              
          
    }
}
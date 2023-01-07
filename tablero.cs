/*
* ---------- Ayuda!! ----------
*    Se muestra un tablero interactivo que utiliza las teclas de flecha 
*    para moverte en él y la tecla Enter para seleccionar.
*/
//-Importaciones:
using System;

//-Contenido:

namespace Gato_4enLinea
{
    public class Tablero{

        /// <summary>
        /// Atributos de la clase Tablero
        /// </summary>
        private Ficha[,] _casillas;

        /// <summary>
        /// Constructor de la clase Tablero
        /// </summary>
        /// <param name="filas">Filas del tablero</param>
        /// <param name="columnas">Columnas del tablero</param>        
        public Tablero(int filas, int columnas)
        {
            this.casillas = new Ficha[filas,columnas];
        }  

        /// <summary>
        /// Propiedades de la clase Tablero
        /// </summary>
        public Ficha[,] casillas
        {
            get { return _casillas; }
            set { _casillas = value; }
        }
       
        /// <summary>
        /// Método para imprimir el tablero con sobrecarga para colocar ficha
        /// </summary>
        /// <param name="newFicha">Ficha que se va a colocar en el tablero</param>
        /// <param name="ejeY">Eje Y donde se va a colocar la ficha</param>
        public void imprimirTablero(Ficha newFicha, int ejeY)
        {
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
                        casillas[i,j].colocar();
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");

                }
                Console.Write("|");
                if(i == ejeY)
                {
                    Console.ForegroundColor = newFicha.color;
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
        /// Método para imprimir el tablero
        /// </summary>
        public void imprimirTablero()
        {
            for (int j = 0; j < this.casillas.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("----");
            }
            Console.Write("-\n");
            for (int i = 0; i < this.casillas.GetLength(0); i++)
            {
                
                for (int j = 0; j < this.casillas.GetLength(1); j++)
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
                        casillas[i,j].colocar();
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");

                }
                Console.Write("|\n");
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
        /// Método para obtener las posiciones válidas en el tablero
        /// </summary>
        /// <returns>Arreglo con las posiciones válidas</returns>
        public int[] posicionesValidas()
        {
            int[] posicionesX = new int[casillas.GetLength(1)];
            for (int x = 0; x < casillas.GetLength(1); x++)
            {
                posicionesX[x] = 0;
                for (int y = 0; y < casillas.GetLength(0); y++)
                {
                    if(casillas[y,x] == null)
                    {
                        posicionesX[x] = 1;
                        break;
                    }
                }
            }
            return posicionesX;                
        }

        /// <summary>
        /// Método para obtener las posiciones válidas en el tablero del ejeX
        /// </summary>
        /// <param name="ejeX">Eje X donde se va a buscar las posiciones válidas</param>
        /// <returns>Arreglo con las posiciones válidas</returns>
        public int[] posicionesValidas(int ejeX)
        {            
            int[] posicionesY = new int[casillas.GetLength(1)];
            for (int y = 0; y < casillas.GetLength(1); y++)
            {                       
                if(casillas[y,ejeX] == null)
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
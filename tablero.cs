
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
        /// Constructor de la clase Tablero
        /// </summary>
        /// <param name="filas">Filas del tablero</param>
        /// <param name="columnas">Columnas del tablero</param>        
        public Tablero(int filas, int columnas)
        {
            this.casillas = new Ficha[filas,columnas];
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
        /// Método para imprimir el tablero donde se muestra la ficha que se va a colocar
        /// </summary>
        /// <param name="newFicha">Ficha que se va a colocar en el tablero</param>
        /// <param name="ejeY">Eje Y donde se va a colocar la ficha</param>
        public void imprimir(Ficha newFicha, int ejeY)
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
                        casillas[i,j].imprimir();
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
        public void imprimir()
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
                        casillas[i,j].imprimir();
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
    }
}
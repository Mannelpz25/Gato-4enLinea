/*
* ---------- Ayuda!! ----------
*    Se muestra un tablero interactivo que utiliza las teclas de flecha 
*    para moverte en él y la tecla Enter para seleccionar.
*/
//-Importaciones:
using System;
using ficha;
using jugador;

//-Contenido:

namespace tablero
{
    public class Tablero{
        private Ficha[,] casillas { get; set;}
        public Tablero(int filas, int columnas)
        {
            this.casillas = new Ficha[filas,columnas];
        }  
        public Ficha[,] getCasillas()
        {
            return this.casillas;
        }
        public Ficha getFicha(int ejeX, int ejeY)
        {
            return this.casillas[ejeX,ejeY];
        }



        public int getLength(){
            return this.casillas.Length;
        }  
        public void setFicha(Ficha ficha, int ejeX, int ejeY)
        {
            this.casillas[ejeX,ejeY] = ficha;
        }
        public void imprimirTablero(Ficha newFicha, int ejeX, int ejeY)
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
                        if(i == ejeX  && j == ejeY)
                        {
                            newFicha.colocar();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ");
                        }
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
        public void imprimirTablero()
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

        public int[,] posicionesValidas()
        {
            int[,] posiciones = new int[casillas.GetLength(0), casillas.GetLength(1)];
            for (int x = 0; x < casillas.GetLength(1); x++)
            {
                for (int y = 0; y < casillas.GetLength(0); y++)
                {
                    if(casillas[x,y] == null)
                    {
                        posiciones[x,y] = 1;
                    }
                    else
                    {
                        posiciones[x,y] = 0;
                    }
                }
            }
            return posiciones;
        }        
    }
}
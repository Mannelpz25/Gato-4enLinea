/* ---------- Ayuda!! ----------
*    Clase reglas
*   Se modela el objeto reglas con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
using System.Linq;
//-Contenido:
namespace Gato_4enLinea{  
    public class Reglas{
        public void verificarGanador(int numFichas, Tablero tablero, Jugador jugador1, Jugador jugador2){            
            //Verificar horizontal
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    if(tablero.casillas[i, j] != null){                        
                        if(j + numFichas <= tablero.casillas.GetLength(1)){
                            int contador = 0;
                            for(int k = j; k < j + numFichas; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i, k]){
                                    contador++;
                                }
                            }
                            if(contador == numFichas){
                                Console.Clear();
                                switch(tablero.casillas[i, j].figura){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", jugador1.nombre);
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", jugador2.nombre);
                                        break;
                                }
                                tablero.imprimirTablero();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
            //Verificar vertical
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    if(tablero.casillas[i, j] != null){                        
                        if(i + numFichas <= tablero.casillas.GetLength(0)){
                            int contador = 0;
                            for(int k = i; k < i + numFichas; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[k, j]){
                                    contador++;
                                }
                            }
                            if(contador == numFichas){
                                Console.Clear();
                                switch(tablero.casillas[i, j].figura){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", jugador1.nombre);
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", jugador2.nombre);
                                        break;
                                }
                                tablero.imprimirTablero();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
            //Verificar diagonal
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    if(tablero.casillas[i, j] != null){    
                        if(i + numFichas <= tablero.casillas.GetLength(0) && j + numFichas <= tablero.casillas.GetLength(1)){
                            int contador = 0;
                            for(int k = 0; k < numFichas; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i + k, j + k]){
                                    contador++;
                                }
                            }
                            if(contador == numFichas){
                                Console.Clear();
                                switch(tablero.casillas[i, j].figura){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", jugador1.nombre);
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", jugador2.nombre);
                                        break;
                                }
                                tablero.imprimirTablero();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                        if((i + numFichas) <= tablero.casillas.GetLength(0) && (j - numFichas + 1) >= 0){
                            int contador = 0;
                            for(int k = 0; k < numFichas; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i + k, j - k]){       
                                    contador++;
                                }
                            }
                            if(contador == numFichas){
                                Console.Clear();
                                switch(tablero.casillas[i, j].figura){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", jugador1.nombre);
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", jugador2.nombre);
                                        break;
                                }
                                tablero.imprimirTablero();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
        }
    }
}
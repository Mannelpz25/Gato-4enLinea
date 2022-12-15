/* ---------- Ayuda!! ----------
*    Clase Juego
*   Se modela el objeto Juego con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
using ficha;
using tablero;
using jugador;
//-Contenido:
namespace juego{    
    public class Juego{
        private Tablero tablero { get; set;}
        private Jugador jugador1 { get; set;}
        private Jugador jugador2 { get; set;}
        public Juego(int filas, int columnas, Jugador jugador1, Jugador jugador2)
        {
            this.tablero = new Tablero(filas, columnas);
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
        }
        public Tablero getTablero()
        {
            return this.tablero;
        }
        public Tablero setTablero(Tablero tablero)
        {
            this.tablero = tablero;
            return this.tablero;
        }
        public Jugador getJugador1()
        {
            return this.jugador1;
        }

        public Jugador getJugador2()
        {
            return this.jugador2;
        }
    }
    public class Gato:Juego
    {
        public Gato(Jugador jugador1, Jugador jugador2):base(3,3,jugador1,jugador2)
        {
            
        }
        public void verificarGanador(){
            Tablero tablero = this.getTablero();
            for(int i = 0; i < tablero.getCasillas().GetLength(0); i++){
                if (tablero.getFicha(i, 0) != null
                    && tablero.getFicha(i, 0) == tablero.getFicha(i, 1)
                    && tablero.getFicha(i, 1) == tablero.getFicha(i, 2))
                {
                    switch(tablero.getFicha(i, 0).getFigura()){
                        case 'X':
                            Console.WriteLine("Ganador: {0}", this.getJugador1().getNombre());
                            break;
                        case 'O':
                            Console.WriteLine("Ganador: {0}", this.getJugador2().getNombre());
                            break;
                    }
                    Environment.Exit(0);
                }
            }
            for(int i = 0; i < tablero.getCasillas().GetLength(1); i++){
                if (tablero.getFicha(0, i) != null
                    && tablero.getFicha(0, i) == tablero.getFicha(1, i)
                    && tablero.getFicha(1, i) == tablero.getFicha(2, i))
                {
                    switch(tablero.getFicha(0, i).getFigura()){
                        case 'X':
                            Console.WriteLine("Ganador: {0}", this.getJugador1().getNombre());
                            break;
                        case 'O':
                            Console.WriteLine("Ganador: {0}", this.getJugador2().getNombre());
                            break;
                    }
                    Environment.Exit(0);
                }
            }
            if (tablero.getFicha(0, 0) != null
                && tablero.getFicha(0, 0) == tablero.getFicha(1,1)
                && tablero.getFicha(1, 1) == tablero.getFicha(2,2))
            {
                switch(tablero.getFicha(0, 0).getFigura()){
                    case 'X':
                        Console.WriteLine("Ganador: {0}", this.getJugador1().getNombre());
                        break;
                    case 'O':
                        Console.WriteLine("Ganador: {0}", this.getJugador2().getNombre());
                        break;
                }
                Environment.Exit(0);
            }
            if (tablero.getFicha(0, 2) != null
                && tablero.getFicha(0, 2) == tablero.getFicha(1,1)
                && tablero.getFicha(1, 1) == tablero.getFicha(2,0))
            {
                switch(tablero.getFicha(0, 2).getFigura()){
                    case 'X':
                        Console.WriteLine("Ganador: {0}", this.getJugador1().getNombre());
                        break;
                    case 'O':
                        Console.WriteLine("Ganador: {0}", this.getJugador2().getNombre());
                        break;
                }
                Environment.Exit(0);
            }         
        }
        public void jugarTurno(Jugador jugador){            
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeX = -1; // Variable para almacenar la posicion en X
            int ejeY = -1; // Variable para almacenar la posicion en Y
            verificarGanador();
            int[,] posicionesValidas = this.getTablero().posicionesValidas();
            for(int x = 0; x < posicionesValidas.GetLength(1); x++){
                for(int y = 0; y < posicionesValidas.GetLength(0); y++){
                    if(posicionesValidas[x,y] == 1){
                        ejeX = x;
                        ejeY = y;
                        break;
                    }
                }               
                if(ejeX != -1 && ejeY != -1)
                    break;
            }
            if(ejeX == -1 || ejeY == -1){
                Console.WriteLine("Fin del juego....");
                Console.ReadKey();
                return;
            }
            do{
                key = 0;
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                Console.WriteLine("Jugador: {0}", jugador.getNombre());
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
                Console.WriteLine("Utilize las flechas para moverse y pulse Enter para seleccionar... \n");
                this.getTablero().imprimirTablero(jugador.getFicha(), ejeX, ejeY);
                key = Console.ReadKey().Key;     
                // Se evalua si que flecha se presiono
                if(key == ConsoleKey.LeftArrow){
                    if(ejeY > 0){
                        for(int y = ejeY-1; y >= 0; y--){
                            if(posicionesValidas[ejeX,y] == 1){
                                ejeY = y;
                                break;
                            }
                        }
                                                
                    }                    
                } else if(key == ConsoleKey.RightArrow){
                    if(ejeY < posicionesValidas.GetLength(0)-1){
                        for(int y = ejeY+1; y < posicionesValidas.GetLength(0); y++){
                            if(posicionesValidas[ejeX,y] == 1){
                                ejeY = y;
                                break;
                            }
                        }
                    }                    
                } else if (key == ConsoleKey.UpArrow){
                    if(ejeX > 0){
                        for(int x = ejeX-1; x >= 0; x--){
                            if(posicionesValidas[x,ejeY] == 1){
                                ejeX = x;
                                break;
                            }
                        }
                    }
                } else if (key == ConsoleKey.DownArrow){
                    if(ejeX < posicionesValidas.GetLength(1)-1){
                        for(int x = ejeX+1; x < posicionesValidas.GetLength(1); x++){
                            if(posicionesValidas[x,ejeY] == 1){
                                ejeX = x;
                                break;
                            }
                        }
                    }
                } else if (key == ConsoleKey.Enter){
                    this.getTablero().setFicha(jugador.getFicha(),ejeX,ejeY);
                } 
            }while(key != ConsoleKey.Enter);
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto 
        }        
    }

    public class CuatroEnLinea:Juego
    {
        public CuatroEnLinea(Jugador jugador1, Jugador jugador2):base(6, 7, jugador1, jugador2)
        {
            
        }

        public void verificarGanador(){
            Tablero tablero = this.getTablero();
            for(int i = 0; i < tablero.getCasillas().GetLength(0); i++){
                if (tablero.getFicha(i, 0) != null
                    && tablero.getFicha(i, 0) == tablero.getFicha(i, 1)
                    && tablero.getFicha(i, 1) == tablero.getFicha(i, 2))
                {
                    switch(tablero.getFicha(i, 0).getFigura()){
                        case 'X':
                            Console.WriteLine("Ganador: {0}", this.getJugador1().getNombre());
                            break;
                        case 'O':
                            Console.WriteLine("Ganador: {0}", this.getJugador2().getNombre());
                            break;
                    }
                    Environment.Exit(0);
                }
            }
            for(int i = 0; i < tablero.getCasillas().GetLength(1); i++){
                if (tablero.getFicha(0, i) != null
                    && tablero.getFicha(0, i) == tablero.getFicha(1, i)
                    && tablero.getFicha(1, i) == tablero.getFicha(2, i))
                {
                    switch(tablero.getFicha(0, i).getFigura()){
                        case 'X':
                            Console.WriteLine("Ganador: {0}", this.getJugador1().getNombre());
                            break;
                        case 'O':
                            Console.WriteLine("Ganador: {0}", this.getJugador2().getNombre());
                            break;
                    }
                    Environment.Exit(0);
                }
            }
            if (tablero.getFicha(0, 0) != null
                && tablero.getFicha(0, 0) == tablero.getFicha(1,1)
                && tablero.getFicha(1, 1) == tablero.getFicha(2,2))
            {
                switch(tablero.getFicha(0, 0).getFigura()){
                    case 'X':
                        Console.WriteLine("Ganador: {0}", this.getJugador1().getNombre());
                        break;
                    case 'O':
                        Console.WriteLine("Ganador: {0}", this.getJugador2().getNombre());
                        break;
                }
                Environment.Exit(0);
            }
            if (tablero.getFicha(0, 2) != null
                && tablero.getFicha(0, 2) == tablero.getFicha(1,1)
                && tablero.getFicha(1, 1) == tablero.getFicha(2,0))
            {
                switch(tablero.getFicha(0, 2).getFigura()){
                    case 'X':
                        Console.WriteLine("Ganador: {0}", this.getJugador1().getNombre());
                        break;
                    case 'O':
                        Console.WriteLine("Ganador: {0}", this.getJugador2().getNombre());
                        break;
                }
                Environment.Exit(0);
            }         
        }
        public void jugarTurno(Jugador jugador){            
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeX = -1; // Variable para almacenar la posicion en X
            int ejeY = -1; // Variable para almacenar la posicion en Y
            int[,] posicionesValidas = this.getTablero().posicionesValidas();
            for(int x = 0; x < posicionesValidas.GetLength(1); x++){
                for(int y = 0; y < posicionesValidas.GetLength(0); y++){
                    if(posicionesValidas[x,y] == 1){
                        ejeX = x;
                        ejeY = y;
                        break;
                    }
                }               
                if(ejeX != -1 && ejeY != -1)
                    break;
            }
            if(ejeX == -1 || ejeY == -1){
                Console.WriteLine("Fin del juego....");
                Console.ReadKey();
                return;
            }
            do{
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                Console.WriteLine("Jugador: {0}", jugador.getNombre());
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
                Console.WriteLine("Utilize las flechas para moverse y pulse Enter para seleccionar... \n");
                this.getTablero().imprimirTablero(jugador.getFicha(), ejeX, ejeY);
                key = Console.ReadKey().Key;

                // Se evalua si que flecha se presiono
                if(key == ConsoleKey.LeftArrow){
                    if(ejeY > 0){
                        for(int y = ejeY-1; y >= 0; y--){
                            if(posicionesValidas[ejeX,y] == 1){
                                ejeY = y;
                                break;
                            }
                        }
                    }                    
                } else if(key == ConsoleKey.RightArrow){
                    if(ejeY < posicionesValidas.GetLength(0)-1){
                        for(int y = ejeY+1; y < posicionesValidas.GetLength(0); y++){
                            if(posicionesValidas[ejeX,y] == 1){
                                ejeY = y;
                                break;
                            }
                        }
                    }                    
                } else if (key == ConsoleKey.UpArrow){
                    if(ejeX > 0){
                        for(int x = ejeX-1; x >= 0; x--){
                            if(posicionesValidas[x,ejeY] == 1){
                                ejeX = x;
                                break;
                            }
                        }
                    }
                } else if (key == ConsoleKey.DownArrow){
                    if(ejeX < posicionesValidas.GetLength(1)-1){
                        for(int x = ejeX+1; x < posicionesValidas.GetLength(1); x++){
                            if(posicionesValidas[x,ejeY] == 1){
                                ejeX = x;
                                break;
                            }
                        }
                    }
                } else if (key == ConsoleKey.Enter){
                    this.getTablero().setFicha(jugador.getFicha(),ejeX,ejeY);
                } 
            }while(key != ConsoleKey.Enter);
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto 
        }        
    }    
   
}
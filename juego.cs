/* ---------- Ayuda!! ----------
*    Clase Juego
*   Se modela el objeto Juego con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
using System.Linq;
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
        public void verificarGanador(int numFichas){
            Tablero tablero = this.getTablero();
            //Verificar horizontal
            for(int i = 0; i < tablero.getCasillas().GetLength(0); i++){
                for(int j = 0; j < tablero.getCasillas().GetLength(1); j++){
                    if(tablero.getFicha(i, j) != null){                        
                        if(j + numFichas <= tablero.getCasillas().GetLength(1)){
                            int contador = 0;
                            for(int k = j; k < j + numFichas; k++){
                                if(tablero.getFicha(i, j) == tablero.getFicha(i, k)){
                                    contador++;
                                }
                            }
                            if(contador == numFichas){
                                Console.Clear();
                                switch(tablero.getFicha(i, j).getFigura()){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", this.getJugador1().getNombre());
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", this.getJugador2().getNombre());
                                        break;
                                }
                                this.getTablero().imprimirTablero();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
            //Verificar vertical
            for(int i = 0; i < tablero.getCasillas().GetLength(0); i++){
                for(int j = 0; j < tablero.getCasillas().GetLength(1); j++){
                    if(tablero.getFicha(i, j) != null){                        
                        if(i + numFichas <= tablero.getCasillas().GetLength(0)){
                            int contador = 0;
                            for(int k = i; k < i + numFichas; k++){
                                if(tablero.getFicha(i, j) == tablero.getFicha(k, j)){
                                    contador++;
                                }
                            }
                            if(contador == numFichas){
                                Console.Clear();
                                switch(tablero.getFicha(i, j).getFigura()){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", this.getJugador1().getNombre());
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", this.getJugador2().getNombre());
                                        break;
                                }
                                this.getTablero().imprimirTablero();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
            //Verificar diagonal
            for(int i = 0; i < tablero.getCasillas().GetLength(0); i++){
                for(int j = 0; j < tablero.getCasillas().GetLength(1); j++){
                    if(tablero.getFicha(i, j) != null){    
                        if(i + numFichas <= tablero.getCasillas().GetLength(0) && j + numFichas <= tablero.getCasillas().GetLength(1)){
                            int contador = 0;
                            for(int k = 0; k < numFichas; k++){
                                if(tablero.getFicha(i, j) == tablero.getFicha(i + k, j + k)){
                                    contador++;
                                }
                            }
                            if(contador == numFichas){
                                Console.Clear();
                                switch(tablero.getFicha(i, j).getFigura()){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", this.getJugador1().getNombre());
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", this.getJugador2().getNombre());
                                        break;
                                }
                                this.getTablero().imprimirTablero();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                        if((i + numFichas) <= tablero.getCasillas().GetLength(0) && (j - numFichas + 1) >= 0){
                            int contador = 0;
                            for(int k = 0; k < numFichas; k++){
                                if(tablero.getFicha(i, j) == tablero.getFicha(i + k, j - k)){       
                                    contador++;
                                }
                            }
                            if(contador == numFichas){
                                Console.Clear();
                                switch(tablero.getFicha(i, j).getFigura()){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", this.getJugador1().getNombre());
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", this.getJugador2().getNombre());
                                        break;
                                }
                                this.getTablero().imprimirTablero();
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
    public class Gato:Juego
    {
        public Gato(Jugador jugador1, Jugador jugador2):base(3,3,jugador1,jugador2)
        {
            
        }
        
        public void seleccionarColumna(Jugador jugador){            
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeX = -1; // Variable para almacenar la posicion en X
            verificarGanador(3);
            int[] posicionesValidas = this.getTablero().posicionesValidas();
            if(posicionesValidas.Sum() == 0 ){
                Console.Clear();
                Console.WriteLine("Empate\n");
                this.getTablero().imprimirTablero();
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
                if(ejeX == -1){
                    for(int x = 0; x < posicionesValidas.Length; x++){
                        if(posicionesValidas[x] == 1){
                            Console.ForegroundColor = jugador.getFicha().getColor();
                            Console.Write("  ▼\n");
                            ejeX = x;
                            break;
                        }else{
                            Console.Write("    ");
                        }
                    }
                }else{
                    for(int x = 0; x < posicionesValidas.Length; x++){                        
                        if(x == ejeX){
                            Console.ForegroundColor = jugador.getFicha().getColor();
                            Console.Write("  ▼\n");  
                            break;
                        }else{
                            Console.Write("    ");
                        }  
                    }
                }
                this.getTablero().imprimirTablero();
                key = Console.ReadKey().Key;     
                // Se evalua si que flecha se presiono
                if(key == ConsoleKey.LeftArrow){
                    if(ejeX > 0){
                        for(int x = ejeX-1; x >= 0; x--){
                            if(posicionesValidas[x] == 1){
                                ejeX = x;
                                break;
                            }
                        }
                                                
                    }                    
                } else if(key == ConsoleKey.RightArrow){
                    if(ejeX < posicionesValidas.Length){
                        for(int x = ejeX+1; x < posicionesValidas.Length; x++){
                            if(posicionesValidas[x] == 1){
                                ejeX = x;
                                break;
                            }
                        }
                    } 
                } 
            }while(key != ConsoleKey.Enter);
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto 
            seleccionarFila(ejeX, jugador);
        }        

        public void seleccionarFila(int ejeX, Jugador jugador){
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeY = -1; // Variable para almacenar la posicion en X
            int[] posicionesValidas = this.getTablero().posicionesValidas(ejeX);
            do{
                key = 0;
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                Console.WriteLine("Jugador: {0}", jugador.getNombre());
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
                Console.WriteLine("Utilize las flechas para moverse y pulse Enter para seleccionar... \n"); 
                for(int x = 0; x <= ejeX; x++){
                    if(ejeX==x){                         
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("  ▼\n");
                        break;
                    }else{
                        Console.Write("    ");
                    }
                }              
                if(ejeY == -1){
                    for(int y = 0; y < posicionesValidas.Length; y++){
                        if(posicionesValidas[y] == 1){                            
                            ejeY = y;
                            break;
                        }
                    }
                }  
                this.getTablero().imprimirTablero(jugador.getFicha(), ejeY);
                key = Console.ReadKey().Key;     
                // Se evalua si que flecha se presiono
                if(key == ConsoleKey.UpArrow){
                    if(ejeY > 0){
                        for(int y = ejeY-1; y >= 0; y--){
                            if(posicionesValidas[y] == 1){
                                ejeY = y;
                                break;
                            }
                        }
                                                
                    }                    
                } else if(key == ConsoleKey.DownArrow){
                    if(ejeY < posicionesValidas.Length){
                        for(int y = ejeY+1; y < posicionesValidas.Length; y++){
                            if(posicionesValidas[y] == 1){
                                ejeY = y;
                                break;
                            }
                        }
                    } 
                } 
            }while(key != ConsoleKey.Enter);
            this.getTablero().setFicha(jugador.getFicha() ,ejeY, ejeX);
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto 
        }
    }

    public class CuatroEnLinea:Juego
    {
        public CuatroEnLinea(Jugador jugador1, Jugador jugador2):base(6, 7, jugador1, jugador2)
        {
            
        }
        
        public void seleccionarColumna(Jugador jugador){            
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeX = -1; // Variable para almacenar la posicion en X
            verificarGanador(4);
            int[] posicionesValidas = this.getTablero().posicionesValidas();
            if(posicionesValidas.Sum() == 0 ){
                Console.Clear();
                Console.WriteLine("Empate\n");
                this.getTablero().imprimirTablero();
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
                if(ejeX == -1){
                    for(int x = 0; x < posicionesValidas.Length; x++){
                        if(posicionesValidas[x] == 1){
                            Console.ForegroundColor = jugador.getFicha().getColor();
                            Console.Write("  ▼\n");
                            ejeX = x;
                            break;
                        }else{
                            Console.Write("    ");
                        }
                    }
                }else{
                    for(int x = 0; x < posicionesValidas.Length; x++){                        
                        if(x == ejeX){
                            Console.ForegroundColor = jugador.getFicha().getColor();
                            Console.Write("  ▼\n");  
                            break;
                        }else{
                            Console.Write("    ");
                        }  
                    }
                }
                this.getTablero().imprimirTablero();
                key = Console.ReadKey().Key;     
                // Se evalua si que flecha se presiono
                if(key == ConsoleKey.LeftArrow){
                    if(ejeX > 0){
                        for(int x = ejeX-1; x >= 0; x--){
                            if(posicionesValidas[x] == 1){
                                ejeX = x;
                                break;
                            }
                        }
                                                
                    }                    
                } else if(key == ConsoleKey.RightArrow){
                    if(ejeX < posicionesValidas.Length){
                        for(int x = ejeX+1; x < posicionesValidas.Length; x++){
                            if(posicionesValidas[x] == 1){
                                ejeX = x;
                                break;
                            }
                        }
                    } 
                } 
            }while(key != ConsoleKey.Enter);
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto 
            dejarCaerFicha(ejeX, jugador);
        }     
        public void dejarCaerFicha(int ejeX, Jugador jugador){
            for(int y = this.getTablero().getCasillas().GetLength(0)-1; y >= 0; y--){
                if(this.getTablero().getFicha(y, ejeX) == null){
                    this.getTablero().setFicha(jugador.getFicha(), y, ejeX);
                    break;
                }
            }
        }
        
    }    
   
}
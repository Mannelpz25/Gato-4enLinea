/* ---------- Ayuda!! ----------
*    Clase Juego
*   Se modela el objeto Juego con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
using System.Linq;
//-Contenido:
namespace Gato_4enLinea{    
    public class Juego{

        /// <summary>
        /// Atributos de la clase Juego
        /// </summary>
        private Tablero _tablero;
        private Jugador _jugador1;
        private Jugador _jugador2;
        private Reglas _reglas = new Reglas();

        /// <summary>
        /// Constructor de la clase Juego
        /// </summary>
        /// <param name="filas">Filas del tablero</param>
        /// <param name="columnas">Columnas del tablero</param>
        /// <param name="jugador1">Jugador 1</param>
        /// <param name="jugador2">Jugador 2</param>
        public Juego(int filas, int columnas, Jugador jugador1, Jugador jugador2)
        {
            this.tablero = new Tablero(filas, columnas);
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
        }

        /// <summary>
        /// Propiedades de la clase Juego
        /// </summary>
        public Tablero tablero
        {
            get { return _tablero; }
            set { _tablero = value; }
        }
        public Jugador jugador1
        {
            get { return _jugador1; }
            set { _jugador1 = value; }
        }
        public Jugador jugador2
        {
            get { return _jugador2; }
            set { _jugador2 = value; }
        }      
        public Reglas reglas
        {
            get { return _reglas; }
            set { _reglas = value; }
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
            reglas.verificarGanador(3,this.tablero, this.jugador1, this.jugador2);
            int[] posicionesValidas = this.tablero.posicionesValidas();
            if(posicionesValidas.Sum() == 0 ){
                Console.Clear();
                Console.WriteLine("Empate\n");
                this.tablero.imprimirTablero();
                Console.WriteLine("Fin del juego....");
                Console.ReadKey();
                return;
            }
            do{
                key = 0;
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                Console.WriteLine("Jugador: {0}", jugador.nombre);
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
                Console.WriteLine("Utilize las flechas para moverse y pulse Enter para seleccionar... \n");
                if(ejeX == -1){
                    for(int x = 0; x < posicionesValidas.Length; x++){
                        if(posicionesValidas[x] == 1){
                            Console.ForegroundColor = jugador.ficha.color;
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
                            Console.ForegroundColor = jugador.ficha.color;
                            Console.Write("  ▼\n");  
                            break;
                        }else{
                            Console.Write("    ");
                        }  
                    }
                }
                this.tablero.imprimirTablero();
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
            int[] posicionesValidas = this.tablero.posicionesValidas(ejeX);
            do{
                key = 0;
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                Console.WriteLine("Jugador: {0}", jugador.nombre);
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
                this.tablero.imprimirTablero(jugador.ficha, ejeY);
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
            this.tablero.casillas[ejeY, ejeX] = jugador.ficha ;
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
            reglas.verificarGanador(4,this.tablero, this.jugador1, this.jugador2);
            int[] posicionesValidas = this.tablero.posicionesValidas();
            if(posicionesValidas.Sum() == 0 ){
                Console.Clear();
                Console.WriteLine("Empate\n");
                this.tablero.imprimirTablero();
                Console.WriteLine("Fin del juego....");
                Console.ReadKey();
                return;
            }
            do{
                key = 0;
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                Console.WriteLine("Jugador: {0}", jugador.nombre);
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
                Console.WriteLine("Utilize las flechas para moverse y pulse Enter para seleccionar... \n");
                if(ejeX == -1){
                    for(int x = 0; x < posicionesValidas.Length; x++){
                        if(posicionesValidas[x] == 1){
                            Console.ForegroundColor = jugador.ficha.color;
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
                            Console.ForegroundColor = jugador.ficha.color;
                            Console.Write("  ▼\n");  
                            break;
                        }else{
                            Console.Write("    ");
                        }  
                    }
                }
                this.tablero.imprimirTablero();
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
            for(int y = this.tablero.casillas.GetLength(0)-1; y >= 0; y--){
                if(this.tablero.casillas[y, ejeX] == null){
                    this.tablero.casillas[y, ejeX] = jugador.ficha;
                    break;
                }
            }
        }
        
    }    
   
}
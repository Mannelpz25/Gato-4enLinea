//-Importaciones:
using System;
//-Contenido:
namespace Gato_4enLinea{    
    /// <summary>
    /// Clase que modela un juego, contiene los jugadores, el tablero y las reglas
    /// </summary>
    public abstract class Juego{
        /// <summary>
        /// Almacenamiento del tablero
        /// </summary>
        private Tablero _tablero;

        /// <summary>
        /// Almacenamiento del jugador ganador
        /// </summary>
        private Jugador _jugadorGanador;

        /// <summary>
        /// Almacenamiento del jugador 1
        /// </summary>
        private Jugador _jugador1;
        /// <summary>
        /// Almacenamiento del jugador 2
        /// </summary>
        private Jugador _jugador2;

        /// <summary>
        /// Almacenamiento de las reglas
        /// </summary>
        private ReglaAbstract [] _reglas;

        /// <summary>
        /// Tablero del juego
        /// </summary>
        public Tablero tablero
        {
            get { return _tablero; }
            set { _tablero = value; }
        }

        /// <summary>
        /// Jugador ganador
        /// </summary>
        public Jugador jugadorGanador
        {
            get { return _jugadorGanador; }
            set { _jugadorGanador = value; }
        }

        /// <summary>
        /// Jugador 1
        /// </summary>
        public Jugador jugador1
        {
            get { return _jugador1; }
            set { _jugador1 = value; }
        }

        /// <summary>
        /// Jugador 2
        /// </summary>
        public Jugador jugador2
        {
            get { return _jugador2; }
            set { _jugador2 = value; }
        }

        /// <summary>
        /// Reglas del juego
        /// </summary>
        public ReglaAbstract[] reglas
        {
            get { return _reglas; }
            set { _reglas = value; }
        }

        /// <summary>
        /// Enumerador de resultados
        /// </summary>
        public enum results
        {
            WIN,
            DRAW,
        }

        /// <summary>
        /// Método abstacto para inicializar el juego
        /// </summary>
        public abstract void init();

        /// <summary>
        /// Método abstacto para comenzar el juego
        /// </summary>
        public abstract void run();

        /// <summary>
        /// Método abstacto para resultado el juego
        /// </summary>
        public abstract void result();   
    }    

    /// <summary>
    /// Clase que modela un juego de gato
    /// </summary>
    public class JuegoGato : Juego
    {
        /// <summary>
        /// Método para inicializar el juego
        /// </summary>
        public override void init()
        {
            // Inicializar tablero
            tablero = new Tablero(3, 3);

            // Inicializar jugadores
            String nombreJugador1;
            String nombreJugador2;
            Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
            Console.WriteLine("Ingrese el nombre del jugador 1:");
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto
            nombreJugador1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
            Console.WriteLine("Ingrese el nombre del jugador 2:");
            Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto
            nombreJugador2 = Console.ReadLine();

            jugador1 = new Jugador(nombreJugador1, 'X', ConsoleColor.Red);
            jugador2 = new Jugador(nombreJugador2, 'O', ConsoleColor.Blue);

            // Inicializar reglas
            reglas = new ReglaAbstract[4];
            reglas[0] = new ReglaHorizontal(3);
            reglas[1] = new ReglaVertical(3);
            reglas[2] = new ReglaDiagonal(3);
            reglas[3] = new ReglaTableroLleno();
        }

        /// <summary>
        /// Método para comenzar el juego
        /// </summary>
        public override void run()
        {
            int turno = 0;
            do{
                turno += seleccionarColumna(jugador1);
                if(verificarReglas(jugador1))
                    break;
                turno += seleccionarColumna(jugador2);
                if(verificarReglas(jugador2))
                    break;
            } while (turno != 9);
        }

        /// <summary>
        /// Método para resultado el juego
        /// </summary>
        public override void result()
        {
            if (jugadorGanador == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
                Console.WriteLine(results.DRAW.ToString());
                Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
                Console.WriteLine("Ganador: " + jugadorGanador.nombre);
                Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto
            }
        }

        /// <summary>
        /// Método para verificar las reglas del juego
        /// </summary>
        public bool verificarReglas(Jugador jugador)
        {
            foreach (ReglaAbstract regla in reglas)
            {
                if (regla.evaluar(tablero, jugador.ficha))
                {
                    if(regla is ReglaTableroLleno){
                        jugadorGanador = null;
                        return true;
                    }
                    jugadorGanador = jugador;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Método para seleccionar la columna en la que se desea colocar la ficha
        /// </summary>
        /// <param name="jugador">Jugador que desea colocar la ficha</param>
        public int seleccionarColumna(Jugador jugador){            
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeX = -1; // Variable para almacenar la posicion en X
            int[] posicionesValidas = tablero.getPosicionesValidasX();
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
                            ejeX = x;
                            break;
                        }
                    }
                }
                tablero.marcadores[0] = ejeX;
                tablero.marcadores[1] = -1;
                this.tablero.imprimir(); 
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
            return seleccionarFila(jugador);
        } 

         /// <summary>
        /// Método para seleccionar la fila en la que se desea colocar la ficha
        /// </summary>
        /// <param name="ejeX">Posicion en X</param>
        /// <param name="jugador">Jugador que desea colocar la ficha</param>
        public int seleccionarFila(Jugador jugador){
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeY = -1; // Variable para almacenar la posicion en X
            int[] posicionesValidas = tablero.getPosicionesValidasY();
            do{
                key = 0;
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                Console.WriteLine("Jugador: {0}", jugador.nombre);
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
                Console.WriteLine("Utilize las flechas para moverse y pulse Enter para seleccionar... \n"); 
                if(ejeY == -1){
                    for(int y = 0; y < posicionesValidas.Length; y++){
                        if(posicionesValidas[y] == 1){                            
                            ejeY = y;
                            break;
                        }
                    }
                }  
                tablero.marcadores[1] = ejeY;
                this.tablero.imprimir();
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
            this.tablero.casillas[tablero.marcadores[1], tablero.marcadores[0]] = jugador.ficha ;
            return 1;// Cambia el color del texto 
        }       
    }          
   
}
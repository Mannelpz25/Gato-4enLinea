//-Importaciones:
using System;
using System.Linq;
//-Contenido:
namespace Gato_4enLinea{    
    /// <summary>
    /// Clase Juego
    /// </summary>
    public class Juego{

        /// <summary>
        /// Almacenamiento del tablero
        /// </summary>
        private Tablero _tablero;
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
        private Regla[] _reglas;


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
        /// Tablero del juego
        /// </summary>
        public Tablero tablero
        {
            get { return _tablero; }
            set { _tablero = value; }
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
        public Regla[] reglas
        {
            get { return _reglas; }
            set { _reglas = value; }
        }

        /// <summary>
        /// verifica si hay un ganador con las reglas del juego
        /// </summary>
        public void verificarGanador(){            
            //Verificar horizontal
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    if(tablero.casillas[i, j] != null){                        
                        if(j + reglas[0].valor <= tablero.casillas.GetLength(1)){
                            int contador = 0;
                            for(int k = j; k < j + reglas[0].valor; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i, k]){
                                    contador++;
                                }
                            }
                            if(reglas[0].seCumple(contador)){
                                Console.Clear();
                                switch(tablero.casillas[i, j].figura){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", jugador1.nombre);
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", jugador2.nombre);
                                        break;
                                }
                                tablero.imprimir();
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
                        if(i + reglas[0].valor <= tablero.casillas.GetLength(0)){
                            int contador = 0;
                            for(int k = i; k < i + reglas[0].valor; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[k, j]){
                                    contador++;
                                }
                            }
                            if(reglas[0].seCumple(contador)){
                                Console.Clear();
                                switch(tablero.casillas[i, j].figura){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", jugador1.nombre);
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", jugador2.nombre);
                                        break;
                                }
                                tablero.imprimir();
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
                        if(i + reglas[0].valor <= tablero.casillas.GetLength(0) && j + reglas[0].valor <= tablero.casillas.GetLength(1)){
                            int contador = 0;
                            for(int k = 0; k < reglas[0].valor; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i + k, j + k]){
                                    contador++;
                                }
                            }
                            if(reglas[0].seCumple(contador)){
                                Console.Clear();
                                switch(tablero.casillas[i, j].figura){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", jugador1.nombre);
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", jugador2.nombre);
                                        break;
                                }
                                tablero.imprimir();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                        if((i + reglas[0].valor) <= tablero.casillas.GetLength(0) && (j - reglas[0].valor + 1) >= 0){
                            int contador = 0;
                            for(int k = 0; k < reglas[0].valor; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i + k, j - k]){       
                                    contador++;
                                }
                            }
                            if(reglas[0].seCumple(contador)){
                                Console.Clear();
                                switch(tablero.casillas[i, j].figura){
                                    case 'X':
                                        Console.WriteLine("Ganador: {0}\n", jugador1.nombre);
                                        break;
                                    case 'O':
                                        Console.WriteLine("Ganador: {0}\n", jugador2.nombre);
                                        break;
                                }
                                tablero.imprimir();
                                Console.WriteLine("Fin del juego....");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Obtiene las posiciones válidas en el tablero
        /// </summary>
        /// <returns>Arreglo con las posiciones válidas</returns>
        public int[] getPosicionesValidas()
        {
            int[] posicionesX = new int[tablero.casillas.GetLength(1)];
            for (int x = 0; x < tablero.casillas.GetLength(1); x++)
            {
                posicionesX[x] = 0;
                for (int y = 0; y < tablero.casillas.GetLength(0); y++)
                {
                    if(!reglas[2].seCumple(tablero.casillas[y,x] == null ? 0 : 1))
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
        public int[] getPosicionesValidasX(int ejeX)
        {            
            int[] posicionesY = new int[tablero.casillas.GetLength(1)];
            for (int y = 0; y < tablero.casillas.GetLength(1); y++)
            {                       
                if(!reglas[2].seCumple(tablero.casillas[y,ejeX] == null ? 0 : 1 ))
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
    public class Gato:Juego
    {
        /// <summary>
        /// Almacenamiento de las reglas
        /// </summary>
        private Regla[] _reglas = new Regla[4]
        {
            new Regla(3, "Si hay 3 fichas iguales en linea gana el jugador"),
            new Regla(0, "Si se llena el tablero sin ganador se declara empate"),
            new Regla(1, "Si la casilla ya esta ocupada no se puede colocar la ficha"),
            new Regla(9, "El tamaño del tablero es 3x3")
        };
        /// <summary>
        /// Constructor de la clase Gato
        /// </summary>
        /// <param name="jugador1">Jugador 1</param>
        /// <param name="jugador2">Jugador 2</param>        
        public Gato(Jugador jugador1, Jugador jugador2):base(3,3,jugador1,jugador2)
        {
            this.reglas = _reglas;
        }

        
        /// <summary>
        /// Método para seleccionar la columna en la que se desea colocar la ficha
        /// </summary>
        /// <param name="jugador">Jugador que desea colocar la ficha</param>
        public int seleccionarColumna(Jugador jugador){            
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeX = -1; // Variable para almacenar la posicion en X
            verificarGanador();
            int[] posicionesValidas = getPosicionesValidas();
            if(reglas[1].seCumple(posicionesValidas.Sum())){
                Console.Clear();
                Console.WriteLine("Empate\n");
                this.tablero.imprimir();
                Console.WriteLine("Fin del juego....");
                Console.ReadKey();
                return 0;
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
            return seleccionarFila(ejeX, jugador);
        }        

        /// <summary>
        /// Método para seleccionar la fila en la que se desea colocar la ficha
        /// </summary>
        /// <param name="ejeX">Posicion en X</param>
        /// <param name="jugador">Jugador que desea colocar la ficha</param>
        public int seleccionarFila(int ejeX, Jugador jugador){
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeY = -1; // Variable para almacenar la posicion en X
            int[] posicionesValidas = getPosicionesValidasX(ejeX);
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
                this.tablero.imprimir(jugador.ficha, ejeY);
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
            Console.ForegroundColor = ConsoleColor.Gray; 
            return 1;// Cambia el color del texto 
        }
    }

    public class CuatroEnLinea:Juego
    {
        /// <summary>
        /// Almacenamiento de las reglas
        /// </summary>
        private Regla[] _reglas = new Regla[4]
        {
            new Regla(4, "Si hay 4 fichas iguales en linea gana el jugador"),
            new Regla(0, "Si se llena el tablero sin ganador se declara empate"),
            new Regla(1, "Si la casilla ya esta ocupada no se puede colocar la ficha"),
            new Regla(42, "El tamaño del tablero es 6x7")
        };
        public CuatroEnLinea(Jugador jugador1, Jugador jugador2):base(6, 7, jugador1, jugador2)
        {
            this.reglas = _reglas;
        }
        
        /// <summary>
        /// Método para seleccionar la columna en la que se desea colocar la ficha
        /// </summary>
        /// <param name="jugador">Jugador que desea colocar la ficha</param>
        public int seleccionarColumna(Jugador jugador){            
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            int ejeX = -1; // Variable para almacenar la posicion en X
            verificarGanador();
            int[] posicionesValidas = getPosicionesValidas();
            if(reglas[1].seCumple(posicionesValidas.Sum())){
                Console.Clear();
                Console.WriteLine("Empate\n");
                this.tablero.imprimir();
                Console.WriteLine("Fin del juego....");
                Console.ReadKey();
                return 0;
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
            return dejarCaerFicha(ejeX, jugador);
        }     

        ///<summary>
        /// Método para dejar caer la ficha en la columna seleccionada
        ///</summary>
        ///<param name="ejeX">Posicion en X</param>
        ///<param name="jugador">Jugador que desea colocar la ficha</param>
        public int dejarCaerFicha(int ejeX, Jugador jugador){
            for(int y = this.tablero.casillas.GetLength(0)-1; y >= 0; y--){
                if(this.tablero.casillas[y, ejeX] == null){
                    this.tablero.casillas[y, ejeX] = jugador.ficha;
                    return 1;
                }
            }
            return 0;
        }
        
    }    
   
}
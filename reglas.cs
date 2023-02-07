using System;

namespace Gato_4enLinea{  
    /// <summary>
    /// Clase abstracta para la represntación de una regla
    /// </summary>
    public abstract class ReglaAbstract{
        
        /// <summary>
        /// Método abstracto para evaluar la regla
        /// </summary>
        public abstract bool evaluar(Tablero tablero, Ficha ficha);
        
    }

    /// <summary>
    /// Clase para la representación de la regla para ganar en horizontal
    /// </summary>
    public class ReglaHorizontal : ReglaAbstract{
        /// <summary>
        /// Almacena el número de fichas que se deben colocar en línea para ganar
        /// </summary>
        private int _numeroFichas;

        /// <summary>
        /// Número de fichas que se deben colocar en línea para ganar
        /// </summary>
        public int numeroFichas{
            get { return _numeroFichas; }
            set { _numeroFichas = value; }
        }

        /// <summary>
        /// Constructor de la clase ReglaHorizontal
        /// </summary>
        /// <param name="numeroFichas">Número de fichas que se deben colocar en línea para ganar</param>
        public ReglaHorizontal(int numeroFichas){
            this.numeroFichas = numeroFichas;
        }

        /// <summary>
        /// Método para evaluar la regla
        /// </summary>
        /// <param name="tablero">Tablero donde se evaluará la regla</param>
        /// <param name="ficha">Ficha que se evaluará</param>
        /// <returns>True si se cumple la regla, false en caso contrario</returns>
        public override bool evaluar(Tablero tablero, Ficha ficha){
            //Recorremos las filas
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    //Verificamos que la casilla no esté vacía
                    if(tablero.casillas[i, j] != null){        
                        //Verificamos que no se salga del tablero                
                        if(j + numeroFichas <= tablero.casillas.GetLength(1)){
                            int contador = 0;
                            //Recorremos las casillas en línea
                            for(int k = j; k < j + numeroFichas; k++){
                                //Verificamos que las casillas sean iguales
                                if(tablero.casillas[i, j] == tablero.casillas[i, k])
                                    //Si son iguales, incrementamos el contador
                                    contador++;                                
                            }
                            //Si el contador es igual al número de fichas
                            if(numeroFichas == contador)
                                //Verificamos que la casilla sea igual a la ficha
                                if(tablero.casillas[i, j] == ficha)
                                    //Se cumple la regla
                                    return true;
                        }
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// Clase para la representación de la regla para ganar en vertical
    /// </summary>
    public class ReglaVertical : ReglaAbstract{
        /// <summary>
        /// Almacena el número de fichas que se deben colocar en línea para ganar
        /// </summary>
        private int _numeroFichas;

        /// <summary>
        /// Número de fichas que se deben colocar en línea para ganar
        /// </summary>
        public int numeroFichas{
            get { return _numeroFichas; }
            set { _numeroFichas = value; }
        }

        /// <summary>
        /// Constructor de la clase ReglaHorizontal
        /// </summary>
        /// <param name="numeroFichas">Número de fichas que se deben colocar en línea para ganar</param>
        public ReglaVertical(int numeroFichas){
            this.numeroFichas = numeroFichas;
        }

        /// <summary>
        /// Método para evaluar la regla
        /// </summary>
        /// <param name="tablero">Tablero donde se evaluará la regla</param>
        /// <param name="ficha">Ficha que se evaluará</param>
        /// <returns>True si se cumple la regla, false en caso contrario</returns>
        public override bool evaluar(Tablero tablero, Ficha ficha){
            //Recorremos el tablero
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    //Si la casilla no está vacía
                    if(tablero.casillas[i, j] != null){     
                        //Si el número de fichas que se deben colocar en línea para ganar no sobrepasa el tamaño del tablero                   
                        if(i + numeroFichas <= tablero.casillas.GetLength(0)){
                            int contador = 0;
                            //Recorremos las casillas de la columna
                            for(int k = i; k < i + numeroFichas; k++){
                                //Si la casilla es igual a la casilla que estamos evaluando
                                if(tablero.casillas[i, j] == tablero.casillas[k, j]){
                                    //Incrementamos el contador
                                    contador++;
                                }
                            }
                            //Si el contador es igual al número de fichas que se deben colocar en línea para ganar
                            if(numeroFichas == contador)
                                //Si la ficha que se está evaluando es igual a la ficha que se está evaluando
                                if(tablero.casillas[i, j] == ficha)
                                    //Se cumple la regla
                                    return true;
                        }
                    }
                }
            }
            return false;            
        }
    }

     /// <summary>
    /// Clase para la representación de la regla para ganar en diagonal
    /// </summary>
    public class ReglaDiagonal: ReglaAbstract{
        /// <summary>
        /// Almacena el número de fichas que se deben colocar en línea para ganar
        /// </summary>
        private int _numeroFichas;

        /// <summary>
        /// Número de fichas que se deben colocar en línea para ganar
        /// </summary>
        public int numeroFichas{
            get { return _numeroFichas; }
            set { _numeroFichas = value; }
        }

        /// <summary>
        /// Constructor de la clase ReglaHorizontal
        /// </summary>
        /// <param name="numeroFichas">Número de fichas que se deben colocar en línea para ganar</param>
        public ReglaDiagonal(int numeroFichas){
            this.numeroFichas = numeroFichas;
        }

        /// <summary>
        /// Método para evaluar la regla
        /// </summary>
        /// <param name="tablero">Tablero donde se evaluará la regla</param>
        /// <param name="ficha">Ficha que se evaluará</param>
        /// <returns>True si se cumple la regla, false en caso contrario</returns>
        public override bool evaluar(Tablero tablero, Ficha ficha){
            //Verificar diagonal
            //Se recorre el tablero buscando una ficha
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    //Si la casilla no está vacía
                    if(tablero.casillas[i, j] != null){    
                        //Diagonal normal
                        //Si la suma de la fila y el número de fichas no excede el tamaño del tablero
                        if(i + numeroFichas <= tablero.casillas.GetLength(0) && j + numeroFichas <= tablero.casillas.GetLength(1)){
                            int contador = 0;
                            //Se recorre el número de fichas buscando coincidencias
                            for(int k = 0; k < numeroFichas; k++){
                                //Si la ficha de la casilla es igual a la ficha de la casilla a la que se está comparando
                                if(tablero.casillas[i, j] == tablero.casillas[i + k, j + k]){
                                    //Se incrementa el contador
                                    contador++;
                                }
                            }
                            //Si el contador es igual al número de fichas
                             if(numeroFichas == contador)
                                //Si la ficha de la casilla es igual a la ficha que se está evaluando
                                if(tablero.casillas[i, j] == ficha)
                                    //Se cumple la regla
                                    return true;
                        }
                        //Diagonal inversa
                        //Si la suma de la fila y el número de fichas no excede el tamaño del tablero
                        if((i + numeroFichas) <= tablero.casillas.GetLength(0) && (j - numeroFichas + 1) >= 0){
                            int contador = 0;
                            //Se recorre el número de fichas buscando coincidencias
                            for(int k = 0; k < numeroFichas; k++){
                                //Si la ficha de la casilla es igual a la ficha de la casilla a la que se está comparando
                                if(tablero.casillas[i, j] == tablero.casillas[i + k, j - k]){     
                                    //Se incrementa el contador  
                                    contador++;
                                }
                            }
                            //Si el contador es igual al número de fichas
                             if(numeroFichas == contador)
                                //Si la ficha de la casilla es igual a la ficha que se está evaluando
                                if(tablero.casillas[i, j] == ficha)
                                    //Se cumple la regla
                                    return true;
                        }
                    }
                }
            }
            return false;
        }
    }
  

    /// <summary>
    /// Clase para la representación de la regla para verificar si el tablero está lleno
    /// </summary>
    public class ReglaTableroLleno: ReglaAbstract{
        /// <summary>
        /// Método para evaluar la regla
        /// </summary>
        /// <param name="tablero">Tablero donde se evaluará la regla</param>
        /// <param name="ficha">Ficha que se evaluará</param>
        /// <returns>True si se cumple la regla, false en caso contrario</returns>
        public override bool evaluar(Tablero tablero, Ficha ficha){
            //Se recorre el tablero buscando una casilla vacía
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    //Si la casilla está vacía
                    if(tablero.casillas[i, j] == null)
                        //No se cumple la regla
                        return false;
                }
            }
            //Se cumple la regla
            return true;
        }
    }   
}

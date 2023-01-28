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
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    if(tablero.casillas[i, j] != null){                        
                        if(j + numeroFichas <= tablero.casillas.GetLength(1)){
                            int contador = 0;
                            for(int k = j; k < j + numeroFichas; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i, k])
                                    contador++;                                
                            }
                            if(numeroFichas == contador)
                                if(tablero.casillas[i, j] == ficha)
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
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    if(tablero.casillas[i, j] != null){                        
                        if(i + numeroFichas <= tablero.casillas.GetLength(0)){
                            int contador = 0;
                            for(int k = i; k < i + numeroFichas; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[k, j]){
                                    contador++;
                                }
                            }
                            if(numeroFichas == contador)
                                if(tablero.casillas[i, j] == ficha)
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
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    if(tablero.casillas[i, j] != null){    
                        if(i + numeroFichas <= tablero.casillas.GetLength(0) && j + numeroFichas <= tablero.casillas.GetLength(1)){
                            int contador = 0;
                            for(int k = 0; k < numeroFichas; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i + k, j + k]){
                                    contador++;
                                }
                            }
                             if(numeroFichas == contador)
                                if(tablero.casillas[i, j] == ficha)
                                    return true;
                        }
                        if((i + numeroFichas) <= tablero.casillas.GetLength(0) && (j - numeroFichas + 1) >= 0){
                            int contador = 0;
                            for(int k = 0; k < numeroFichas; k++){
                                if(tablero.casillas[i, j] == tablero.casillas[i + k, j - k]){       
                                    contador++;
                                }
                            }
                             if(numeroFichas == contador)
                                if(tablero.casillas[i, j] == ficha)
                                    return true;
                        }
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// Clase para la representación de la regla para verificar si hay un ganador
    /// </summary>
    public class ReglaGanador: ReglaAbstract{
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
        /// Constructor de la clase regla ganador
        /// </summary>
        /// <param name="numeroFichas">Número de fichas que se deben colocar en línea para ganar</param>
        public ReglaGanador(int numeroFichas){
            this.numeroFichas = numeroFichas;
        }

        /// <summary>
        /// Método para evaluar la regla
        /// </summary>
        /// <param name="tablero">Tablero donde se evaluará la regla</param>
        /// <param name="ficha">Ficha que se evaluará</param>
        /// <returns>True si se cumple la regla, false en caso contrario</returns>
        public override bool evaluar(Tablero tablero, Ficha ficha){
            ReglaHorizontal reglaHorizontal = new ReglaHorizontal(numeroFichas);
            ReglaVertical reglaVertical = new ReglaVertical(numeroFichas);
            ReglaDiagonal reglaDiagonal = new ReglaDiagonal(numeroFichas);
            Console.WriteLine("Regla horizontal: " + reglaHorizontal.evaluar(tablero, ficha));
            Console.WriteLine("Regla vertical: " + reglaVertical.evaluar(tablero, ficha));
            Console.WriteLine("Regla diagonal: " + reglaDiagonal.evaluar(tablero, ficha));
            Console.ReadKey();
            if(reglaHorizontal.evaluar(tablero, ficha) || reglaVertical.evaluar(tablero, ficha) || reglaDiagonal.evaluar(tablero, ficha))
                return true;
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
            for(int i = 0; i < tablero.casillas.GetLength(0); i++){
                for(int j = 0; j < tablero.casillas.GetLength(1); j++){
                    if(tablero.casillas[i, j] == null)
                        return false;
                }
            }
            return true;
        }
    }
}

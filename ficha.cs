//-Importaciones:
using System;
//-Contenido:
namespace Gato_4enLinea{    
    /// <summary>
    /// Clase Ficha
    /// </summary>
    public class Ficha{
        /// <summary>
        /// Almacenamiento del caracter de la ficha
        /// </summary>        
        private char _figura = ' ';
        /// <summary>
        /// Almacenamiento del color de la ficha
        /// </summary>      
        private ConsoleColor _color = new ConsoleColor();    

        /// <summary>
        /// Constructor de la clase Ficha
        /// </summary>
        /// <param name="figura">Figura que de la ficha</param>
        /// <param name="color">Color de la ficha</param>
        public Ficha(char figura, ConsoleColor color)
        {
            this.figura = figura;
            this.color = color;
        }

        /// <summary>
        /// Imprime la ficha
        /// </summary>        
        public void imprimir()
        {
            Console.ForegroundColor = this.color;
            Console.Write(figura);
        }

        /// <summary>
        /// Carácter de la ficha
        /// </summary>
        public char figura
        {
            get { return _figura; }
            set { _figura = value; }
        }

        /// <summary>
        /// Color de la ficha
        /// </summary>
        public ConsoleColor color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
   
}
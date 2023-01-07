/* ---------- Ayuda!! ----------
*    Clase Ficha
*   Se modela el objeto Ficha con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
//-Contenido:
namespace Gato_4enLinea{    
    public class Ficha{
        /// <summary>
        /// Atributos de la clase Ficha
        /// </summary>        
        private char _figura = ' ';
        private ConsoleColor _color = new ConsoleColor();    

        /// <summary>
        /// Constructor de la clase Ficha vacia
        /// </summary>
        public Ficha()
        {
        }   

        /// <summary>
        /// Constructor de la clase Ficha
        /// </summary>
        /// <param name="figura">Figura que representa al jugador</param>
        /// <param name="color">Color de la figura del jugador</param>
        public Ficha(char figura, ConsoleColor color)
        {
            this.figura = figura;
            this.color = color;
        }

        /// <summary>
        /// Método para colocar la ficha en el tablero
        /// </summary>        
        public void colocar()
        {
            Console.ForegroundColor = this.color;
            Console.Write(figura);
        }

        /// <summary>
        /// Propiedades de la clase Ficha
        /// </summary>
        public char figura
        {
            get { return _figura; }
            set { _figura = value; }
        }
        public ConsoleColor color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
   
}
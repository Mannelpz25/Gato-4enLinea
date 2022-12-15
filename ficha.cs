/* ---------- Ayuda!! ----------
*    Clase Ficha
*   Se modela el objeto Ficha con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
//-Contenido:
namespace ficha{    
    public class Ficha{
        private char figura { get; set; }
        private ConsoleColor color { get; set; }
        public Ficha()
        {
            
        }
        public Ficha(char figura, ConsoleColor color)
        {
            this.figura = figura;
            this.color = color;
        }

        public char getFigura()
        {
            return this.figura;
        }
        public void colocar()
        {
            Console.ForegroundColor = this.color;
            Console.Write(figura);
        }
    }
   
}
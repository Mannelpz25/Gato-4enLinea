/* ---------- Ayuda!! ----------
*    Clase Jugador
*   Se modela el objeto Jugador con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
using ficha;
//-Contenido:

namespace jugador{    
    public class Jugador{
        private String nombre { get; set; }
        private Ficha ficha { get; set; }
        public Jugador(String nombre, char figura, ConsoleColor color) 
        {            
            this.nombre = nombre;            
            this.ficha = new Ficha(figura, color);
        }
        public Ficha colocarFicha()
        {
            return this.ficha;
        }
        public String getNombre()
        {
            return this.nombre;
        }
    }   
}
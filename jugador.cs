/* ---------- Ayuda!! ----------
*    Clase Jugador
*   Se modela el objeto Jugador con sus métodos para manipulación del mismo
*/
//-Importaciones:
using System;
//-Contenido:

namespace Gato_4enLinea{    
    public class Jugador{

        /// <summary>
        /// Atributos de la clase Jugador
        /// </summary>        
        private String _nombre = "";
        private Ficha _ficha = new Ficha();
        
        /// <summary>
        /// Constructor de la clase Jugador
        /// </summary>
        /// <param name="nombre">Nombre del jugador</param>
        /// <param name="figura">Figura que representa al jugador</param>
        /// <param name="color">Color de la figura del jugador</param>

        public Jugador(String nombre, char figura, ConsoleColor color) 
        {            
            this.nombre = nombre;            
            this.ficha = new Ficha(figura, color);
        }

        /// <summary>
        /// Propiedades de la clase Jugador
        /// </summary>
        public String nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public Ficha ficha
        {
            get { return _ficha; }
            set { _ficha = value; }
        }
    }   
}
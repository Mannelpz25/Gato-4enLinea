//-Importaciones:
using System;
//-Contenido:

namespace Gato_4enLinea{    
    /// <summary>
    /// Clase Jugador
    /// </summary>
    public class Jugador{

        /// <summary>
        /// Almacenamiento del nombre del jugador
        /// </summary>        
        private String _nombre = "";
        /// <summary>
        /// Almacenamiento de la ficha del jugador
        /// </summary>     
        private Ficha _ficha;
        
        /// <summary>
        /// Constructor de la clase Jugador
        /// </summary>
        /// <param name="nombre">Nombre del jugador</param>
        /// <param name="figura">Figura de la ficha</param>
        /// <param name="color">Color de la ficha</param>

        public Jugador(String nombre, char figura, ConsoleColor color) 
        {            
            this.nombre = nombre;            
            this.ficha = new Ficha(figura, color);
        }

        /// <summary>
        /// Nombre del jugador
        /// </summary>
        public String nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        /// <summary>
        /// Ficha del jugador
        /// </summary>
        public Ficha ficha
        {
            get { return _ficha; }
            set { _ficha = value; }
        }
    }   
}
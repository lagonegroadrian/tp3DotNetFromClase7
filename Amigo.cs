using System;
using System.Collections.Generic;
using System.Text;

namespace Clase7
{
    public class Amigo
    {
        public int idAmigo { get; set; }
       
        public string nombre { get; set; }
        public string apellido { get; set; }
       

        public Amigo() { }
        public Amigo(string _nombre, string _apellido)
        {
            
            
            this.nombre = _nombre;
            this.apellido = _apellido;
          
        }
     }
}

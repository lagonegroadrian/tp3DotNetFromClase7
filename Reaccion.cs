using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase7
{
    public class Reaccion
    {
        public int id { get; set; }
        public String tipo { get; set; }

        public Post post { get; set; }

        public Usuario usuario { get; set; }

        private static int ultimoValor = 1;

        public int Comentarioid { get; set; }
        public Comentario Comentario { get; set; }


        public Reaccion() { }

        public Reaccion(String tipo, Post post, Usuario usuario)
        {
            this.id = Contador();
            this.tipo = tipo;
            this.post = post;
            this.usuario = usuario;

        }

        public int Contador() { return ultimoValor++; }

    }
}

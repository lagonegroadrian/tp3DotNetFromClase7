using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase7
{
    public class Post
    {
        // •	El Post contiene una lista de reacciones pero cada Reacción
        // corresponde a un único Usuario y Post. En este caso,
        // el usuario solo puede reaccionar una vez al Post.

        // •	El Post contiene una lista de comentarios pero cada Comentario
        // corresponde a un único Usuario y Post.A diferencia del punto anterior,
        // el usuario puede comentar tantas veces como guste, si realiza distintos comentarios,
        // estos tendrán distintos IDs.

        // •	El Post puede tener muchos Tags pero un Tag puede estar en varios Posts,
        // esta es una relación de tipo muchos a muchos.

        public int idPost { get; set; }
        public Usuario usuario { get; set; }
        public int idUsuario { get; set; }
        public String contenido { get; set; }

        public List<Comentario> comentarios;
        public List<Reaccion> reacciones;
        public List<Tag> tags;

        public DateTime fecha { get; set; }

        private static int ultimoValor = 1;
        public Post(int id, Usuario usuario, String contenido, DateTime fecha)
        {
            this.idPost = id;
            this.usuario = usuario;
            this.contenido = contenido;
            this.comentarios = new List<Comentario>();
            this.reacciones = new List<Reaccion>();
            this.tags = new List<Tag>();

            this.fecha = fecha;
        }

        public string[] toArray()
        {
            return new string[] { idPost.ToString(), contenido, comentarios.Count.ToString(), reacciones.Count.ToString()};
        }

        public int Contador() { return ultimoValor++; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase7
{
    public class Comentario
    {
        public int id { get; set; }
        public Post post { get; set; }
        public int idPost { get; set; }
        public Usuario usuario { get; set; }
        public int idUsuario { get; set; }

        public String contenido { get; set; }

        public DateTime fecha { get; set; }

        public List<Usuario> usuarios;

        public Comentario() { }

        private static int ultimoValor = 1;
        public Comentario(Post post, Usuario usuario, String contenido, DateTime fecha)
        {
            this.id = Contador();
            this.post = post;
            this.usuario = usuario;
            this.contenido = contenido;
            this.fecha = fecha;
            this.usuarios = new List<Usuario>();
        }

        public int Contador() { return ultimoValor++; }

    }
}

/*
   //AMB de comentarios
public void Comentar(Comentario _comentario)
{
    try
    {
        usuarios.Add(_comentario);
        return true;
    }
    catch (Exception)
    {
        return false;
    }
}

public void ModificarComentario(Comentario _comentario) 
{

}
public void QuitarComentario(Comentario _comentario) 
{

}
}
*/
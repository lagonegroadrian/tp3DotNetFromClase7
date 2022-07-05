using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; //para no tener que usar referencias usamos también este
//así no tienes que estar colocando   el "namespace"

namespace Clase7
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public bool esADM { get; set; }
        public virtual ICollection<UsuarioAmigo> misAmigos { get; set; }
        public virtual ICollection<UsuarioAmigo> amigosMios { get; set; }

        public List<Usuario> amigos;

        public List<Post> posts;
        public List<Comentario> comentarios;
        public List<Reaccion> reacciones;

        private static int ultimoValor = 1;

        public Usuario() { } //constuctor vació que necesita EF para funcionar

        //public Usuario(int _dni, String _nombre, String _apellido, String _mail, String _password)
        public Usuario(int _dni, string _nombre, string _apellido, string _mail, string _password, bool _bloqueado, bool esADM)
        {
            //this.id = Contador();
            this.dni = _dni;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.mail = _mail;
            this.password = _password;
            this.intentosFallidos = 0;
            this.bloqueado = _bloqueado;
            this.esADM = esADM;
            posts = new List<Post>();
            comentarios = new List<Comentario>();
            reacciones = new List<Reaccion>();
        }

        public void addFriend(Usuario user)
        {
            //this.amigos.Add(user);
            amigos.Add(user);
        }

        public int Contador() { return ultimoValor++; }

        public List<List<String>> amigosString()
        {
            List<List<String>> amigos2 = new List<List<String>>();

            foreach (Usuario u in this.amigos)
            {
                List<String> amigo = new List<String>(new String[] { u.nombre, u.apellido, u.mail, u.dni.ToString()});
                amigos2.Add(amigo);
            }

            return amigos2;
        }

        

            public List<List<String>> postsString()
        {
            List<List<String>> posts2 = new List<List<String>>();

            foreach (Post p in posts)
            {
                List<String> post = new List<String>(new String[] { p.idPost.ToString(), p.contenido, p.comentarios.ToString(), p.reacciones.ToString() });
                posts2.Add(post);
            }

            return posts2;
        }

        public List<List<String>> postsStringAmigos()
        {
            List<List<String>> posts3 = new List<List<String>>();

            foreach (Usuario a in amigos)
            {
                foreach (Post p in a.posts)
                {
                    List<String> post = new List<String>(new String[] { p.idPost.ToString(), p.contenido, p.comentarios.ToString(), p.reacciones.ToString() });
                    posts3.Add(post);
                }

            }

            return posts3;
        }

        public override string ToString()
        {
            return
                idUsuario + ";" +
                dni + ";" +
                nombre + ";" +
                apellido + ";" +
                mail + ";" +
                password + ";" +
                intentosFallidos + ";" +
                bloqueado;
        }

        // •	Un Usuario tiene una lista con 0 o más Posts mientras
        // que el Post corresponde a un único usuario.
    }
}

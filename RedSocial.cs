using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Reflection.Metadata.Ecma335;

namespace Clase7
{
    public class RedSocial
    {
        private MyContext contexto;
        private DbSet<Usuario> misUsuarios;
        private int idLogueado;
        public RedSocial()
        {
            inicializarAtributos();
            idLogueado = -1;
        }

        private void inicializarAtributos()
        {
            try
            {
                //creo un contexto
                contexto = new MyContext();
                //cargo los usuarios
                //falta reacciones en el include y amigos de usuarios
                contexto.usuarios.Load();
                misUsuarios = contexto.usuarios;
                contexto.usuarios.Include(u => u.posts).Include(u => u.comentarios).Load();
                contexto.posts.Load();
                contexto.comentarios.Load();
               
            }
            catch (Exception)
            {

            }
        }
        public Usuario obtenerUsuario(int idUser)
        {
            return contexto.usuarios.Where(U => U.idUsuario == idUser).FirstOrDefault();
        }
        public List<Usuario> obtenerUsuarios()
        {
            return contexto.usuarios.ToList();
        }
        
        public List<Usuario> usuariosAdministradores()
        {
            var query = from Usuario in contexto.usuarios
                        where Usuario.esADM == true
                        select Usuario;
            return query.ToList();
        }

        public bool agregarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            try
            {
                Usuario nuevo = new Usuario { dni = Dni, nombre = Nombre, mail = Mail, password = Password, bloqueado = Bloqueado, esADM = EsADM };
                contexto.usuarios.Add(nuevo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarUsuario(int id)
        {
            try
            {
                Usuario usuarioElim = contexto.usuarios.Where(u =>u.idUsuario==id).FirstOrDefault();
                if (usuarioElim != null)
                {
                    contexto.Remove(usuarioElim);
                    contexto.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool modificarUsuario(int id, int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            bool salida = false;
            foreach (Usuario u in contexto.usuarios)
                if (u.idUsuario==id)
                {
                    u.nombre = Nombre;
                    u.mail = Mail;
                    u.password = Password;
                    u.esADM = EsADM;
                    u.bloqueado = Bloqueado;
                    contexto.usuarios.Update(u);
                    salida = true;
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
        }

        public int getIdLogueado()
        {
            return this.idLogueado;
        }

        public List<Post> obternerPostsUsuario(int id)
        {
            return contexto.usuarios.Where(u => u.idUsuario == id).FirstOrDefault().posts;
        }

        public List<Post> obternerPostsAmigos(int id)
        {
            List<Post> salida = new List<Post>();
            Usuario ElUser = contexto.usuarios.Where(u => u.idUsuario == id).FirstOrDefault();
            foreach(Usuario amigo in ElUser.amigos)
            {
               salida.AddRange(amigo.posts);
            }
            return salida;
        }

        public Usuario loginUsuario(int dni, string Contraseña)
        {
            Usuario Aux = contexto.usuarios.Where(u => u.dni == dni).FirstOrDefault();
            if (Aux != null)
            {
                if(Aux.password.Equals(Contraseña))
                {
                    Aux.intentosFallidos = 0;
                    contexto.usuarios.Update(Aux);
                    contexto.SaveChanges();
                    idLogueado = Aux.idUsuario;
                    return Aux;
                }
                else
                {
                    Aux.intentosFallidos = Aux.intentosFallidos+1;
                    if (Aux.intentosFallidos == 3)
                        Aux.bloqueado = true;
                    contexto.usuarios.Update(Aux);
                    contexto.SaveChanges();
                    return null;
                }
            }
            return null;
        }

        public void cerrar()
        {
            contexto.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Clase7
{
    public partial class RedSocialIni : Form
    {
        public delegate void opcion(int opcion); // desde el metodo delegado --> opcionClickeada de form1
        public opcion opcionClickeada;

        public delegate bool cargarAmigos();
        public cargarAmigos cargarAmigoss;

        public Usuario usuarioLogueado;

        public delegate void initializeForm();
        public initializeForm volverAtras;

        public delegate bool agregarAmigo();
        public agregarAmigo addFriend;

        private RedSocial red;

        //public TransDelegado TransEvento;

        private int idUser;

        public RedSocialIni(RedSocial miRed)
        {
            InitializeComponent();

            red = miRed;
            idUser = miRed.getIdLogueado();
            inicializarGrids();
        }

        private void inicializarGrids()
        {
            dataGridView2.Rows.Clear();
            foreach(Post p in red.obternerPostsUsuario(idUser))
            {
                dataGridView2.Rows.Add(p.toArray());
            }
            dataGridView1.Rows.Clear();
            foreach (Post p in red.obternerPostsAmigos(idUser))
            {
                dataGridView1.Rows.Add(p.toArray());
            }
        }

        private void UsuarioActual_Click(object sender, EventArgs e)
        {

        }

        private void llenarDatosDataGrid(List<List<String>> amigos)
        {
            dataGridViewAmigos.Rows.Clear();

            foreach (List<String> a in amigos){dataGridViewAmigos.Rows.Add(a.ToArray());}

        }

        private void llenarDatosDataGridPosts(List<List<String>> posts)
        {
            dataGridView2.Rows.Clear();

            foreach (List<String> p in posts)
            {
                dataGridView2.Rows.Add(p.ToArray());
            }

        }

        private void llenarDatosDataGridPostsAmigos(List<List<String>> posts)
        {
            dataGridView1.Rows.Clear();

            foreach (List<String> p in posts)
            {
                dataGridView1.Rows.Add(p.ToArray());
            }

        }
        /* se muda esta logica en el load del form (this form)
        private void button1_Click(object sender, EventArgs e) // boton accion
        {
            usuarioLogueado = this.TransEvento();

            this.UsuarioActual.Text = " traer el dato del login";//usuarioLogueado.nombre + " , " + usuarioLogueado.apellido;

            llenarDatosDataGrid(usuarioLogueado.amigosString());
            llenarDatosDataGridPosts(usuarioLogueado.postsString());
            llenarDatosDataGridPostsAmigos(usuarioLogueado.postsStringAmigos());

            //dataGridView2.Rows.Clear();
            // foreach (List<string> Post in usuarios.obtenerUsuarios())
            //{ dataGridView2.Rows.Add(usuario.ToArray()); }
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Application.Restart();
                this.volverAtras();
            }
        }

        private void addFriend_btn_Click(object sender, EventArgs e)
        {
            this.opcionClickeada(4);

            /*
            string input = Interaction.InputBox("Prompt", "Agregar amigo");
            MessageBox.Show(input);
            try
            {
                int dni = Int32.Parse(input);
                //RedSocial.agregarAmigo(dni) - pasar metodo de la class redsocial
                if (true)
                {
                    MessageBox.Show(dni.ToString());
                    MessageBox.Show("Usuario agregado a tu lista de amigos");
                }
                else
                {
                    MessageBox.Show("No existe el usuario indicado");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Indicar un número de documento válido");
            }
            */
        }


        public delegate Usuario TransDelegado();

        private void button2_Click(object sender, EventArgs e)
        {
            this.volverAtras();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public List<List<String>> formateaListAmigosUsuario(List<Usuario> _listaAmigos)
        {
            List<List<String>> aux = new List<List<String>>();

            foreach (Usuario u in _listaAmigos)
            {
                List<String> acu = new List<String>(new String[] { u.idUsuario.ToString(), u.nombre, u.apellido, u.mail, u.dni.ToString() });
                aux.Add(acu);
            }
            return aux;
        }

        public List<List<String>> formateaListPostUsuario(List<Post> _listaPost)
        {
            List<List<String>> aux = new List<List<String>>();

            foreach (Post p in _listaPost)
            {
                //List<Comentario> comentarios = managerComentario.traerComentariosPorPost(p.id);
                //List<String> acu = new List<String>(new String[] { p.id.ToString(), p.usuario.mail, p.contenido, comentarios.Count().ToString(), p.fecha.ToString() });
                //aux.Add(acu);
            }
            return aux;
        }

        private void RedSocialIni_Load(object sender, EventArgs e)
        {
            //usuarioLogueado = managerUsuarios.traeUsuarioConId(idUser);

            //List<Usuario> amigoDeUsuario = managerUsuarios.traeAmigosDeUsuarioConId(idUser);
            //Usuario amigoDeUsuario = managerUsuarios.traeAmigosDeUsuarioConId(idUser);
            //List<Usuario> amigoDeUsuario = managerUsuarios.traeAmigosDeUsuarioConId(idUser);
            //List<Post> postDeUsuario = managerPosts.traerPostsPorUsuario(idUser);
            //formateaListAmigosUsuario(amigoDeUsuario);
            //usuarioLogueado = this.TransEvento();


            this.UsuarioActual.Text = usuarioLogueado.nombre + " , " + usuarioLogueado.apellido + " (" + usuarioLogueado.idUsuario + ")";

            //llenarDatosDataGrid(formateaListAmigosUsuario(amigoDeUsuario));
            //llenarDatosDataGrid(usuarioLogueado.amigosString());
            //llenarDatosDataGridPosts(formateaListPostUsuario(postDeUsuario));
            //llenarDatosDataGridPostsAmigos(usuarioLogueado.postsStringAmigos());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.opcionClickeada(5);
        }

        private void dataGridViewAmigos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

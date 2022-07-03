using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase7
{
    public partial class AddPost : Form
    {
        public delegate void opcion(int opcion); // desde el metodo delegado --> opcionClickeada de form1
        public opcion opcionClickeada;
        public RedSocial redSocial;
        public delegate void initializeForm();
        public initializeForm volverAtras;
        public List<Post> postUsuario;

        public int idUser;
        public int idPost;
        
        public AddPost(int idUserLogeado)
        {
            InitializeComponent();
            idUser = idUserLogeado;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            /*
            if (managerPost.agregarPost(idUser, richTextBox1.Text) == 1)
            {
                MessageBox.Show("Has agregado un Post");
                accionDentroDeLoad();
            }
            else
            {
                MessageBox.Show("No se puedo guardar el Post");
            }
            */
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void llenarDatosDataGrid(List<List<String>> posteos)
        {
            dataGridView1.Rows.Clear();

            foreach (List<String> a in posteos)
            {
                dataGridView1.Rows.Add(a.ToArray());
            }

        }

        public void accionDentroDeLoad()
        {
           
            llenarDatosDataGrid(formateaListPostUsuario(postUsuario));
        }


        private void AddPost_Load(object sender, EventArgs e)
        {
            accionDentroDeLoad();
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idPost = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            richTextBox1.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            richTextBox2.Visible = true;
            button4.Visible = true;
        }

        public List<List<String>> formateaListPostUsuario(List<Post> _listaPost)
        {
            List<List<String>> aux = new List<List<String>>();

            foreach (Post p in _listaPost)
            {
                //List<Comentario> comentarios = managerComentario.traerComentariosPorPost(p.idPost);
                //List<String> acu = new List<String>(new String[] { p.idPost.ToString(), p.usuario.mail, p.contenido, comentarios.Count().ToString(), p.fecha.ToString() });
                //aux.Add(acu);
            }
            return aux;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class AddAmigo : Form
    {
        public delegate void opcion(int opcion); // desde el metodo delegado --> opcionClickeada de form1
        public opcion opcionClickeada;
        public RedSocial redSocial;
        public delegate void initializeForm();
        public initializeForm volverAtras;
        
        public Usuario usuarioLogueado;

        private List<Usuario> amigoDeUsuario = new List<Usuario>();
        private List<Usuario> todosLosUsuario = new List<Usuario>();


        public int idUser;
        //public AddAmigo(RedSocial _redSocial)
        public AddAmigo(int idUserLogeado)
        {
            InitializeComponent();
            //redSocial = _redSocial;
            idUser = idUserLogeado;
           

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //no te olvides de validar que para agregar esté todito completo
            
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public List<List<String>> formateaListAmigosUsuario(List<Usuario> _listaAmigos)
        {
            List<List<String>> aux = new List<List<String>>();

            foreach (Usuario u in _listaAmigos)
            {
                List<String> acu = new List<String>(new String[] { u.idUsuario.ToString(), u.nombre, u.apellido, u.mail, u.dni.ToString() , esAmigacho(u)});
                aux.Add(acu);
            }
            return aux;
        }


        private void llenarDatosDataGrid(List<List<String>> amigos)
        {
            dataGridViewAmigos.Rows.Clear();

            foreach (List<String> a in amigos)
            {
                dataGridViewAmigos.Rows.Add(a.ToArray());
            }

        }

        public void accionDentroDeLoad() 
        {
            //usuarioLogueado = managerUsuarios.traeUsuarioConId(idUser);
            //amigoDeUsuario = managerUsuarios.traeAmigosDeUsuarioConId(idUser);
            //todosLosUsuario = managerUsuarios.obtenerUsuarios();

            llenarDatosDataGrid(formateaListAmigosUsuario(todosLosUsuario));
        }

        private void AddAmigo_Load(object sender, EventArgs e)
        {
            accionDentroDeLoad();
        }
        
        private string esAmigacho(Usuario _usuario)
        {
            string aux = "No";

            foreach (Usuario u in amigoDeUsuario)
            {                
               if(_usuario.idUsuario == u.idUsuario) { aux="Si"; }
            }
            return aux;
        }

        private string esAmigacho(int _idUsuario)
        {           
            string aux = "No";

            foreach (Usuario u in amigoDeUsuario)
            {
                if (u.idUsuario == _idUsuario) { aux = "Si"; }
            }
            return aux;
        }

        private void dataGridViewAmigos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridViewAmigos[1, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridViewAmigos[2, e.RowIndex].Value.ToString();
            textBox3.Text = dataGridViewAmigos[0, e.RowIndex].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //nombre
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //apellido
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //id
        }

        private void button2_Click(object sender, EventArgs e)
        {

     
        }
    }
}

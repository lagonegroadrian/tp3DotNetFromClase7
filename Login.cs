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
    public partial class Login : Form
    {
        public delegate void opcion(int opcion); // desde el metodo delegado --> opcionClickeada de form1
        public opcion opcionClickeada;

        public delegate void opcionUserActual(int idUser); // con este metodo delegado le informo a form1 el Id de usuario
        public opcionUserActual userActual;

        public delegate bool ingresarClickeado(int user, string Password);
        public ingresarClickeado IniciarSesion;

        public delegate Usuario elUsuarioLogueado(Usuario _user);
        public elUsuarioLogueado elUsuarioLogueadoOut;
        private RedSocial redSocial;
        //private int intentosFallidos;

        public Login(RedSocial redSocial)
        {
            InitializeComponent();
            this.redSocial = redSocial;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Ingresar_Click(object sender, EventArgs e)
        {
            int user;
            int.TryParse(textBox1.Text, out user);
            string Contraseña = textBox2.Text;

            //bool logueado = this.IniciarSesion(user, Contraseña);               

            Usuario auxUser = redSocial.loginUsuario(user, Contraseña);
            if (auxUser!=null)
            {
                MessageBox.Show("BienVenido " + auxUser.nombre + " !");
                this.userActual(auxUser.idUsuario);
                this.opcionClickeada(3);// ver la redSocial propiamente dicha
                this.Close();
            }
            else
            {
                MessageBox.Show("contraseña incorrecto");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.opcionClickeada(2);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
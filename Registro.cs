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
    public partial class Registro : Form
    {
        public delegate bool registroClick(int DNI, string Nombre, string Apellido, string Mail, string Password);
        public registroClick registroClickeado;

        public delegate void initializeForm();
        public initializeForm volverAtras;

     

        public Registro()
        {
            InitializeComponent();
            
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int DNI;
            int.TryParse(textBox1.Text, out DNI);
            string Nombre = textBox2.Text;
            string Apellido = textBox3.Text;
            string Mail = textBox4.Text;
            string Contraseña = textBox5.Text;
            //bool mailEsValido = IsValidEmail(Mail);

            /*
            MessageBox.Show(" x--> dni " + DNI);
            MessageBox.Show(" x---> nombre " + Nombre);
            MessageBox.Show(" x--> apellido " + Apellido);
            MessageBox.Show(" x---> Mail " + Mail);
            MessageBox.Show(" x----> contraseña " + Contraseña);
            */
            MessageBox.Show("Sus datos son: " + "\n"
                            + "\nDNI:   " + "\n       " + DNI + "\n"
                            + "\nNombre:   " + "\n       " + Nombre + "\n"
                            + "\nApellido:   " + "\n       " + Apellido + "\n"
                            + "\nMail:   " + "\n       " + Mail + "\n"
                            + "\nConstraseña:   " + "\n       " + Contraseña); 



            //managerUsuario es el intermediario entre la Clase y la BD
            //MessageBox.Show(" ---> " + managerUsuarios.agregarUsuario(DNI, Nombre, Apellido, Mail, Contraseña, false));

            if (this.registroClickeado(DNI, Nombre, Apellido, Mail, Contraseña))
            {
                MessageBox.Show("El registro fue exitoso");
                //this.Close();
                this.volverAtras();
            }
            else { MessageBox.Show("El registro NO fue exitoso"); }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.volverAtras();
        }

    }
}
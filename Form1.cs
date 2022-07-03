using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase7
{
    public partial class Form1 : Form
    {
        // Formularios de login
        Login loginPage;
        Registro registerPage;
        RedSocialIni RedSocialPage;
        AddAmigo addAmigoPage;
        AddPost addPostPage;

        RedSocial redSocial = new RedSocial();

        int idUserLogeado;

        public Form1()
        {
            InitializeComponent();
            initializeLoginPage();
        }


        private void initializeLoginPage()
        {
            loginPage = new Login(redSocial);
            loginPage.MdiParent = this;
            loginPage.opcionClickeada += opcionClickeada;

            loginPage.userActual += opcionUserActual;

            //loginPage.elUsuarioLogueadoOut += elUsuarioLogueado;


            loginPage.Show();
        }

        private void opcionUserActual(int IdUsuer)
        {
            idUserLogeado = IdUsuer;
        }

        private void opcionClickeada(int opcionElegida)
        {
            switch (opcionElegida)
            {
                //* menuLogin
                case 1:
                    //loginPage.IniciarSesion += ingresarClickeado;
                    break;

                //* menuRegistro;
                case 2:
                    registerPage = new Registro();
                    registerPage.MdiParent = this;
                    registerPage.registroClickeado += registroClickeado;
                    registerPage.volverAtras += initializeLoginPage;
                    registerPage.Show();
                    break;

                //* menuRedSocial;
                case 3:
                    RedSocialPage = new RedSocialIni(redSocial);
                    RedSocialPage.MdiParent = this;
                    //RedSocialPage.cargarAmigoss += cargarAmigoss;
                    RedSocialPage.volverAtras += initializeLoginPage;
                    RedSocialPage.opcionClickeada += opcionClickeada;
                    //RedSocialPage.TransEvento += TransDelegado;
                    RedSocialPage.Show();
                    break;

                //* agregar Amigo
                case 4:
                    //addAmigoPage = new AddAmigo(redSocial);
                    addAmigoPage = new AddAmigo(idUserLogeado);
                    addAmigoPage.MdiParent = this;
                    addAmigoPage.volverAtras += initializeLoginPage;
                    addAmigoPage.Show();
                    break;

                //Post
                case 5:
                    addPostPage = new AddPost(idUserLogeado);
                    addPostPage.MdiParent = this;
                    //addPostPage.volverAtras += initializeLoginPage;
                    addPostPage.Show();
                    break;
                case 6:
                    //addAmigoPage = new AddAmigo(redSocial);
                    addAmigoPage = new AddAmigo(idUserLogeado);
                    addAmigoPage.MdiParent = this;
                    addAmigoPage.volverAtras += initializeLoginPage;
                    addAmigoPage.Show();
                    break;
            }
        }

        /* se saca la iteraccion con form1 respecto del usuario... x cada form consulto con el Id todo
        private Usuario TransDelegado()
        {
            return redSocial.usuarioActual;
        }
        */

        private void elUsuarioLogueado(Usuario _user)
        {
            //redSocial.usuarioActual = _user;
        }

        private bool registroClickeado(int _dni, string _nomb, string _apel, string _email, string _pass)
        {
            //Usuario _usuario = new Usuario(99, _dni, _nomb, _apel, _email, _pass , false); // no te olvides, de este chamu!
            //bool result = redSocial.RegistrarUsuario(_usuario);

            //MessageBox.Show(_usuario.ToString());

            //return result;
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

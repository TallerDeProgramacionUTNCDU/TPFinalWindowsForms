using Microsoft.Extensions.Hosting;
using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinalWindowsForms.DAL;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.Quartz;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.VisualBasic.Logging;

namespace TPFinalWindowsForms.Visual
{


    public partial class Login : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static DBContext context = new DBContext();
        RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
        public Login()
        { 
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repoUsuario.GetAll().ToList() ;
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length == 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar un usuario";
            }
            else if (txtPass.Text.Length == 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar una contraseña";
            }
            else
            {
                try
                {
                    var objetoUsuario = repoUsuario.Get(txtUsuario.Text);
                    if (objetoUsuario.Nickname == txtUsuario.Text && objetoUsuario.Contraseña == txtPass.Text)
                    {
                        log.Info("Login Exitoso");
                        Hide();                        
                        PantallaPrincipal pantallPrincipal = new PantallaPrincipal();
                        Program.usuarioLogueado = objetoUsuario.Nickname;
                        pantallPrincipal.ShowDialog();                                             
                    }
                    else
                    {
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = "Debe ingresar un usuario y contraseñas correctos";
                        log.Error("Usuario o contraseña invalidos");

                    }
                }
                catch (NullReferenceException excepcion)  {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Debe ingresar un usuario y contraseñas correctos";
                    log.Error("No existe el usuario");
                }

            }
            txtUsuario.Text = "";
            txtPass.Text = "";
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Signup registro = new Signup();
            registro.ShowDialog();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

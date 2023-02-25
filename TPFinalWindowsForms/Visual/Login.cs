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
using System.Runtime.InteropServices;
using log4net;
using TPFinalWindowsForms.Visual;
using TPFinalWindowsForms;

namespace TPFinalWindowsForms.Visual
{


    public partial class Login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        Fachada fachada = new Fachada();
        public Login()
        { 
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = repoUsuario.GetAll().ToList() ;
            lblMensaje.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }


private void btnSignup_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            if (WindowState== FormWindowState.Normal) 
            {
                pboxMinimizarVentana.Image = TPFinalWindowsForms.Properties.Resources.maximizar;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                pboxMinimizarVentana.Image = TPFinalWindowsForms.Properties.Resources.minimizar;
                MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                pboxMinimizarVentana.Image = TPFinalWindowsForms.Properties.Resources.maximizar;
                WindowState = FormWindowState.Normal;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void Acceder()
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
                    var objetoUsuario = fachada.GetUser(txtUsuario.Text);
                    if (objetoUsuario.Nickname == txtUsuario.Text && objetoUsuario.Contraseña == txtPass.Text)
                    {
                        log.Info("Login Exitoso");
                        Hide();
                        Fachada.ActivarSesion(objetoUsuario.Nickname);
                        PantallaPrincipal pantallPrincipal = new PantallaPrincipal();
                        pantallPrincipal.ShowDialog();
                    }
                    else
                    {
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = "Debe ingresar un usuario y contraseñas correctos";
                        log.Error("Usuario o contraseña invalidos");

                    }
                }
                catch (NullReferenceException excepcion)
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Debe ingresar un usuario y contraseñas correctos";
                    log.Error("No existe el usuario");
                }

            }
            txtUsuario.Text = "";
            txtPass.Text = "";
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Acceder();          
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Signup registro = new Signup();
            registro.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Acceder();
            }
        }
    }
}

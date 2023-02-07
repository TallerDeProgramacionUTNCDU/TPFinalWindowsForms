using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinalWindowsForms.DAL;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.Domain;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.Logging;
using System.Runtime.InteropServices;

namespace TPFinalWindowsForms.Visual
{
    public partial class Signup : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        Utilidades utilidades = new Utilidades();   
        static DBContext context = new DBContext();
        RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
        Fachada fachada = new Fachada();
        public Signup()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repoUsuario.GetAll().ToList();
            lblMensaje.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pboxMinimizarVentana_Click(object sender, EventArgs e)
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

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNick.Text.Length == 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar un usuario";
            }
            else if (txtPass.Text.Length == 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar una contraseña";
            }
            else if (txtPass.Text != txtCheckPass.Text)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Las contraseñas no coinciden";
            }
            else if (txtNombre.Text.Length == 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar un nombre";
            }
            else if (txtApellido.Text.Length == 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar un apellido";
            }
            else if (txtEmail.Text.Length == 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar un email";
            }
            else if (!utilidades.IsValidEmail(txtEmail.Text))
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar un email VALIDO";
            }
            else if (txtEmail.Text != txtCheckMail.Text)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Los Email no coinciden";
            }
            else
            {
                if (repoUsuario.Get(txtNick.Text) != null)
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Este usuario ya existe";
                    Login.log.Error("El usuario ya existe");
                }
                else
                {
                    using (IUnitOfWork bUoW = new UnitOfWork(new DBContext()))
                    {
                        Usuario usuario = new Usuario
                        {
                            Nickname = txtNick.Text,
                            Contraseña = txtPass.Text,
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Email = txtEmail.Text,
                            Favcriptos = "",
                            Umbral = 0
                        };
                        bUoW.RepositorioUsuario.Add(usuario);
                        bUoW.Complete();
                        Login.log.Info("Registro Exitoso");
                        dataGridView1.DataSource = repoUsuario.GetAll().ToList();
                    }
                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = "Se agregó correctamente";
                    txtNick.Text = "";
                    txtPass.Text = "";
                    txtCheckPass.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtCheckMail.Text = "";
                }
            }
        }

        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            if (WindowState == FormWindowState.Normal)
            {
                pboxMinimizarVentana.Image = TPFinalWindowsForms.Properties.Resources.maximizar;
            }
        }
    }
}

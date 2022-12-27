using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinalWindowsForms.DAL.EntityFramework;

namespace TPFinalWindowsForms.Visual
{
    public partial class Perfil : Form
    {
        NumberFormatInfo provider = new NumberFormatInfo();
        Fachada fachada = new Fachada();
        public Perfil()
        {
            InitializeComponent();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            UsuarioManagerDBContext context = new UsuarioManagerDBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var usuario = repoUsuario.Get(Program.usuarioLogueado);
            txtShowNick.Text = usuario.Nickname;
            txtShowPass.Text = usuario.Contraseña;
            txtShowNombre.Text = usuario.Nombre;
            txtShowApellido.Text = usuario.Apellido;
            txtShowEmail.Text = usuario.Email;
            txtShowUmbral.Text = usuario.Umbral.ToString();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioManagerDBContext context = new UsuarioManagerDBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            provider.NumberGroupSeparator = ",";
            provider.NumberDecimalSeparator = ".";
            var usuario = repoUsuario.Get(Program.usuarioLogueado);
            if (txtPass.Text.Length==0 && txtPassControl.Text.Length==0 && txtNombre.Text.Length==0 && txtApellido.Text.Length == 0 && txtEmail.Text.Length == 0 && txtConfirmEmail.Text.Length == 0 && txtUmbral.Text.Length == 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar al menos un dato para guardar cambios";
            }
            else
            {
                bool cambio = false;
                if (txtPass.Text.Length > 0)
                {
                    if (txtPass.Text != txtPassControl.Text)
                    {
                        lblMensaje.Text = "Las contraseñas no coinciden";
                        lblMensaje.ForeColor = Color.Red;
                    }
                    else
                    {
                        cambio = true;
                        usuario.Contraseña = txtPass.Text;
                    }

                }              

                if (txtNombre.Text.Length > 0)
                {
                    usuario.Nombre = txtNombre.Text;
                    cambio = true;
                }
                if (txtApellido.Text.Length > 0)
                {
                    usuario.Apellido = txtApellido.Text;
                    cambio = true;
                }
                if (txtEmail.Text.Length > 0)
                {
                    if (txtEmail.Text != txtConfirmEmail.Text)
                    {
                        lblMensaje.Text = "Los email no coinciden";
                        lblMensaje.ForeColor = Color.Red;

                    }
                    else if (!fachada.IsValidEmail(txtEmail.Text))
                    {
                        lblMensaje.Text = "Debe ingresar un email VALIDO";
                        lblMensaje.ForeColor = Color.Red;
                    }
                    else
                    {
                        usuario.Email = txtEmail.Text;
                        cambio = true;
                    }
                }
               

                if (txtUmbral.Text.Length > 0)
                {
                    if (!double.TryParse(txtUmbral.Text, out _))
                    {
                        lblMensaje.Text = "El umbral debe ser un numero";
                        lblMensaje.ForeColor = Color.Red;

                    }
                    else
                    {
                        usuario.Umbral=double.Parse(txtUmbral.Text, provider);
                        cambio = true;
                    }
                    
                }
                if (cambio)
                {
                    lblMensaje.Text = "Datos actualizados correctamente";
                    lblMensaje.ForeColor = Color.Green;
                    txtShowNick.Text = usuario.Nickname;
                    txtShowPass.Text = usuario.Contraseña;
                    txtShowNombre.Text = usuario.Nombre;
                    txtShowApellido.Text = usuario.Apellido;
                    txtShowEmail.Text = usuario.Email;
                    txtShowUmbral.Text = usuario.Umbral.ToString();
                }                
                txtPass.Text = "";
                txtPassControl.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtConfirmEmail.Text = "";
                txtUmbral.Text = "";
                Login.log.Info("Datos del usuario Actualizados Exitosamente");
            }
            context.SaveChanges();
        }

        private void txtShowNick_Click(object sender, EventArgs e)
        {
        }
    }
}

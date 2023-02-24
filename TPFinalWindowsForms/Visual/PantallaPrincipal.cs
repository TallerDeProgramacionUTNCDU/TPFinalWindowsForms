using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinalWindowsForms.DAL;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ScottPlot;
using static ScottPlot.Plottable.PopulationPlot;
using System.Reflection.Emit;
using System.Windows.Forms.VisualStyles;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using TPFinalWindowsForms.Api.Exceptions;
using System.Runtime.InteropServices;
using TPFinalWindowsForms.Visual;

namespace TPFinalWindowsForms.Visual
{
    public partial class PantallaPrincipal : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;




        public static Usuario user { get; set; }



        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        Fachada fachada = new Fachada();
        NumberFormatInfo provider = new NumberFormatInfo();

        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            lblMensajeUmbral2.Text = "";
            lblMensaje.Text = "";
            Program.Alertas();
            //Carga de la tabla cryptos generales
            try
            {
                var respuesta = fachada.GetAllCryptoDTO();
                dgvCryptos.DataSource = respuesta;
                //CHART
                provider.NumberGroupSeparator = ",";
                provider.NumberDecimalSeparator = ".";
                var cryptosDTO = fachada.GetAllCryptoDTO(); //awijdiawjdiadwjdawidjiawjdiawd
                int i = 0;
                List<ScottPlot.Plottable.Bar> bars = new();
                foreach (var crypto in cryptosDTO)
                {
                    i++;
                    double value = double.Parse(crypto.PriceUSD, provider);

                    ScottPlot.Plottable.Bar bar = new()
                    {
                        Value = value,
                        Position = i,
                        FillColor = ScottPlot.Palette.Category10.GetColor(i),
                        Label = crypto.Name,
                        LineWidth = 4,
                        LineColor = ScottPlot.Palette.Category10.GetColor(i),
                    };
                    bars.Add(bar);
                }
                double[] positions = new double[i + 1];
                string[] vacio = new string[i + 1];
                int k = 0;
                foreach (var crypto in cryptosDTO)
                {
                    k++;
                    positions[k] = k;
                    vacio[k] = "";
                }
                formsPlot1.Plot.XTicks(positions, vacio);
                formsPlot1.Refresh();

                // Add the BarSeries to the plot
                formsPlot1.Plot.AddBarSeries(bars);
                formsPlot1.Plot.SetAxisLimitsY(0, 17500);
                formsPlot1.Plot.YLabel("Precio en USD");
                formsPlot1.Refresh();
                int j = 0;
                // Carga área de notificaciones
                var usuario = fachada.GetUsuarioActual();
                lblMensajeUmbral2.Text = "Umbral actual: " + String.Format("{0:0.0000}", usuario.Umbral + "%");
                void HandleTimer()
                {
                    j = 0;
                    listBoxNotificaciones.Items.Clear();
                    provider.NumberGroupSeparator = ",";
                    provider.NumberDecimalSeparator = ".";
                    var listaAlertas = fachada.GetAllAlerts();
                    while (j < listaAlertas.Count())
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            foreach (var alerta in listaAlertas)
                            {
                                listBoxNotificaciones.Items.Add((j + 1) + "- " + alerta.Fecha + " La cripto " + alerta.Idcripto + " cambio un " + String.Format("{0:0.0000}", alerta.Umbralalerta) + "%");
                                j++;
                            }
                            Login.log.Info("Alertas Mostradas");
                        }));
                    }
                }
                System.Timers.Timer timer = new(interval: 5000); //Está en milisegundos
                timer.Elapsed += (sender, e) => HandleTimer();
                timer.Start();
                Login.log.Info("Timer alertas área alertas iniciado");
                //Carga el umbral actual para mostrarselo al usuario
                lblMensajeUmbral.Text = "Umbral Actual: " + usuario.Umbral.ToString() + "%";
            }
            catch (ExcepcionesApi unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                Application.Exit();
            }
        }

        private void btnShowFavCryptos_Click(object sender, EventArgs e)
        {

        }

        private void btnShowCyrpto_Click(object sender, EventArgs e)
        {
        
        }

  

        private void btnDelFav_Click(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {


           

            }

        private void btnChangeUmbral_Click(object sender, EventArgs e)
        {


        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            //fachada.SendMail();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void txtCrypto_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        private void flowNotificaciones_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil();
            perfil.ShowDialog();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //fachada.SendMail();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Notificacion(e);
                notifAlerta.Visible = true;
            }
            base.OnClientSizeChanged(e);
        }

        protected void Notificacion (EventArgs e)
        {
            notifAlerta.ShowBalloonTip(0);
        }

        private void PantallaPrincipal_SizeChanged(object sender, EventArgs e)
        {            
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.log.Info("Saliendo de la aplicación");
            Application.Exit();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {            
            WindowState = FormWindowState.Minimized;
        }

        private void PantallaPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.log.Info("Saliendo de la aplicación");
            Application.Exit();
        }

        private void notifAlerta_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void notifAlerta_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
        }

        private void txtUmbral_TextChanged(object sender, EventArgs e)
        {
            lblMensajeUmbral2.Text = "";
        }

        private void btnAgregarCriptoFavoritos_Click(object sender, EventArgs e)
        {

            var respuesta = fachada.GetHystoryFrom(txtCrypto.Text.ToLower());

            if (txtCrypto.Text.Length == 0)
            {
                lblMensaje.Text = "Debe ingresar el id de una crypto";
                lblMensaje.ForeColor = Color.Red;
            }
            else if (respuesta.Count()==0)
            {
                lblMensaje.Text = "La crypto ingresada no se encuentra";
                lblMensaje.ForeColor = Color.Red;
            }
            else
            {
                var objetoUsuario = PantallaPrincipal.user;
                string favorita = txtCrypto.Text.ToLower();
                if (objetoUsuario.ExisteCripto(favorita) is false)
                {
                    fachada.AddFavCrypto(favorita); 
                    lblMensaje.Text = "La crypto fue agregada a favoritos";
                    lblMensaje.ForeColor = Color.Aqua;
                    Login.log.Info(txtCrypto.Text + " Añadida a favoritas");
                    var listaCryptosDTO = fachada.ObtenerListaFavoritas();
                    dgvCryptos.DataSource = listaCryptosDTO;
                }
                else
                {
                    lblMensaje.Text = "La crypto ya está entre las favoritas";
                    lblMensaje.ForeColor = Color.Red;
                    Login.log.Error("Crypto ya es una favorita");
                }

            }
        }

        private void btnMostrarFavoritas_Click(object sender, EventArgs e)
        {
            try
            {
                var listaCryptosDTO = fachada.ObtenerListaFavoritas();
                int i = 0;
                provider.NumberGroupSeparator = ",";
                provider.NumberDecimalSeparator = ".";
                double max = 0;
                if (listaCryptosDTO.Count() > 0)
                {
                    dgvCryptos.DataSource = listaCryptosDTO;
                    List<ScottPlot.Plottable.Bar> bars = new();
                    formsPlot1.Plot.Clear();
                    foreach (var crypto in listaCryptosDTO)
                    {
                        i++;

                        double value = double.Parse(crypto.PriceUSD, provider);
                        if (value > max)
                        {
                            max = value;
                        }
                        ScottPlot.Plottable.Bar bar = new()
                        {
                            Value = value,
                            Position = i,
                            FillColor = ScottPlot.Palette.Category10.GetColor(i),
                            Label = crypto.Name,
                            LineWidth = 4,
                            LineColor = ScottPlot.Palette.Category10.GetColor(i),

                        };
                        bars.Add(bar);
                    }
                    double[] positions = new double[i + 1];
                    string[] vacio = new string[i + 1];
                    int j = 0;
                    foreach (var crypto in listaCryptosDTO)
                    {
                        j++;
                        positions[j] = j;
                        vacio[j] = "";
                    }
                    formsPlot1.Plot.XTicks(positions, vacio);
                    formsPlot1.Refresh();

                    formsPlot1.Plot.AddBarSeries(bars);
                    formsPlot1.Plot.SetAxisLimitsY(0, max + (max * 90 / 100));
                    formsPlot1.Plot.YLabel("Precio en USD");
                    formsPlot1.Plot.XLabel("");

                    lblMensaje.Text = "Se han mostrado las cryptos favoritas";
                    lblMensaje.ForeColor = Color.Aqua;
                    Login.log.Info("Se mostraron las cryptos favoritas");
                }
                else
                {
                    lblMensaje.Text = "No hay cryptos favoritas";
                    lblMensaje.ForeColor = Color.Red;
                }
                formsPlot1.Refresh();
            }
            catch (ExcepcionesApi unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                Application.Exit();
            }
        }

        private void btnMostrarCripto_Click(object sender, EventArgs e)
        {
            try
            {
                var respuesta = fachada.GetHystoryFrom(txtCrypto.Text.ToLower());
                if (txtCrypto.Text.ToLower() == "")
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Debe ingresar el id de una crypto";
                }
                else if (respuesta.Count() == 0)
                {
                    lblMensaje.Text = "No se ha encontrado la crypto ingresada";
                    lblMensaje.ForeColor = Color.Red;
                }
                else
                {
                    formsPlot1.Plot.Clear();
                    int i = 0;
                    provider.NumberGroupSeparator = ",";
                    provider.NumberDecimalSeparator = ".";
                    List<ScottPlot.Plottable.Bar> bars = new();
                    foreach (var crypto in respuesta)
                    {
                        i++;
                        double value = double.Parse(crypto.PriceUSD, provider);
                        ScottPlot.Plottable.Bar bar = new()
                        {
                            Value = value,
                            Position = i,
                            FillColor = Color.Aqua,
                            Label = "",
                            LineWidth = 4,
                            LineColor = Color.Aqua,

                        };
                        bars.Add(bar);
                    }
                    var j = 0;
                    string[] fechas = new string[i + 1];
                    double[] positions = new double[i + 1];
                    foreach (var crypto in respuesta)
                    {
                        j++;
                        fechas[j] = crypto.Time.ToString();
                        positions[j] = j;
                    }
                    formsPlot1.Plot.AddBarSeries(bars);
                    formsPlot1.Plot.SetAxisLimitsY(0, 17500);
                    formsPlot1.Plot.XTicks(positions, fechas);
                    formsPlot1.Plot.YLabel("Precio en USD");
                    formsPlot1.Plot.XLabel("Fecha y Hora");
                    lblMensaje.ForeColor = Color.Aqua;
                    lblMensaje.Text = "Crypto Ingresada";
                    dgvCryptos.DataSource = respuesta;
                    formsPlot1.Refresh();
                    Login.log.Info(txtCrypto.Text + " mostrada");
                }
            }
            catch (ExcepcionesApi unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                Application.Exit();
            }

        }

        private void btnEliminarCripto_Click(object sender, EventArgs e)
        {
            var respuesta = fachada.GetHystoryFrom(txtCrypto.Text.ToLower());
            if (txtCrypto.Text.Length == 0)
            {
                lblMensaje.Text = "Debe ingresar el id de una crypto";
                lblMensaje.ForeColor = Color.Red;
            }
            else if (respuesta.Count()==0)
            {
                lblMensaje.Text = "La crypto ingresada no se encuentra";
                lblMensaje.ForeColor = Color.Red;
            }
            else
            {

                if (PantallaPrincipal.user.ExisteCripto(txtCrypto.Text.ToLower()))
                {
                    fachada.DelFavCrypto(txtCrypto.Text.ToLower()); 
                    lblMensaje.Text = "La crypto fue eliminada satisfactoriamente de favoritos";
                    lblMensaje.ForeColor = Color.Red;
                    Login.log.Info("Se eliminó a " + txtCrypto.Text + " de favoritas");
                    var listaCryptosDTO = fachada.ObtenerListaFavoritas();
                    dgvCryptos.DataSource = listaCryptosDTO;
                }
                else
                {
                    lblMensaje.Text = "La crypto que desea eliminar no está en favoritas";
                    lblMensaje.ForeColor = Color.Red;
                    Login.log.Error("Se intentó eliminar una crypto que no es favorita");

                }
            }
        }

        private void btnMostrarTodas_Click(object sender, EventArgs e)
        {
            try
            {
                var respuesta = fachada.GetAllCryptoDTO();
                dgvCryptos.DataSource = respuesta;
                int i = 0;
                provider.NumberGroupSeparator = ",";
                provider.NumberDecimalSeparator = ".";
                formsPlot1.Plot.Clear();
                List<ScottPlot.Plottable.Bar> bars = new();
                foreach (var crypto in respuesta)
                {
                    i++;
                    double value = double.Parse(crypto.PriceUSD, provider);

                    ScottPlot.Plottable.Bar bar = new()
                    {
                        Value = value,
                        Position = i,
                        FillColor = ScottPlot.Palette.Category10.GetColor(i),
                        Label = crypto.Name,
                        LineWidth = 4,
                        LineColor = ScottPlot.Palette.Category10.GetColor(i),

                    };
                    bars.Add(bar);
                }
                double[] positions = new double[i + 1];
                string[] vacio = new string[i + 1];
                int j = 0;
                foreach (var crypto in respuesta)
                {
                    j++;
                    positions[j] = j;
                    vacio[j] = "";
                }
                formsPlot1.Plot.XTicks(positions, vacio);
                formsPlot1.Refresh();

                formsPlot1.Plot.AddBarSeries(bars);
                formsPlot1.Plot.SetAxisLimitsY(0, 17500);
                formsPlot1.Plot.XLabel("");
                formsPlot1.Plot.YLabel("Precio en USD");
                formsPlot1.Refresh();
                Login.log.Info("Se mostraron las cryptos generales");
            }
            catch (ExcepcionesApi unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
                Application.Exit();
            }
        }

        private void btnBorrarSeleccionada_Click(object sender, EventArgs e)
        {
            if (listBoxNotificaciones.SelectedIndex== -1)
            {
                lblMensaje.Text = "Debe seleccionar una cripto";
            }
            else
            {
                fachada.RemoveAlertByIndex(listBoxNotificaciones.SelectedIndex);
                lblMensaje.Text = "Cripto borrada";
            }
            listBoxNotificaciones.Items.Remove(listBoxNotificaciones.SelectedItem);
            Login.log.Info(listBoxNotificaciones.SelectedItem + " Notificación Borrada");

        }

        private void btnBorrarTodas_Click(object sender, EventArgs e)
        {
            fachada.RemoveAllAlerts();
            lblMensaje.Text = "Criptos borradas";
            listBoxNotificaciones.Items.Clear();
            Login.log.Info("Notificaciones Eliminadas");
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

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCambiarUmbral_Click(object sender, EventArgs e)
        {
            var objetoUsuario = fachada.GetUsuarioActual();
            provider.NumberGroupSeparator = ",";
            provider.NumberDecimalSeparator = ".";
            if (txtUmbral.Text.Length == 0)
            {
                lblMensajeUmbral2.Text = "Debe ingresar un valor para cambiar el umbral";
                lblMensajeUmbral2.ForeColor = Color.Red;
            }
            else if (!double.TryParse(txtUmbral.Text, out _))
            {
                lblMensajeUmbral2.Text = "El umbral debe ser un numero";
                lblMensajeUmbral2.ForeColor = Color.Red;

            }
            else
            {
                fachada.ChangeUmbral(txtUmbral.Text, provider);
                lblMensajeUmbral2.Text = "Umbral cambiado exitosamente";
                lblMensajeUmbral2.ForeColor = Color.Green;


                Login.log.Error("Umbral cambiado");
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

        private void dgvCryptos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

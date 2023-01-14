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

namespace TPFinalWindowsForms.Visual
{
    public partial class PantallaPrincipal : Form
    {
        InteraccionApi interaccionCrypto = new InteraccionApi();
        static DBContext context = new DBContext();
        RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
        RepositorioAlertas repoAlertas = new RepositorioAlertas(context);

        Fachada fachada = new Fachada();
        NumberFormatInfo provider = new NumberFormatInfo();


        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            Program.Alertas();
            //Carga de la tabla cryptos generales
            var respuesta = interaccionCrypto.GetAllCrytosDTO();
            dgvCryptos.DataSource = respuesta;
            //CHART
            provider.NumberGroupSeparator = ",";
            provider.NumberDecimalSeparator = ".";
            var cryptosDTO = interaccionCrypto.GetAllCrytosDTO();
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
            double[] positions = new double[i+1];
            string[] vacio = new string[i+1];
            int k = 0;
            foreach (var crypto in cryptosDTO)
            {
                k++;
                positions[k] = k;
                vacio[k]="";
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
            var usuario = repoUsuario.Get(Program.usuarioLogueado);
            void HandleTimer()
            {
                j = 0;
                listBoxNotificaciones.Items.Clear();
                provider.NumberGroupSeparator = ",";
                provider.NumberDecimalSeparator = ".";
                var listaAlertas = repoAlertas.GetAll();
                while (j< listaAlertas.Count())
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
            lblMensajeUmbral.Text ="Umbral Actual: " +usuario.Umbral.ToString()+"%";
        }

        private void btnShowGeneralCryptos_Click(object sender, EventArgs e)
        {
            var respuesta = interaccionCrypto.GetAllCrytosDTO();
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
            double[] positions = new double[i+1];
            string[] vacio = new string[i+1];
            int j = 0;
            foreach (var crypto in respuesta)
            {
                j++;
                positions[j] = j;
                vacio[j]="";
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

        private void btnShowFavCryptos_Click(object sender, EventArgs e)
        {
            var listaCryptosDTO= fachada.ObtenerListaFavoritas();
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
                double[] positions = new double[i+1];
                string[] vacio = new string[i+1];
                int j = 0;
                foreach (var crypto in listaCryptosDTO)
                {
                    j++;
                    positions[j] = j;
                    vacio[j]="";
                }
                formsPlot1.Plot.XTicks(positions,vacio);
                formsPlot1.Refresh();

                formsPlot1.Plot.AddBarSeries(bars);
                formsPlot1.Plot.SetAxisLimitsY(0, max+(max*90/100));
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

        private void btnShowCyrpto_Click(object sender, EventArgs e)
        {
            var respuesta = interaccionCrypto.Get6MonthHistoryFrom(txtCrypto.Text.ToLower());
            if (txtCrypto.Text.ToLower() == "")
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Debe ingresar el id de una crypto";
            }
            else if (respuesta.Count() == 0)
            {
                lblMensaje.Text = "La crypto ingresada no se encuentra";
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
                string[] fechas = new string[i+1];
                double[] positions = new double[i+1];
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
                Login.log.Info(txtCrypto.Text+" mostrada");


            }
        }

        private void btnAddFav_Click(object sender, EventArgs e)
        {

            var respuesta = interaccionCrypto.Get6MonthHistoryFrom(txtCrypto.Text.ToLower());
            if (txtCrypto.Text.Length == 0)
            {
                lblMensaje.Text = "Debe ingresar el id de una crypto";
                lblMensaje.ForeColor = Color.Red;
            }
            else if (respuesta.Count() == 0)
            {
                lblMensaje.Text = "La crypto ingresada no se encuentra";
                lblMensaje.ForeColor = Color.Red;
            }
            else
            {
                var objetoUsuario = repoUsuario.Get(Program.usuarioLogueado);
                string[] arrayCryptos = objetoUsuario.Favcriptos.Split(' ');
                int i = 0;
                bool nueva = true;
                string favorita = txtCrypto.Text.ToLower();
                foreach (var crypto in arrayCryptos)
                {
                    if (crypto == favorita)
                    {
                        nueva = false;
                        break;
                    }
                }                
                if (nueva)
                {
                    using (IUnitOfWork bUoW = new UnitOfWork(new DBContext()))
                    {
                        var usuario = repoUsuario.Get(Program.usuarioLogueado);
                        usuario.Favcriptos = usuario.Favcriptos + " " + txtCrypto.Text;
                        context.SaveChanges();
                        lblMensaje.Text = "La crypto fue agregada a favoritos";
                        lblMensaje.ForeColor = Color.Aqua;
                        Login.log.Info(txtCrypto.Text+" Añadida a favoritas");
                    }

                }
                else
                {
                    lblMensaje.Text = "La crypto ya está entre las favoritas";
                    lblMensaje.ForeColor = Color.Red;
                    Login.log.Error("Crypto ya es una favorita");
                }

            }
        }

        private void btnDelFav_Click(object sender, EventArgs e)
        {
            string cryptosFavoritas = "";
            var respuesta = interaccionCrypto.Get6MonthHistoryFrom(txtCrypto.Text.ToLower());
            if (txtCrypto.Text.Length == 0)
            {
                lblMensaje.Text = "Debe ingresar el id de una crypto";
                lblMensaje.ForeColor = Color.Red;
            }
            else if (respuesta.Count() == 0)
            {
                lblMensaje.Text = "La crypto ingresada no se encuentra";
                lblMensaje.ForeColor = Color.Red;
            }
            else
            {
                var objetoUsuario = repoUsuario.Get(Program.usuarioLogueado);
                string[] arrayCryptos = objetoUsuario.Favcriptos.Split(' ');
                bool existe = false;
                int i = 0;
                foreach (var crypto in arrayCryptos)
                {
                    if (crypto == txtCrypto.Text)
                    {
                        existe = true;
                        break;
                    }
                    i++;
                }
                if (existe)
                {
                    arrayCryptos[i] = null;
                    foreach (var nombreCrypto in arrayCryptos)
                    {
                        if (nombreCrypto != "")
                        {
                            cryptosFavoritas = cryptosFavoritas + " " + nombreCrypto;
                        }
                    }
                    using (IUnitOfWork bUoW = new UnitOfWork(new DBContext()))
                    {
                        objetoUsuario.Favcriptos = cryptosFavoritas;
                        context.SaveChanges();
                        lblMensaje.Text = "La crypto fue eliminada satisfactoriamente de favoritos";
                        lblMensaje.ForeColor = Color.Aqua;
                        Login.log.Info("Se eliminó a "+txtCrypto.Text + " de favoritas");
                    }
                }
                else
                {
                    lblMensaje.Text = "La crypto que desea eliminar no está en favoritas";
                    lblMensaje.ForeColor = Color.Red;
                    Login.log.Error("Se intentó eliminar una crypto que no es favorita");
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


           

            }

        private void btnChangeUmbral_Click(object sender, EventArgs e)
        {
            var objetoUsuario = repoUsuario.Get(Program.usuarioLogueado);
            provider.NumberGroupSeparator = ",";
            provider.NumberDecimalSeparator = ".";
            if (txtUmbral.Text.Length == 0)
            {
                lblMensajeUmbral.Text = "Debe ingresar un valor para cambiar el umbral";
                lblMensajeUmbral.ForeColor = Color.Red;
            }
            else
            {
                objetoUsuario.Umbral = double.Parse(txtUmbral.Text, provider);
                lblMensajeUmbral.Text = "Umbral cambiado exitosamente";
                lblMensajeUmbral.ForeColor = Color.Green;
                context.SaveChanges();
                Login.log.Error("Umbral cambiado");
            }

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
            DBContext contexto = new DBContext();
            RepositorioAlertas repoAlertas = new RepositorioAlertas(contexto);
            var listaAlertas = repoAlertas.GetAll();
            if (listaAlertas.Count() > 0)
            {
                foreach (var alerta in listaAlertas)
                {
                    repoAlertas.Remove(alerta);
                    listBoxNotificaciones.Items.Clear();
                }

            }
            contexto.SaveChanges();
            Login.log.Info("Notificaciones Eliminadas");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DBContext contexto = new DBContext();
            RepositorioAlertas repoAlertas = new RepositorioAlertas(contexto);
            var listaAlertas = repoAlertas.GetAll();
            int i = -1;
            foreach (var alerta in listaAlertas)
            {                
                i++;
                if (listBoxNotificaciones.SelectedIndex >= 0)
                {
                    if (listBoxNotificaciones.SelectedIndex == i)
                    {
                        repoAlertas.Remove(alerta);
                    }
                }
                else
                {
                    lblMensaje.Text="Debe seleccionar una cripto";
                }
            }
            contexto.SaveChanges();
            listBoxNotificaciones.Items.Remove(listBoxNotificaciones.SelectedItem);
            Login.log.Info(listBoxNotificaciones.SelectedItem+" Notificación Borrada");
            
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
    }
}

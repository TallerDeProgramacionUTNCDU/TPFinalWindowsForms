namespace TPFinalWindowsForms.Visual
{
    partial class PantallaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaPrincipal));
            this.btnShowCyrpto = new System.Windows.Forms.Button();
            this.btnAddFav = new System.Windows.Forms.Button();
            this.btnShowFavCryptos = new System.Windows.Forms.Button();
            this.btnDelFav = new System.Windows.Forms.Button();
            this.btnChangeUmbral = new System.Windows.Forms.Button();
            this.dgvCryptos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtCrypto = new System.Windows.Forms.TextBox();
            this.txtUmbral = new System.Windows.Forms.TextBox();
            this.btnShowGeneralCryptos = new System.Windows.Forms.Button();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.lblMensajeUmbral = new System.Windows.Forms.Label();
            this.btnBorrarTodas = new System.Windows.Forms.Button();
            this.listBoxNotificaciones = new System.Windows.Forms.ListBox();
            this.btnBorrarSeleccionada = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUmbralActual = new System.Windows.Forms.Label();
            this.notifAlerta = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCryptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowCyrpto
            // 
            this.btnShowCyrpto.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowCyrpto.Location = new System.Drawing.Point(29, 934);
            this.btnShowCyrpto.Name = "btnShowCyrpto";
            this.btnShowCyrpto.Size = new System.Drawing.Size(133, 72);
            this.btnShowCyrpto.TabIndex = 0;
            this.btnShowCyrpto.Text = "Mostrar Cripto";
            this.btnShowCyrpto.UseVisualStyleBackColor = true;
            this.btnShowCyrpto.Click += new System.EventHandler(this.btnShowCyrpto_Click);
            // 
            // btnAddFav
            // 
            this.btnAddFav.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddFav.Location = new System.Drawing.Point(168, 852);
            this.btnAddFav.Name = "btnAddFav";
            this.btnAddFav.Size = new System.Drawing.Size(133, 72);
            this.btnAddFav.TabIndex = 1;
            this.btnAddFav.Text = "Agregar Cripto Favorita";
            this.btnAddFav.UseVisualStyleBackColor = true;
            this.btnAddFav.Click += new System.EventHandler(this.btnAddFav_Click);
            // 
            // btnShowFavCryptos
            // 
            this.btnShowFavCryptos.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowFavCryptos.Location = new System.Drawing.Point(307, 852);
            this.btnShowFavCryptos.Name = "btnShowFavCryptos";
            this.btnShowFavCryptos.Size = new System.Drawing.Size(133, 72);
            this.btnShowFavCryptos.TabIndex = 2;
            this.btnShowFavCryptos.Text = "Mostrar Favoritas";
            this.btnShowFavCryptos.UseVisualStyleBackColor = true;
            this.btnShowFavCryptos.Click += new System.EventHandler(this.btnShowFavCryptos_Click);
            // 
            // btnDelFav
            // 
            this.btnDelFav.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelFav.Location = new System.Drawing.Point(168, 934);
            this.btnDelFav.Name = "btnDelFav";
            this.btnDelFav.Size = new System.Drawing.Size(133, 72);
            this.btnDelFav.TabIndex = 3;
            this.btnDelFav.Text = "Eliminar Cripto Favorita";
            this.btnDelFav.UseVisualStyleBackColor = true;
            this.btnDelFav.Click += new System.EventHandler(this.btnDelFav_Click);
            // 
            // btnChangeUmbral
            // 
            this.btnChangeUmbral.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChangeUmbral.Location = new System.Drawing.Point(1519, 914);
            this.btnChangeUmbral.Name = "btnChangeUmbral";
            this.btnChangeUmbral.Size = new System.Drawing.Size(222, 74);
            this.btnChangeUmbral.TabIndex = 5;
            this.btnChangeUmbral.Text = "Cambiar Umbral";
            this.btnChangeUmbral.UseVisualStyleBackColor = true;
            this.btnChangeUmbral.Click += new System.EventHandler(this.btnChangeUmbral_Click);
            // 
            // dgvCryptos
            // 
            this.dgvCryptos.AllowUserToAddRows = false;
            this.dgvCryptos.AllowUserToDeleteRows = false;
            this.dgvCryptos.AllowUserToOrderColumns = true;
            this.dgvCryptos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCryptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCryptos.Location = new System.Drawing.Point(475, 759);
            this.dgvCryptos.Name = "dgvCryptos";
            this.dgvCryptos.ReadOnly = true;
            this.dgvCryptos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvCryptos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCryptos.RowTemplate.Height = 30;
            this.dgvCryptos.Size = new System.Drawing.Size(857, 258);
            this.dgvCryptos.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1519, 852);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ingrese el Umbral en %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1508, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Área de Notificaciones";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(29, 850);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(96, 15);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "Ingrese la Crypto";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensaje.Location = new System.Drawing.Point(12, 787);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(68, 21);
            this.lblMensaje.TabIndex = 11;
            this.lblMensaje.Text = "Mensaje";
            // 
            // txtCrypto
            // 
            this.txtCrypto.Location = new System.Drawing.Point(29, 871);
            this.txtCrypto.Name = "txtCrypto";
            this.txtCrypto.Size = new System.Drawing.Size(133, 23);
            this.txtCrypto.TabIndex = 12;
            this.txtCrypto.TextChanged += new System.EventHandler(this.txtCrypto_TextChanged);
            // 
            // txtUmbral
            // 
            this.txtUmbral.Location = new System.Drawing.Point(1564, 885);
            this.txtUmbral.Name = "txtUmbral";
            this.txtUmbral.Size = new System.Drawing.Size(133, 23);
            this.txtUmbral.TabIndex = 13;
            // 
            // btnShowGeneralCryptos
            // 
            this.btnShowGeneralCryptos.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowGeneralCryptos.Location = new System.Drawing.Point(307, 934);
            this.btnShowGeneralCryptos.Name = "btnShowGeneralCryptos";
            this.btnShowGeneralCryptos.Size = new System.Drawing.Size(133, 72);
            this.btnShowGeneralCryptos.TabIndex = 14;
            this.btnShowGeneralCryptos.Text = "Mostrar Todas";
            this.btnShowGeneralCryptos.UseVisualStyleBackColor = true;
            this.btnShowGeneralCryptos.Click += new System.EventHandler(this.btnShowGeneralCryptos_Click);
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(-1, -1);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1287, 754);
            this.formsPlot1.TabIndex = 15;
            this.formsPlot1.Load += new System.EventHandler(this.formsPlot1_Load);
            // 
            // lblMensajeUmbral
            // 
            this.lblMensajeUmbral.AutoSize = true;
            this.lblMensajeUmbral.Location = new System.Drawing.Point(1671, 1075);
            this.lblMensajeUmbral.Name = "lblMensajeUmbral";
            this.lblMensajeUmbral.Size = new System.Drawing.Size(0, 15);
            this.lblMensajeUmbral.TabIndex = 16;
            // 
            // btnBorrarTodas
            // 
            this.btnBorrarTodas.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBorrarTodas.Location = new System.Drawing.Point(1674, 759);
            this.btnBorrarTodas.Name = "btnBorrarTodas";
            this.btnBorrarTodas.Size = new System.Drawing.Size(201, 74);
            this.btnBorrarTodas.TabIndex = 18;
            this.btnBorrarTodas.Text = "Borrar Todas";
            this.btnBorrarTodas.UseVisualStyleBackColor = true;
            this.btnBorrarTodas.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listBoxNotificaciones
            // 
            this.listBoxNotificaciones.BackColor = System.Drawing.Color.Gray;
            this.listBoxNotificaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxNotificaciones.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listBoxNotificaciones.ForeColor = System.Drawing.Color.White;
            this.listBoxNotificaciones.FormattingEnabled = true;
            this.listBoxNotificaciones.ItemHeight = 22;
            this.listBoxNotificaciones.Location = new System.Drawing.Point(1293, 95);
            this.listBoxNotificaciones.Name = "listBoxNotificaciones";
            this.listBoxNotificaciones.Size = new System.Drawing.Size(604, 616);
            this.listBoxNotificaciones.TabIndex = 19;
            this.listBoxNotificaciones.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnBorrarSeleccionada
            // 
            this.btnBorrarSeleccionada.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBorrarSeleccionada.Location = new System.Drawing.Point(1400, 759);
            this.btnBorrarSeleccionada.Name = "btnBorrarSeleccionada";
            this.btnBorrarSeleccionada.Size = new System.Drawing.Size(222, 74);
            this.btnBorrarSeleccionada.TabIndex = 20;
            this.btnBorrarSeleccionada.Text = "Borrar Seleccionada";
            this.btnBorrarSeleccionada.UseVisualStyleBackColor = true;
            this.btnBorrarSeleccionada.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1792, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblUmbralActual
            // 
            this.lblUmbralActual.AutoSize = true;
            this.lblUmbralActual.Location = new System.Drawing.Point(1674, 991);
            this.lblUmbralActual.Name = "lblUmbralActual";
            this.lblUmbralActual.Size = new System.Drawing.Size(0, 15);
            this.lblUmbralActual.TabIndex = 22;
            // 
            // notifAlerta
            // 
            this.notifAlerta.BalloonTipText = "Click para ver su panel de seguimiento";
            this.notifAlerta.BalloonTipTitle = "Alertas Cryptomonedas";
            this.notifAlerta.ContextMenuStrip = this.contextMenuStrip1;
            this.notifAlerta.Icon = ((System.Drawing.Icon)(resources.GetObject("notifAlerta.Icon")));
            this.notifAlerta.Text = "Alertas Cryptos";
            this.notifAlerta.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifAlerta.DoubleClick += new System.EventHandler(this.notifAlerta_DoubleClick);
            this.notifAlerta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifAlerta_MouseClick);
            this.notifAlerta.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 48);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1924, 1035);
            this.Controls.Add(this.lblUmbralActual);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBorrarSeleccionada);
            this.Controls.Add(this.listBoxNotificaciones);
            this.Controls.Add(this.btnBorrarTodas);
            this.Controls.Add(this.lblMensajeUmbral);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.btnShowGeneralCryptos);
            this.Controls.Add(this.txtUmbral);
            this.Controls.Add(this.txtCrypto);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCryptos);
            this.Controls.Add(this.btnChangeUmbral);
            this.Controls.Add(this.btnDelFav);
            this.Controls.Add(this.btnShowFavCryptos);
            this.Controls.Add(this.btnAddFav);
            this.Controls.Add(this.btnShowCyrpto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PantallaPrincipal";
            this.Text = "PantallaPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PantallaPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.PantallaPrincipal_Load);
            this.SizeChanged += new System.EventHandler(this.PantallaPrincipal_SizeChanged);
            this.Resize += new System.EventHandler(this.PantallaPrincipal_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCryptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnShowCyrpto;
        private Button btnAddFav;
        private Button btnShowFavCryptos;
        private Button btnDelFav;
        private Button btnChangeUmbral;
        private DataGridView dgvCryptos;
        private Label label1;
        private Label label2;
        private Label lbl1;
        private Label lblMensaje;
        private TextBox txtCrypto;
        private TextBox txtUmbral;
        private Button btnShowGeneralCryptos;
        private ScottPlot.FormsPlot formsPlot1;
        private Label lblMensajeUmbral;
        private Button btnBorrarTodas;
        private ListBox listBoxNotificaciones;
        private Button btnBorrarSeleccionada;
        private PictureBox pictureBox1;
        private Label lblUmbralActual;
        private NotifyIcon notifAlerta;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem mostrarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}
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
            this.dgvCryptos = new System.Windows.Forms.DataGridView();
            this.lblMensajeUmbral2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtCrypto = new System.Windows.Forms.TextBox();
            this.txtUmbral = new System.Windows.Forms.TextBox();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.lblMensajeUmbral = new System.Windows.Forms.Label();
            this.listBoxNotificaciones = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUmbralActual = new System.Windows.Forms.Label();
            this.notifAlerta = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.controlBox = new System.Windows.Forms.Panel();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.pboxMinimizarVentana = new System.Windows.Forms.PictureBox();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChangeUmbral = new System.Windows.Forms.Button();
            this.btnDeleteAllNotifications = new System.Windows.Forms.Button();
            this.btnDeleteSelectedNotification = new System.Windows.Forms.Button();
            this.btnShowAllCriptos = new System.Windows.Forms.Button();
            this.btnShowFavCriptos = new System.Windows.Forms.Button();
            this.btnDelCripto = new System.Windows.Forms.Button();
            this.btnAgregarCripto = new System.Windows.Forms.Button();
            this.btnShowCripto = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCryptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizarVentana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCryptos
            // 
            this.dgvCryptos.AllowUserToAddRows = false;
            this.dgvCryptos.AllowUserToDeleteRows = false;
            this.dgvCryptos.AllowUserToOrderColumns = true;
            this.dgvCryptos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCryptos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCryptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCryptos.Location = new System.Drawing.Point(479, 627);
            this.dgvCryptos.Name = "dgvCryptos";
            this.dgvCryptos.ReadOnly = true;
            this.dgvCryptos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvCryptos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCryptos.RowTemplate.Height = 30;
            this.dgvCryptos.Size = new System.Drawing.Size(744, 299);
            this.dgvCryptos.TabIndex = 7;
            this.dgvCryptos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCryptos_CellContentClick);
            // 
            // lblMensajeUmbral2
            // 
            this.lblMensajeUmbral2.AutoSize = true;
            this.lblMensajeUmbral2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensajeUmbral2.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensajeUmbral2.Location = new System.Drawing.Point(0, 0);
            this.lblMensajeUmbral2.Name = "lblMensajeUmbral2";
            this.lblMensajeUmbral2.Size = new System.Drawing.Size(179, 31);
            this.lblMensajeUmbral2.TabIndex = 8;
            this.lblMensajeUmbral2.Text = "Mensaje Umbral";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(1440, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 35);
            this.label2.TabIndex = 9;
            this.label2.Text = "Área de Notificaciones";
            // 
            // lbl1
            // 
            this.lbl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(67, 590);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(185, 31);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "Ingrese la Crypto";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(0, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(97, 31);
            this.lblMensaje.TabIndex = 11;
            this.lblMensaje.Text = "Mensaje";
            // 
            // txtCrypto
            // 
            this.txtCrypto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCrypto.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCrypto.Location = new System.Drawing.Point(67, 627);
            this.txtCrypto.Name = "txtCrypto";
            this.txtCrypto.Size = new System.Drawing.Size(384, 39);
            this.txtCrypto.TabIndex = 12;
            this.txtCrypto.TextChanged += new System.EventHandler(this.txtCrypto_TextChanged);
            // 
            // txtUmbral
            // 
            this.txtUmbral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUmbral.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUmbral.Location = new System.Drawing.Point(1370, 787);
            this.txtUmbral.Name = "txtUmbral";
            this.txtUmbral.Size = new System.Drawing.Size(317, 39);
            this.txtUmbral.TabIndex = 13;
            this.txtUmbral.TextChanged += new System.EventHandler(this.txtUmbral_TextChanged);
            // 
            // formsPlot1
            // 
            this.formsPlot1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formsPlot1.Location = new System.Drawing.Point(17, 6);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1206, 546);
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
            // listBoxNotificaciones
            // 
            this.listBoxNotificaciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxNotificaciones.BackColor = System.Drawing.Color.White;
            this.listBoxNotificaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxNotificaciones.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listBoxNotificaciones.ForeColor = System.Drawing.Color.Purple;
            this.listBoxNotificaciones.FormattingEnabled = true;
            this.listBoxNotificaciones.ItemHeight = 22;
            this.listBoxNotificaciones.Location = new System.Drawing.Point(1230, 98);
            this.listBoxNotificaciones.Name = "listBoxNotificaciones";
            this.listBoxNotificaciones.Size = new System.Drawing.Size(680, 418);
            this.listBoxNotificaciones.TabIndex = 19;
            this.listBoxNotificaciones.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1797, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblUmbralActual
            // 
            this.lblUmbralActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUmbralActual.AutoSize = true;
            this.lblUmbralActual.Location = new System.Drawing.Point(1449, 911);
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
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Purple;
            this.panelSuperior.Controls.Add(this.controlBox);
            this.panelSuperior.Controls.Add(this.label8);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1924, 92);
            this.panelSuperior.TabIndex = 35;
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            // 
            // controlBox
            // 
            this.controlBox.BackColor = System.Drawing.Color.Purple;
            this.controlBox.Controls.Add(this.pboxCerrar);
            this.controlBox.Controls.Add(this.pboxMinimizarVentana);
            this.controlBox.Controls.Add(this.pboxMinimizar);
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlBox.Location = new System.Drawing.Point(1705, 0);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(219, 92);
            this.controlBox.TabIndex = 4;
            // 
            // pboxCerrar
            // 
            this.pboxCerrar.Image = global::TPFinalWindowsForms.Properties.Resources.cerrar;
            this.pboxCerrar.Location = new System.Drawing.Point(162, 12);
            this.pboxCerrar.Margin = new System.Windows.Forms.Padding(5);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Padding = new System.Windows.Forms.Padding(5);
            this.pboxCerrar.Size = new System.Drawing.Size(43, 40);
            this.pboxCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxCerrar.TabIndex = 3;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // pboxMinimizarVentana
            // 
            this.pboxMinimizarVentana.Image = global::TPFinalWindowsForms.Properties.Resources.maximizar;
            this.pboxMinimizarVentana.Location = new System.Drawing.Point(111, 12);
            this.pboxMinimizarVentana.Name = "pboxMinimizarVentana";
            this.pboxMinimizarVentana.Size = new System.Drawing.Size(43, 40);
            this.pboxMinimizarVentana.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxMinimizarVentana.TabIndex = 2;
            this.pboxMinimizarVentana.TabStop = false;
            this.pboxMinimizarVentana.Click += new System.EventHandler(this.pboxMinimizarVentana_Click);
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Image = global::TPFinalWindowsForms.Properties.Resources.minimizar_signo;
            this.pboxMinimizar.Location = new System.Drawing.Point(62, 12);
            this.pboxMinimizar.Name = "pboxMinimizar";
            this.pboxMinimizar.Padding = new System.Windows.Forms.Padding(2);
            this.pboxMinimizar.Size = new System.Drawing.Size(43, 40);
            this.pboxMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxMinimizar.TabIndex = 1;
            this.pboxMinimizar.TabStop = false;
            this.pboxMinimizar.Click += new System.EventHandler(this.pboxMinimizar_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sylfaen", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(908, -445);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 46);
            this.label8.TabIndex = 0;
            this.label8.Text = "Perfil";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnChangeUmbral);
            this.panel1.Controls.Add(this.btnDeleteAllNotifications);
            this.panel1.Controls.Add(this.btnDeleteSelectedNotification);
            this.panel1.Controls.Add(this.btnShowAllCriptos);
            this.panel1.Controls.Add(this.btnShowFavCriptos);
            this.panel1.Controls.Add(this.btnDelCripto);
            this.panel1.Controls.Add(this.btnAgregarCripto);
            this.panel1.Controls.Add(this.btnShowCripto);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.formsPlot1);
            this.panel1.Controls.Add(this.listBoxNotificaciones);
            this.panel1.Controls.Add(this.lblUmbralActual);
            this.panel1.Controls.Add(this.txtCrypto);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.txtUmbral);
            this.panel1.Controls.Add(this.dgvCryptos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 943);
            this.panel1.TabIndex = 5;
            // 
            // btnChangeUmbral
            // 
            this.btnChangeUmbral.BackColor = System.Drawing.Color.Purple;
            this.btnChangeUmbral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeUmbral.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChangeUmbral.ForeColor = System.Drawing.Color.White;
            this.btnChangeUmbral.Location = new System.Drawing.Point(1399, 832);
            this.btnChangeUmbral.Name = "btnChangeUmbral";
            this.btnChangeUmbral.Size = new System.Drawing.Size(219, 79);
            this.btnChangeUmbral.TabIndex = 40;
            this.btnChangeUmbral.Text = "Cambiar Umbral";
            this.btnChangeUmbral.UseVisualStyleBackColor = false;
            this.btnChangeUmbral.Click += new System.EventHandler(this.btnCambiarUmbral_Click);
            // 
            // btnDeleteAllNotifications
            // 
            this.btnDeleteAllNotifications.BackColor = System.Drawing.Color.Purple;
            this.btnDeleteAllNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAllNotifications.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteAllNotifications.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAllNotifications.Location = new System.Drawing.Point(1545, 627);
            this.btnDeleteAllNotifications.Name = "btnDeleteAllNotifications";
            this.btnDeleteAllNotifications.Size = new System.Drawing.Size(219, 79);
            this.btnDeleteAllNotifications.TabIndex = 39;
            this.btnDeleteAllNotifications.Text = "Borrar Todas";
            this.btnDeleteAllNotifications.UseVisualStyleBackColor = false;
            this.btnDeleteAllNotifications.Click += new System.EventHandler(this.btnBorrarTodas_Click);
            // 
            // btnDeleteSelectedNotification
            // 
            this.btnDeleteSelectedNotification.BackColor = System.Drawing.Color.Purple;
            this.btnDeleteSelectedNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelectedNotification.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteSelectedNotification.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSelectedNotification.Location = new System.Drawing.Point(1294, 627);
            this.btnDeleteSelectedNotification.Name = "btnDeleteSelectedNotification";
            this.btnDeleteSelectedNotification.Size = new System.Drawing.Size(219, 79);
            this.btnDeleteSelectedNotification.TabIndex = 38;
            this.btnDeleteSelectedNotification.Text = "Borrar Seleccionada";
            this.btnDeleteSelectedNotification.UseVisualStyleBackColor = false;
            this.btnDeleteSelectedNotification.Click += new System.EventHandler(this.btnBorrarSeleccionada_Click);
            // 
            // btnShowAllCriptos
            // 
            this.btnShowAllCriptos.BackColor = System.Drawing.Color.Purple;
            this.btnShowAllCriptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllCriptos.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowAllCriptos.ForeColor = System.Drawing.Color.White;
            this.btnShowAllCriptos.Location = new System.Drawing.Point(67, 847);
            this.btnShowAllCriptos.Name = "btnShowAllCriptos";
            this.btnShowAllCriptos.Size = new System.Drawing.Size(384, 79);
            this.btnShowAllCriptos.TabIndex = 37;
            this.btnShowAllCriptos.Text = "Mostrar Todas";
            this.btnShowAllCriptos.UseVisualStyleBackColor = false;
            this.btnShowAllCriptos.Click += new System.EventHandler(this.btnMostrarTodas_Click);
            // 
            // btnShowFavCriptos
            // 
            this.btnShowFavCriptos.BackColor = System.Drawing.Color.Purple;
            this.btnShowFavCriptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowFavCriptos.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowFavCriptos.ForeColor = System.Drawing.Color.White;
            this.btnShowFavCriptos.Location = new System.Drawing.Point(67, 762);
            this.btnShowFavCriptos.Name = "btnShowFavCriptos";
            this.btnShowFavCriptos.Size = new System.Drawing.Size(384, 79);
            this.btnShowFavCriptos.TabIndex = 36;
            this.btnShowFavCriptos.Text = "Mostrar Favoritas";
            this.btnShowFavCriptos.UseVisualStyleBackColor = false;
            this.btnShowFavCriptos.Click += new System.EventHandler(this.btnMostrarFavoritas_Click);
            // 
            // btnDelCripto
            // 
            this.btnDelCripto.BackColor = System.Drawing.Color.Purple;
            this.btnDelCripto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelCripto.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelCripto.ForeColor = System.Drawing.Color.White;
            this.btnDelCripto.Location = new System.Drawing.Point(327, 672);
            this.btnDelCripto.Name = "btnDelCripto";
            this.btnDelCripto.Size = new System.Drawing.Size(124, 79);
            this.btnDelCripto.TabIndex = 35;
            this.btnDelCripto.Text = "Eliminar Cripto";
            this.btnDelCripto.UseVisualStyleBackColor = false;
            this.btnDelCripto.Click += new System.EventHandler(this.btnDelFav_Click);
            // 
            // btnAgregarCripto
            // 
            this.btnAgregarCripto.BackColor = System.Drawing.Color.Purple;
            this.btnAgregarCripto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCripto.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarCripto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCripto.Location = new System.Drawing.Point(197, 672);
            this.btnAgregarCripto.Name = "btnAgregarCripto";
            this.btnAgregarCripto.Size = new System.Drawing.Size(124, 79);
            this.btnAgregarCripto.TabIndex = 34;
            this.btnAgregarCripto.Text = "Agregar Cripto";
            this.btnAgregarCripto.UseVisualStyleBackColor = false;
            this.btnAgregarCripto.Click += new System.EventHandler(this.btnAgregarCriptoFavoritos_Click);
            // 
            // btnShowCripto
            // 
            this.btnShowCripto.BackColor = System.Drawing.Color.Purple;
            this.btnShowCripto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowCripto.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowCripto.ForeColor = System.Drawing.Color.White;
            this.btnShowCripto.Location = new System.Drawing.Point(67, 672);
            this.btnShowCripto.Name = "btnShowCripto";
            this.btnShowCripto.Size = new System.Drawing.Size(124, 79);
            this.btnShowCripto.TabIndex = 33;
            this.btnShowCripto.Text = "Mostrar Cripto";
            this.btnShowCripto.UseVisualStyleBackColor = false;
            this.btnShowCripto.Click += new System.EventHandler(this.btnShowCyrpto_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.lblMensajeUmbral2);
            this.panel3.Location = new System.Drawing.Point(1294, 722);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 47);
            this.panel3.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.lblMensaje);
            this.panel2.Location = new System.Drawing.Point(67, 542);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 36);
            this.panel2.TabIndex = 28;
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1035);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.lblMensajeUmbral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.controlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizarVentana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dgvCryptos;
        private Label lblMensajeUmbral2;
        private Label label2;
        private Label lbl1;
        private Label lblMensaje;
        private TextBox txtCrypto;
        private TextBox txtUmbral;
        private ScottPlot.FormsPlot formsPlot1;
        private Label lblMensajeUmbral;
        private ListBox listBoxNotificaciones;
        private PictureBox pictureBox1;
        private Label lblUmbralActual;
        private NotifyIcon notifAlerta;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem mostrarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Panel panelSuperior;
        private Panel controlBox;
        private PictureBox pboxCerrar;
        private PictureBox pboxMinimizarVentana;
        private PictureBox pboxMinimizar;
        private Label label8;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button btnShowAllCriptos;
        private Button btnShowFavCriptos;
        private Button btnDelCripto;
        private Button btnAgregarCripto;
        private Button btnShowCripto;
        private Button btnChangeUmbral;
        private Button btnDeleteAllNotifications;
        private Button btnDeleteSelectedNotification;
    }
}
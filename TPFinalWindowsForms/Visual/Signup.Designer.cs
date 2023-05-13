namespace TPFinalWindowsForms.Visual
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            this.label8 = new System.Windows.Forms.Label();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.controlBox = new System.Windows.Forms.Panel();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.pboxMinimizarVentana = new System.Windows.Forms.PictureBox();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCheckMail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.txtCheckPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.panelSuperior.SuspendLayout();
            this.controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizarVentana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sylfaen", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(458, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 46);
            this.label8.TabIndex = 0;
            this.label8.Text = "Registro";
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Purple;
            this.panelSuperior.Controls.Add(this.controlBox);
            this.panelSuperior.Controls.Add(this.label8);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1229, 92);
            this.panelSuperior.TabIndex = 18;
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            // 
            // controlBox
            // 
            this.controlBox.BackColor = System.Drawing.Color.Purple;
            this.controlBox.Controls.Add(this.pboxCerrar);
            this.controlBox.Controls.Add(this.pboxMinimizarVentana);
            this.controlBox.Controls.Add(this.pboxMinimizar);
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlBox.Location = new System.Drawing.Point(1010, 0);
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(388, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(690, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(386, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(393, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(715, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.Location = new System.Drawing.Point(618, 230);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(262, 39);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNick_KeyDown);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensaje.Location = new System.Drawing.Point(547, 357);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(97, 31);
            this.lblMensaje.TabIndex = 15;
            this.lblMensaje.Text = "Mensaje";
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtApellido.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtApellido.Location = new System.Drawing.Point(307, 230);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(262, 39);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNick_KeyDown);
            // 
            // txtCheckMail
            // 
            this.txtCheckMail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCheckMail.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCheckMail.Location = new System.Drawing.Point(618, 315);
            this.txtCheckMail.Name = "txtCheckMail";
            this.txtCheckMail.Size = new System.Drawing.Size(262, 39);
            this.txtCheckMail.TabIndex = 6;
            this.txtCheckMail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNick_KeyDown);
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombre.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombre.Location = new System.Drawing.Point(307, 149);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(262, 39);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNick_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(648, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 31);
            this.label6.TabIndex = 14;
            this.label6.Text = "Confirmar Email";
            // 
            // txtNick
            // 
            this.txtNick.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNick.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNick.Location = new System.Drawing.Point(307, 63);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(262, 39);
            this.txtNick.TabIndex = 0;
            this.txtNick.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNick_KeyDown);
            // 
            // txtCheckPass
            // 
            this.txtCheckPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCheckPass.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCheckPass.Location = new System.Drawing.Point(618, 149);
            this.txtCheckPass.Name = "txtCheckPass";
            this.txtCheckPass.Size = new System.Drawing.Size(262, 39);
            this.txtCheckPass.TabIndex = 4;
            this.txtCheckPass.UseSystemPasswordChar = true;
            this.txtCheckPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNick_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(634, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "Confirmar Contraseña";
            // 
            // txtPass
            // 
            this.txtPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPass.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPass.Location = new System.Drawing.Point(618, 63);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(262, 39);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNick_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.btnSignUp);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtCheckPass);
            this.panel1.Controls.Add(this.txtNick);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.txtCheckMail);
            this.panel1.Controls.Add(this.txtApellido);
            this.panel1.Controls.Add(this.lblMensaje);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1229, 508);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.Color.Purple;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(307, 391);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(262, 86);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Acceder";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSignUp.BackColor = System.Drawing.Color.Purple;
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(618, 391);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(262, 86);
            this.btnSignUp.TabIndex = 8;
            this.btnSignUp.Text = "Registrarse";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1229, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSuperior);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Signup";
            this.Text = "Signup";
            this.Load += new System.EventHandler(this.Signup_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.controlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizarVentana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label8;
        private Panel panelSuperior;
        private Panel controlBox;
        private PictureBox pboxCerrar;
        private PictureBox pboxMinimizarVentana;
        private PictureBox pboxMinimizar;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label1;
        private Label label5;
        private TextBox txtEmail;
        private Label lblMensaje;
        private TextBox txtApellido;
        private TextBox txtCheckMail;
        private TextBox txtNombre;
        private Label label6;
        private TextBox txtNick;
        private TextBox txtCheckPass;
        private Label label7;
        private TextBox txtPass;
        private Panel panel1;
        private Button btnLogin;
        private Button btnSignUp;
    }
}
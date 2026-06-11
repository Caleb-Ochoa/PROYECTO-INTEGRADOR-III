namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            chkMostrar = new CheckBox();
            btnIngresarSesion = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            pnlLogin = new Panel();
            btnIdioma = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(145, 203);
            label1.Name = "label1";
            label1.Size = new Size(56, 19);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(145, 265);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = SystemColors.ScrollBar;
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.Location = new Point(145, 225);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(225, 25);
            txtUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.BackColor = SystemColors.ScrollBar;
            txtContraseña.Font = new Font("Segoe UI", 10F);
            txtContraseña.Location = new Point(145, 287);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(225, 25);
            txtContraseña.TabIndex = 3;
            // 
            // chkMostrar
            // 
            chkMostrar.AutoSize = true;
            chkMostrar.Font = new Font("Segoe UI", 9F);
            chkMostrar.Location = new Point(145, 318);
            chkMostrar.Name = "chkMostrar";
            chkMostrar.Size = new Size(130, 19);
            chkMostrar.TabIndex = 4;
            chkMostrar.Text = "Mostrar Contraseña";
            chkMostrar.UseVisualStyleBackColor = true;
            chkMostrar.CheckedChanged += chkMostrar_CheckedChanged;
            // 
            // btnIngresarSesion
            // 
            btnIngresarSesion.BackColor = SystemColors.ActiveCaption;
            btnIngresarSesion.Font = new Font("Segoe UI", 10F);
            btnIngresarSesion.Location = new Point(145, 380);
            btnIngresarSesion.Name = "btnIngresarSesion";
            btnIngresarSesion.Size = new Size(225, 31);
            btnIngresarSesion.TabIndex = 5;
            btnIngresarSesion.Text = "Ingresar";
            btnIngresarSesion.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(201, 116);
            label4.Name = "label4";
            label4.Size = new Size(112, 21);
            label4.TabIndex = 8;
            label4.Text = "Iniciar Sesión";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1000946;
            pictureBox1.Location = new Point(201, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(132, 147);
            label3.Name = "label3";
            label3.Size = new Size(250, 35);
            label3.TabIndex = 10;
            label3.Text = "Ingrese sus credenciales para acceder al sistema.";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Click += label3_Click;
            // 
            // pnlLogin
            // 
            pnlLogin.Anchor = AnchorStyles.None;
            pnlLogin.Controls.Add(btnIdioma);
            pnlLogin.Controls.Add(pictureBox1);
            pnlLogin.Controls.Add(btnIngresarSesion);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(chkMostrar);
            pnlLogin.Controls.Add(label4);
            pnlLogin.Controls.Add(txtContraseña);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(txtUsuario);
            pnlLogin.Location = new Point(132, 24);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(496, 450);
            pnlLogin.TabIndex = 11;
            // 
            // btnIdioma
            // 
            btnIdioma.Location = new Point(439, 3);
            btnIdioma.Name = "btnIdioma";
            btnIdioma.Size = new Size(33, 37);
            btnIdioma.TabIndex = 12;
            btnIdioma.Text = "🌐";
            btnIdioma.UseVisualStyleBackColor = true;
            btnIdioma.Click += btnIdioma_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(751, 531);
            Controls.Add(pnlLogin);
            Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Login";
            Text = "INICIO SESION";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label3;
        public CheckBox chkMostrar;
        public Button btnIngresarSesion;
        public TextBox txtContraseña;
        private Panel pnlLogin;
        private Button btnIdioma;
    }
}

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class RegistroAdmin
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNombreCompleto = new TextBox();
            txtUsuarioAdmin = new TextBox();
            txtCorreoAdmin = new TextBox();
            txtContraseñaAdmin = new TextBox();
            txtConfirmarContraseña = new TextBox();
            btnRegistarAdmin = new Button();
            label6 = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(46, 175);
            label1.Name = "label1";
            label1.Size = new Size(135, 19);
            label1.TabIndex = 0;
            label1.Text = "Nombre Completo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(46, 234);
            label2.Name = "label2";
            label2.Size = new Size(60, 19);
            label2.TabIndex = 1;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(46, 292);
            label3.Name = "label3";
            label3.Size = new Size(134, 19);
            label3.TabIndex = 2;
            label3.Text = "Correo Electronico";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(46, 349);
            label4.Name = "label4";
            label4.Size = new Size(84, 19);
            label4.TabIndex = 3;
            label4.Text = "Contraseña";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(46, 409);
            label5.Name = "label5";
            label5.Size = new Size(154, 19);
            label5.TabIndex = 4;
            label5.Text = "Confirmar contraseña";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(46, 197);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(242, 23);
            txtNombreCompleto.TabIndex = 5;
            // 
            // txtUsuarioAdmin
            // 
            txtUsuarioAdmin.Location = new Point(46, 256);
            txtUsuarioAdmin.Name = "txtUsuarioAdmin";
            txtUsuarioAdmin.Size = new Size(242, 23);
            txtUsuarioAdmin.TabIndex = 6;
            // 
            // txtCorreoAdmin
            // 
            txtCorreoAdmin.Location = new Point(46, 314);
            txtCorreoAdmin.Name = "txtCorreoAdmin";
            txtCorreoAdmin.Size = new Size(242, 23);
            txtCorreoAdmin.TabIndex = 7;
            // 
            // txtContraseñaAdmin
            // 
            txtContraseñaAdmin.Location = new Point(46, 371);
            txtContraseñaAdmin.Name = "txtContraseñaAdmin";
            txtContraseñaAdmin.Size = new Size(242, 23);
            txtContraseñaAdmin.TabIndex = 8;
            // 
            // txtConfirmarContraseña
            // 
            txtConfirmarContraseña.Location = new Point(46, 431);
            txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            txtConfirmarContraseña.Size = new Size(242, 23);
            txtConfirmarContraseña.TabIndex = 9;
            // 
            // btnRegistarAdmin
            // 
            btnRegistarAdmin.BackColor = SystemColors.ActiveCaption;
            btnRegistarAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistarAdmin.Location = new Point(46, 495);
            btnRegistarAdmin.Name = "btnRegistarAdmin";
            btnRegistarAdmin.Size = new Size(242, 34);
            btnRegistarAdmin.TabIndex = 10;
            btnRegistarAdmin.Text = "Registrar Administrador";
            btnRegistarAdmin.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(61, 93);
            label6.Name = "label6";
            label6.Size = new Size(210, 21);
            label6.TabIndex = 11;
            label6.Text = "Registro de Administrador";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 8F);
            label7.Location = new Point(46, 130);
            label7.Name = "label7";
            label7.Size = new Size(250, 36);
            label7.TabIndex = 12;
            label7.Text = "Debe registrar el administrador principal antes de iniciar sesión. ";
            label7.TextAlign = ContentAlignment.TopCenter;
            label7.Click += label7_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.images;
            pictureBox1.Location = new Point(107, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // RegistroAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 559);
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnRegistarAdmin);
            Controls.Add(txtConfirmarContraseña);
            Controls.Add(txtContraseñaAdmin);
            Controls.Add(txtCorreoAdmin);
            Controls.Add(txtUsuarioAdmin);
            Controls.Add(txtNombreCompleto);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegistroAdmin";
            Text = "RegistroAdmin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombreCompleto;
        private TextBox txtUsuarioAdmin;
        private TextBox txtCorreoAdmin;
        private TextBox txtContraseñaAdmin;
        private TextBox txtConfirmarContraseña;
        private Button btnRegistarAdmin;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox1;
    }
}
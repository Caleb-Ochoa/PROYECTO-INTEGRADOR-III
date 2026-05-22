namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    partial class Form1
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
            btnIngresar = new Button();
            btnCrear = new Button();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(59, 146);
            label1.Name = "label1";
            label1.Size = new Size(60, 19);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(59, 209);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtUsuario.Location = new Point(59, 168);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(225, 25);
            txtUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtContraseña.Location = new Point(59, 231);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(225, 25);
            txtContraseña.TabIndex = 3;
            // 
            // chkMostrar
            // 
            chkMostrar.AutoSize = true;
            chkMostrar.Font = new Font("Segoe UI", 9F);
            chkMostrar.Location = new Point(59, 262);
            chkMostrar.Name = "chkMostrar";
            chkMostrar.Size = new Size(130, 19);
            chkMostrar.TabIndex = 4;
            chkMostrar.Text = "Mostrar Contraseña";
            chkMostrar.UseVisualStyleBackColor = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = SystemColors.ActiveCaption;
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIngresar.Location = new Point(59, 328);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(225, 31);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // btnCrear
            // 
            btnCrear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCrear.Location = new Point(59, 365);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(225, 27);
            btnCrear.TabIndex = 6;
            btnCrear.Text = "Crear Cuenta";
            btnCrear.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(59, 425);
            label3.Name = "label3";
            label3.Size = new Size(251, 15);
            label3.TabIndex = 7;
            label3.Text = "¿No tienes cuenta?  Haz clic en \"Crear Cuenta\"";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(114, 115);
            label4.Name = "label4";
            label4.Size = new Size(112, 21);
            label4.TabIndex = 8;
            label4.Text = "Iniciar Sesión";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1000946;
            pictureBox1.Location = new Point(114, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 482);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCrear);
            Controls.Add(btnIngresar);
            Controls.Add(chkMostrar);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "INICIO SESION";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private CheckBox chkMostrar;
        private Button btnIngresar;
        private Button btnCrear;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
    }
}

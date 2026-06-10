namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class CambioContraseña
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
            txtConfirNuevaContraseña = new TextBox();
            txtContraseñaNueva = new TextBox();
            txtContraseñaActual = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCambiarContraseña = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtConfirNuevaContraseña
            // 
            txtConfirNuevaContraseña.BackColor = SystemColors.ScrollBar;
            txtConfirNuevaContraseña.Location = new Point(383, 329);
            txtConfirNuevaContraseña.Name = "txtConfirNuevaContraseña";
            txtConfirNuevaContraseña.Size = new Size(281, 23);
            txtConfirNuevaContraseña.TabIndex = 6;
            txtConfirNuevaContraseña.TextChanged += textBox3_TextChanged;
            // 
            // txtContraseñaNueva
            // 
            txtContraseñaNueva.BackColor = SystemColors.ScrollBar;
            txtContraseñaNueva.Location = new Point(383, 259);
            txtContraseñaNueva.Name = "txtContraseñaNueva";
            txtContraseñaNueva.Size = new Size(281, 23);
            txtContraseñaNueva.TabIndex = 5;
            // 
            // txtContraseñaActual
            // 
            txtContraseñaActual.BackColor = SystemColors.ScrollBar;
            txtContraseñaActual.Location = new Point(383, 192);
            txtContraseñaActual.Name = "txtContraseñaActual";
            txtContraseñaActual.Size = new Size(281, 23);
            txtContraseñaActual.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(383, 307);
            label3.Name = "label3";
            label3.Size = new Size(187, 19);
            label3.TabIndex = 3;
            label3.Text = "Confirmar Nueva Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(383, 237);
            label2.Name = "label2";
            label2.Size = new Size(122, 19);
            label2.TabIndex = 2;
            label2.Text = "Nueva Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(383, 170);
            label1.Name = "label1";
            label1.Size = new Size(121, 19);
            label1.TabIndex = 1;
            label1.Text = "Contraseña Actual";
            // 
            // btnCambiarContraseña
            // 
            btnCambiarContraseña.BackColor = SystemColors.ActiveCaption;
            btnCambiarContraseña.Font = new Font("Segoe UI", 10F);
            btnCambiarContraseña.Location = new Point(383, 395);
            btnCambiarContraseña.Name = "btnCambiarContraseña";
            btnCambiarContraseña.Size = new Size(281, 30);
            btnCambiarContraseña.TabIndex = 0;
            btnCambiarContraseña.Text = "Actualizar Contraseña";
            btnCambiarContraseña.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(441, 118);
            label4.Name = "label4";
            label4.Size = new Size(164, 21);
            label4.TabIndex = 7;
            label4.Text = "Cambiar Contraseña";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.illustration_of_change_password_symbol_editable_icon_design_for_user_interface_element_vector_removebg_preview;
            pictureBox1.Location = new Point(459, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(129, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // CambioContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 501);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(txtContraseñaActual);
            Controls.Add(txtContraseñaNueva);
            Controls.Add(label2);
            Controls.Add(txtConfirNuevaContraseña);
            Controls.Add(label3);
            Controls.Add(btnCambiarContraseña);
            Name = "CambioContraseña";
            Text = "CambioContraseña";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtConfirNuevaContraseña;
        private TextBox txtContraseñaNueva;
        private TextBox txtContraseñaActual;
        public Button btnCambiarContraseña;
        private Label label4;
        private PictureBox pictureBox1;
    }
}
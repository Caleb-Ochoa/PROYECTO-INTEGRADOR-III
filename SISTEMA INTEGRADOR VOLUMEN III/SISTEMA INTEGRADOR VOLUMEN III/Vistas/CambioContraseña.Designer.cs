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
            groupBox1 = new GroupBox();
            btnCambiarContraseña = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtContraseñaActual = new TextBox();
            txtContraseñaNueva = new TextBox();
            txtConfirNuevaContraseña = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtConfirNuevaContraseña);
            groupBox1.Controls.Add(txtContraseñaNueva);
            groupBox1.Controls.Add(txtContraseñaActual);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnCambiarContraseña);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(204, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(385, 366);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cambio de Contraseña";
            // 
            // btnCambiarContraseña
            // 
            btnCambiarContraseña.BackColor = SystemColors.ActiveCaption;
            btnCambiarContraseña.Location = new Point(49, 276);
            btnCambiarContraseña.Name = "btnCambiarContraseña";
            btnCambiarContraseña.Size = new Size(281, 30);
            btnCambiarContraseña.TabIndex = 0;
            btnCambiarContraseña.Text = "Actualizar Contraseña";
            btnCambiarContraseña.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 44);
            label1.Name = "label1";
            label1.Size = new Size(121, 19);
            label1.TabIndex = 1;
            label1.Text = "Contraseña Actual";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 114);
            label2.Name = "label2";
            label2.Size = new Size(122, 19);
            label2.TabIndex = 2;
            label2.Text = "Nueva Contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 189);
            label3.Name = "label3";
            label3.Size = new Size(187, 19);
            label3.TabIndex = 3;
            label3.Text = "Confirmar Nueva Contraseña";
            // 
            // txtContraseñaActual
            // 
            txtContraseñaActual.Location = new Point(49, 66);
            txtContraseñaActual.Name = "txtContraseñaActual";
            txtContraseñaActual.Size = new Size(281, 25);
            txtContraseñaActual.TabIndex = 4;
            // 
            // txtContraseñaNueva
            // 
            txtContraseñaNueva.Location = new Point(49, 136);
            txtContraseñaNueva.Name = "txtContraseñaNueva";
            txtContraseñaNueva.Size = new Size(281, 25);
            txtContraseñaNueva.TabIndex = 5;
            // 
            // txtConfirNuevaContraseña
            // 
            txtConfirNuevaContraseña.Location = new Point(49, 211);
            txtConfirNuevaContraseña.Name = "txtConfirNuevaContraseña";
            txtConfirNuevaContraseña.Size = new Size(281, 25);
            txtConfirNuevaContraseña.TabIndex = 6;
            txtConfirNuevaContraseña.TextChanged += textBox3_TextChanged;
            // 
            // CambioContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "CambioContraseña";
            Text = "CambioContraseña";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCambiarContraseña;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtConfirNuevaContraseña;
        private TextBox txtContraseñaNueva;
        private TextBox txtContraseñaActual;
    }
}
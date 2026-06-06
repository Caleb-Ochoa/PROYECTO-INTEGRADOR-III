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
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCambiarContraseña);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(204, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(385, 379);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cambio de Contraseña";
            // 
            // btnCambiarContraseña
            // 
            btnCambiarContraseña.BackColor = SystemColors.ActiveCaption;
            btnCambiarContraseña.Location = new Point(98, 326);
            btnCambiarContraseña.Name = "btnCambiarContraseña";
            btnCambiarContraseña.Size = new Size(176, 30);
            btnCambiarContraseña.TabIndex = 0;
            btnCambiarContraseña.Text = "Actualizar Contraseña";
            btnCambiarContraseña.UseVisualStyleBackColor = false;
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
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCambiarContraseña;
    }
}
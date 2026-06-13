namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class GestionUsuario
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
            dgvUsuarios = new DataGridView();
            btnBuscar = new Button();
            textBox1 = new TextBox();
            btnAgregarUsuarios = new Button();
            btnLimpiarGestionUsuarios = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(0, 55);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(800, 459);
            dgvUsuarios.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.ActiveCaption;
            btnBuscar.FlatAppearance.BorderColor = Color.LightGray;
            btnBuscar.Font = new Font("Segoe UI", 10F);
            btnBuscar.Location = new Point(248, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 30);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(22, 22);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Buscar usuario...";
            textBox1.Size = new Size(220, 23);
            textBox1.TabIndex = 1;
            // 
            // btnAgregarUsuarios
            // 
            btnAgregarUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarUsuarios.BackColor = Color.Blue;
            btnAgregarUsuarios.FlatStyle = FlatStyle.Flat;
            btnAgregarUsuarios.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnAgregarUsuarios.ForeColor = Color.White;
            btnAgregarUsuarios.Location = new Point(620, 12);
            btnAgregarUsuarios.Name = "btnAgregarUsuarios";
            btnAgregarUsuarios.Size = new Size(160, 39);
            btnAgregarUsuarios.TabIndex = 4;
            btnAgregarUsuarios.Text = "+ Agregar Usuario";
            btnAgregarUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarGestionUsuarios
            // 
            btnLimpiarGestionUsuarios.BackColor = SystemColors.ActiveCaption;
            btnLimpiarGestionUsuarios.FlatAppearance.BorderColor = Color.LightGray;
            btnLimpiarGestionUsuarios.Font = new Font("Segoe UI", 10F);
            btnLimpiarGestionUsuarios.Location = new Point(329, 15);
            btnLimpiarGestionUsuarios.Name = "btnLimpiarGestionUsuarios";
            btnLimpiarGestionUsuarios.Size = new Size(75, 30);
            btnLimpiarGestionUsuarios.TabIndex = 5;
            btnLimpiarGestionUsuarios.Text = "Limpiar";
            btnLimpiarGestionUsuarios.UseVisualStyleBackColor = false;
            // 
            // GestionUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 528);
            Controls.Add(btnLimpiarGestionUsuarios);
            Controls.Add(btnAgregarUsuarios);
            Controls.Add(btnBuscar);
            Controls.Add(dgvUsuarios);
            Controls.Add(textBox1);
            Name = "GestionUsuario";
            Text = "GestionUsuario";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public DataGridView dgvUsuarios;
        public Button btnBuscar;
        public TextBox textBox1;
        public Button btnAgregarUsuarios;
        public Button btnLimpiarGestionUsuarios;
    }
}
namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class Clientes
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
            dataGridView1 = new DataGridView();
            txtBuscarCliente = new TextBox();
            btnBuscarCliente = new Button();
            btnLimpiarFiltro = new Button();
            btnAgregarCliente = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(800, 459);
            dataGridView1.TabIndex = 0;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(20, 15);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.PlaceholderText = "Buscar cliente...";
            txtBuscarCliente.Size = new Size(220, 23);
            txtBuscarCliente.TabIndex = 1;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.WhiteSmoke;
            btnBuscarCliente.FlatAppearance.BorderColor = Color.LightGray;
            btnBuscarCliente.FlatStyle = FlatStyle.Flat;
            btnBuscarCliente.Location = new Point(248, 14);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(36, 30);
            btnBuscarCliente.TabIndex = 2;
            btnBuscarCliente.Text = "🔍";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarFiltro
            // 
            btnLimpiarFiltro.BackColor = Color.WhiteSmoke;
            btnLimpiarFiltro.FlatAppearance.BorderColor = Color.LightGray;
            btnLimpiarFiltro.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltro.Location = new Point(290, 14);
            btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            btnLimpiarFiltro.Size = new Size(36, 30);
            btnLimpiarFiltro.TabIndex = 3;
            btnLimpiarFiltro.Text = "✕";
            btnLimpiarFiltro.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarCliente.BackColor = Color.FromArgb(37, 99, 235);
            btnAgregarCliente.FlatStyle = FlatStyle.Flat;
            btnAgregarCliente.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnAgregarCliente.ForeColor = Color.White;
            btnAgregarCliente.Location = new Point(620, 12);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(160, 34);
            btnAgregarCliente.TabIndex = 4;
            btnAgregarCliente.Text = "+ Agregar Cliente";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 514);
            Controls.Add(btnAgregarCliente);
            Controls.Add(btnLimpiarFiltro);
            Controls.Add(btnBuscarCliente);
            Controls.Add(txtBuscarCliente);
            Controls.Add(dataGridView1);
            Name = "Clientes";
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public DataGridView dataGridView1;
        public TextBox txtBuscarCliente;
        public Button btnBuscarCliente;
        public Button btnLimpiarFiltro;
        public Button btnAgregarCliente;
    }
}
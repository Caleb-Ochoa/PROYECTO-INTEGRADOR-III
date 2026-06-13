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
            dvgClientes = new DataGridView();
            txtBuscarCliente = new TextBox();
            btnBuscarCliente = new Button();
            btnLimpiarFiltro = new Button();
            btnAgregarCliente = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgClientes).BeginInit();
            SuspendLayout();
            // 
            // dvgClientes
            // 
            dvgClientes.AllowUserToAddRows = false;
            dvgClientes.AllowUserToDeleteRows = false;
            dvgClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dvgClientes.BackgroundColor = Color.White;
            dvgClientes.BorderStyle = BorderStyle.None;
            dvgClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgClientes.Location = new Point(0, 62);
            dvgClientes.Name = "dvgClientes";
            dvgClientes.ReadOnly = true;
            dvgClientes.RowHeadersVisible = false;
            dvgClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgClientes.Size = new Size(800, 520);
            dvgClientes.TabIndex = 0;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.BackColor = SystemColors.ScrollBar;
            txtBuscarCliente.Location = new Point(22, 22);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.PlaceholderText = "Buscar cliente...";
            txtBuscarCliente.Size = new Size(220, 25);
            txtBuscarCliente.TabIndex = 1;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = SystemColors.ActiveCaption;
            btnBuscarCliente.FlatAppearance.BorderColor = Color.LightGray;
            btnBuscarCliente.Font = new Font("Segoe UI", 10F);
            btnBuscarCliente.Location = new Point(248, 16);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(75, 30);
            btnBuscarCliente.TabIndex = 2;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarFiltro
            // 
            btnLimpiarFiltro.BackColor = SystemColors.ActiveCaption;
            btnLimpiarFiltro.FlatAppearance.BorderColor = Color.LightGray;
            btnLimpiarFiltro.Font = new Font("Segoe UI", 10F);
            btnLimpiarFiltro.Location = new Point(336, 16);
            btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            btnLimpiarFiltro.Size = new Size(75, 30);
            btnLimpiarFiltro.TabIndex = 3;
            btnLimpiarFiltro.Text = "Limpiar";
            btnLimpiarFiltro.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarCliente.BackColor = Color.Blue;
            btnAgregarCliente.FlatStyle = FlatStyle.Flat;
            btnAgregarCliente.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnAgregarCliente.ForeColor = Color.White;
            btnAgregarCliente.Location = new Point(620, 14);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(160, 39);
            btnAgregarCliente.TabIndex = 4;
            btnAgregarCliente.Text = "+ Agregar Cliente";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(800, 583);
            Controls.Add(btnAgregarCliente);
            Controls.Add(btnLimpiarFiltro);
            Controls.Add(btnBuscarCliente);
            Controls.Add(txtBuscarCliente);
            Controls.Add(dvgClientes);
            Font = new Font("Segoe UI", 10F);
            Name = "Clientes";
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)dvgClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public DataGridView dvgClientes;
        public TextBox txtBuscarCliente;
        public Button btnBuscarCliente;
        public Button btnLimpiarFiltro;
        public Button btnAgregarCliente;
    }
}
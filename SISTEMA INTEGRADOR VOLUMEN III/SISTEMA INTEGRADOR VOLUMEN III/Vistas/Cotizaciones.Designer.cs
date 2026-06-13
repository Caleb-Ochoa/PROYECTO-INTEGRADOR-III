namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class Cotizaciones
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
            dvgCotizaciones = new DataGridView();
            txtBuscarCotizaciones = new TextBox();
            btnBuscarCotizaciones = new Button();
            btnLimpiarCotizaciones = new Button();
            btnAgregarCotizacion = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgCotizaciones).BeginInit();
            SuspendLayout();
            // 
            // dvgCotizaciones
            // 
            dvgCotizaciones.AllowUserToAddRows = false;
            dvgCotizaciones.AllowUserToDeleteRows = false;
            dvgCotizaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dvgCotizaciones.BackgroundColor = Color.White;
            dvgCotizaciones.BorderStyle = BorderStyle.None;
            dvgCotizaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgCotizaciones.Location = new Point(0, 62);
            dvgCotizaciones.Name = "dvgCotizaciones";
            dvgCotizaciones.ReadOnly = true;
            dvgCotizaciones.RowHeadersVisible = false;
            dvgCotizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgCotizaciones.Size = new Size(800, 520);
            dvgCotizaciones.TabIndex = 0;
            // 
            // txtBuscarCotizaciones
            // 
            txtBuscarCotizaciones.BackColor = SystemColors.ScrollBar;
            txtBuscarCotizaciones.Location = new Point(22, 22);
            txtBuscarCotizaciones.Name = "txtBuscarCotizaciones";
            txtBuscarCotizaciones.Size = new Size(220, 23);
            txtBuscarCotizaciones.TabIndex = 1;
            // 
            // btnBuscarCotizaciones
            // 
            btnBuscarCotizaciones.BackColor = SystemColors.ActiveCaption;
            btnBuscarCotizaciones.FlatStyle = FlatStyle.Flat;
            btnBuscarCotizaciones.Font = new Font("Segoe UI", 10F);
            btnBuscarCotizaciones.Location = new Point(248, 18);
            btnBuscarCotizaciones.Name = "btnBuscarCotizaciones";
            btnBuscarCotizaciones.Size = new Size(40, 27);
            btnBuscarCotizaciones.TabIndex = 2;
            btnBuscarCotizaciones.Text = "🔍";
            btnBuscarCotizaciones.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarCotizaciones
            // 
            btnLimpiarCotizaciones.BackColor = SystemColors.ActiveCaption;
            btnLimpiarCotizaciones.FlatStyle = FlatStyle.Flat;
            btnLimpiarCotizaciones.Font = new Font("Segoe UI", 10F);
            btnLimpiarCotizaciones.Location = new Point(294, 18);
            btnLimpiarCotizaciones.Name = "btnLimpiarCotizaciones";
            btnLimpiarCotizaciones.Size = new Size(35, 27);
            btnLimpiarCotizaciones.TabIndex = 3;
            btnLimpiarCotizaciones.Text = "✕";
            btnLimpiarCotizaciones.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCotizacion
            // 
            btnAgregarCotizacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarCotizacion.BackColor = Color.Blue;
            btnAgregarCotizacion.FlatStyle = FlatStyle.Flat;
            btnAgregarCotizacion.ForeColor = Color.White;
            btnAgregarCotizacion.Location = new Point(620, 14);
            btnAgregarCotizacion.Name = "btnAgregarCotizacion";
            btnAgregarCotizacion.Size = new Size(160, 39);
            btnAgregarCotizacion.TabIndex = 4;
            btnAgregarCotizacion.Text = "+ Agregar Cotización";
            btnAgregarCotizacion.UseVisualStyleBackColor = false;
            // 
            // Cotizaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(800, 583);
            Controls.Add(btnAgregarCotizacion);
            Controls.Add(btnLimpiarCotizaciones);
            Controls.Add(btnBuscarCotizaciones);
            Controls.Add(txtBuscarCotizaciones);
            Controls.Add(dvgCotizaciones);
            Name = "Cotizaciones";
            Text = "Cotizaciones";
            ((System.ComponentModel.ISupportInitialize)dvgCotizaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public DataGridView dvgCotizaciones;
        public TextBox txtBuscarCotizaciones;
        public Button btnAgregarCotizacion;
        public Button btnBuscarCotizaciones;
        public Button btnLimpiarCotizaciones;
    }
}
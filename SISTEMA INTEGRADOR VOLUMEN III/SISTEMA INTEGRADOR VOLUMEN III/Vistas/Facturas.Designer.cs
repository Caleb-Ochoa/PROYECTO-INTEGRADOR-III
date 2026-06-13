namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class Facturas
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
            dvgFacturas = new DataGridView();
            txtBuscarFacturas = new TextBox();
            btnBuscarFacturas = new Button();
            btnLimpiarFacturas = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgFacturas).BeginInit();
            SuspendLayout();
            // 
            // dvgFacturas
            // 
            dvgFacturas.AllowUserToAddRows = false;
            dvgFacturas.AllowUserToDeleteRows = false;
            dvgFacturas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dvgFacturas.BackgroundColor = Color.White;
            dvgFacturas.BorderStyle = BorderStyle.None;
            dvgFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgFacturas.Location = new Point(0, 62);
            dvgFacturas.Name = "dvgFacturas";
            dvgFacturas.ReadOnly = true;
            dvgFacturas.Size = new Size(800, 520);
            dvgFacturas.TabIndex = 1;
            // 
            // txtBuscarFacturas
            // 
            txtBuscarFacturas.BackColor = SystemColors.ScrollBar;
            txtBuscarFacturas.Location = new Point(31, 21);
            txtBuscarFacturas.Name = "txtBuscarFacturas";
            txtBuscarFacturas.Size = new Size(220, 23);
            txtBuscarFacturas.TabIndex = 2;
            // 
            // btnBuscarFacturas
            // 
            btnBuscarFacturas.BackColor = SystemColors.ActiveCaption;
            btnBuscarFacturas.Location = new Point(257, 21);
            btnBuscarFacturas.Name = "btnBuscarFacturas";
            btnBuscarFacturas.Size = new Size(75, 30);
            btnBuscarFacturas.TabIndex = 3;
            btnBuscarFacturas.Text = "Buscar";
            btnBuscarFacturas.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarFacturas
            // 
            btnLimpiarFacturas.BackColor = SystemColors.ActiveCaption;
            btnLimpiarFacturas.Location = new Point(338, 21);
            btnLimpiarFacturas.Name = "btnLimpiarFacturas";
            btnLimpiarFacturas.Size = new Size(75, 30);
            btnLimpiarFacturas.TabIndex = 4;
            btnLimpiarFacturas.Text = "Limpiar";
            btnLimpiarFacturas.UseVisualStyleBackColor = false;
            // 
            // Facturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(800, 583);
            Controls.Add(btnLimpiarFacturas);
            Controls.Add(btnBuscarFacturas);
            Controls.Add(txtBuscarFacturas);
            Controls.Add(dvgFacturas);
            Name = "Facturas";
            Text = "Facturas";
            ((System.ComponentModel.ISupportInitialize)dvgFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Button btnBuscarFacturas;
        public Button btnLimpiarFacturas;
        public TextBox txtBuscarFacturas;
        public DataGridView dvgFacturas;
    }
}
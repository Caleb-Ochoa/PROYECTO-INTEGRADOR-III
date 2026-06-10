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
            label1 = new Label();
            dvgFacturas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dvgFacturas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(22, 22);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 0;
            label1.Text = "Facturas";
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
            // Facturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(800, 583);
            Controls.Add(dvgFacturas);
            Controls.Add(label1);
            Name = "Facturas";
            Text = "Facturas";
            ((System.ComponentModel.ISupportInitialize)dvgFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dvgFacturas;
    }
}
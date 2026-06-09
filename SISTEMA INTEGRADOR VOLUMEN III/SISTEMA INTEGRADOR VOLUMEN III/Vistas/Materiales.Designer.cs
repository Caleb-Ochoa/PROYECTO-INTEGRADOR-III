namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class Materiales
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
            btnLimpiarMaterial = new Button();
            btnGuardarMaterial = new Button();
            txtCostoMaterial = new TextBox();
            txtNombreMaterial = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            btnLimpiarMateriales = new Button();
            btnBuscarMateriales = new Button();
            txtBuscarMateriales = new TextBox();
            label3 = new Label();
            panelmateriales = new Panel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelmateriales.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLimpiarMaterial);
            groupBox1.Controls.Add(btnGuardarMaterial);
            groupBox1.Controls.Add(txtCostoMaterial);
            groupBox1.Controls.Add(txtNombreMaterial);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(10, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(779, 136);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Material";
            // 
            // btnLimpiarMaterial
            // 
            btnLimpiarMaterial.BackColor = SystemColors.ActiveCaption;
            btnLimpiarMaterial.Location = new Point(678, 95);
            btnLimpiarMaterial.Name = "btnLimpiarMaterial";
            btnLimpiarMaterial.Size = new Size(75, 30);
            btnLimpiarMaterial.TabIndex = 5;
            btnLimpiarMaterial.Text = "Limpiar";
            btnLimpiarMaterial.UseVisualStyleBackColor = false;
            // 
            // btnGuardarMaterial
            // 
            btnGuardarMaterial.BackColor = SystemColors.ActiveCaption;
            btnGuardarMaterial.Location = new Point(587, 95);
            btnGuardarMaterial.Name = "btnGuardarMaterial";
            btnGuardarMaterial.Size = new Size(75, 30);
            btnGuardarMaterial.TabIndex = 4;
            btnGuardarMaterial.Text = "Guardar";
            btnGuardarMaterial.UseVisualStyleBackColor = false;
            // 
            // txtCostoMaterial
            // 
            txtCostoMaterial.Location = new Point(517, 53);
            txtCostoMaterial.Name = "txtCostoMaterial";
            txtCostoMaterial.Size = new Size(236, 25);
            txtCostoMaterial.TabIndex = 3;
            // 
            // txtNombreMaterial
            // 
            txtNombreMaterial.Location = new Point(6, 53);
            txtNombreMaterial.Name = "txtNombreMaterial";
            txtNombreMaterial.Size = new Size(489, 25);
            txtNombreMaterial.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(517, 31);
            label2.Name = "label2";
            label2.Size = new Size(104, 19);
            label2.TabIndex = 1;
            label2.Text = "Costo por m^3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 31);
            label1.Name = "label1";
            label1.Size = new Size(135, 19);
            label1.TabIndex = 0;
            label1.Text = "Nombre del Material";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnLimpiarMateriales);
            groupBox2.Controls.Add(btnBuscarMateriales);
            groupBox2.Controls.Add(txtBuscarMateriales);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.Location = new Point(10, 153);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(779, 367);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Materiales Registrados";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 221);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(766, 293);
            dataGridView1.TabIndex = 4;
            // 
            // btnLimpiarMateriales
            // 
            btnLimpiarMateriales.BackColor = SystemColors.ActiveCaption;
            btnLimpiarMateriales.Location = new Point(502, 32);
            btnLimpiarMateriales.Name = "btnLimpiarMateriales";
            btnLimpiarMateriales.Size = new Size(75, 30);
            btnLimpiarMateriales.TabIndex = 3;
            btnLimpiarMateriales.Text = "Limpiar";
            btnLimpiarMateriales.UseVisualStyleBackColor = false;
            // 
            // btnBuscarMateriales
            // 
            btnBuscarMateriales.BackColor = SystemColors.ActiveCaption;
            btnBuscarMateriales.Font = new Font("Segoe UI", 10F);
            btnBuscarMateriales.Location = new Point(421, 32);
            btnBuscarMateriales.Name = "btnBuscarMateriales";
            btnBuscarMateriales.Size = new Size(75, 30);
            btnBuscarMateriales.TabIndex = 2;
            btnBuscarMateriales.Text = "Buscar";
            btnBuscarMateriales.UseVisualStyleBackColor = false;
            // 
            // txtBuscarMateriales
            // 
            txtBuscarMateriales.Location = new Point(55, 32);
            txtBuscarMateriales.Name = "txtBuscarMateriales";
            txtBuscarMateriales.Size = new Size(360, 25);
            txtBuscarMateriales.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(6, 35);
            label3.Name = "label3";
            label3.Size = new Size(52, 19);
            label3.TabIndex = 0;
            label3.Text = "Buscar:";
            // 
            // panelmateriales
            // 
            panelmateriales.Controls.Add(dataGridView1);
            panelmateriales.Controls.Add(groupBox1);
            panelmateriales.Controls.Add(groupBox2);
            panelmateriales.Dock = DockStyle.Fill;
            panelmateriales.Location = new Point(0, 0);
            panelmateriales.Name = "panelmateriales";
            panelmateriales.Size = new Size(800, 525);
            panelmateriales.TabIndex = 2;
            // 
            // Materiales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 525);
            Controls.Add(panelmateriales);
            Name = "Materiales";
            Text = "Materiales";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelmateriales.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button btnLimpiarMaterial;
        private Button btnGuardarMaterial;
        private TextBox txtCostoMaterial;
        private TextBox txtNombreMaterial;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button btnLimpiarMateriales;
        private Button btnBuscarMateriales;
        private TextBox txtBuscarMateriales;
        private Label label3;
        private Panel panelmateriales;
    }
}
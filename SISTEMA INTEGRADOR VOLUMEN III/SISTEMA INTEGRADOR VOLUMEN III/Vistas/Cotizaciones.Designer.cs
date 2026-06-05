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
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            btnLimpiarCoti = new Button();
            btnImprimirCoti = new Button();
            btnGuardaeCoti = new Button();
            cmbEstadoCoti = new ComboBox();
            label8 = new Label();
            txtCostoTotalCoti = new TextBox();
            label7 = new Label();
            txtCostoCoti = new TextBox();
            label6 = new Label();
            dtpFechaCoti = new DateTimePicker();
            label5 = new Label();
            txtVolumenCoti = new TextBox();
            label4 = new Label();
            cmbMaterialCoti = new ComboBox();
            label3 = new Label();
            cmbTerrenoCoti = new ComboBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label9 = new Label();
            cmbClientesFiltrarCoti = new ComboBox();
            label10 = new Label();
            comboBox2 = new ComboBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(800, 523);
            splitContainer1.SplitterDistance = 295;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLimpiarCoti);
            groupBox1.Controls.Add(btnImprimirCoti);
            groupBox1.Controls.Add(btnGuardaeCoti);
            groupBox1.Controls.Add(cmbEstadoCoti);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtCostoTotalCoti);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtCostoCoti);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpFechaCoti);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtVolumenCoti);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbMaterialCoti);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbTerrenoCoti);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(280, 499);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nueva Cotización";
            // 
            // btnLimpiarCoti
            // 
            btnLimpiarCoti.Location = new Point(106, 469);
            btnLimpiarCoti.Name = "btnLimpiarCoti";
            btnLimpiarCoti.Size = new Size(75, 30);
            btnLimpiarCoti.TabIndex = 18;
            btnLimpiarCoti.Text = "Limpiar";
            btnLimpiarCoti.UseVisualStyleBackColor = true;
            // 
            // btnImprimirCoti
            // 
            btnImprimirCoti.Location = new Point(172, 437);
            btnImprimirCoti.Name = "btnImprimirCoti";
            btnImprimirCoti.Size = new Size(96, 30);
            btnImprimirCoti.TabIndex = 17;
            btnImprimirCoti.Text = "Imprimir";
            btnImprimirCoti.UseVisualStyleBackColor = true;
            // 
            // btnGuardaeCoti
            // 
            btnGuardaeCoti.Location = new Point(13, 437);
            btnGuardaeCoti.Name = "btnGuardaeCoti";
            btnGuardaeCoti.Size = new Size(141, 30);
            btnGuardaeCoti.TabIndex = 16;
            btnGuardaeCoti.Text = "Guardar Cotización";
            btnGuardaeCoti.UseVisualStyleBackColor = true;
            // 
            // cmbEstadoCoti
            // 
            cmbEstadoCoti.FormattingEnabled = true;
            cmbEstadoCoti.Location = new Point(14, 396);
            cmbEstadoCoti.Name = "cmbEstadoCoti";
            cmbEstadoCoti.Size = new Size(255, 25);
            cmbEstadoCoti.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 374);
            label8.Name = "label8";
            label8.Size = new Size(50, 19);
            label8.TabIndex = 14;
            label8.Text = "Estado";
            // 
            // txtCostoTotalCoti
            // 
            txtCostoTotalCoti.Location = new Point(13, 346);
            txtCostoTotalCoti.Name = "txtCostoTotalCoti";
            txtCostoTotalCoti.Size = new Size(255, 25);
            txtCostoTotalCoti.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 324);
            label7.Name = "label7";
            label7.Size = new Size(141, 19);
            label7.TabIndex = 12;
            label7.Text = "Costo Total Calculado";
            // 
            // txtCostoCoti
            // 
            txtCostoCoti.Location = new Point(13, 296);
            txtCostoCoti.Name = "txtCostoCoti";
            txtCostoCoti.Size = new Size(255, 25);
            txtCostoCoti.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 274);
            label6.Name = "label6";
            label6.Size = new Size(98, 19);
            label6.TabIndex = 10;
            label6.Text = "Costo Unitario";
            // 
            // dtpFechaCoti
            // 
            dtpFechaCoti.Location = new Point(13, 246);
            dtpFechaCoti.Name = "dtpFechaCoti";
            dtpFechaCoti.Size = new Size(255, 25);
            dtpFechaCoti.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 224);
            label5.Name = "label5";
            label5.Size = new Size(44, 19);
            label5.TabIndex = 8;
            label5.Text = "Fecha";
            // 
            // txtVolumenCoti
            // 
            txtVolumenCoti.Location = new Point(13, 196);
            txtVolumenCoti.Name = "txtVolumenCoti";
            txtVolumenCoti.Size = new Size(255, 25);
            txtVolumenCoti.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 174);
            label4.Name = "label4";
            label4.Size = new Size(63, 19);
            label4.TabIndex = 6;
            label4.Text = "Volumen";
            // 
            // cmbMaterialCoti
            // 
            cmbMaterialCoti.FormattingEnabled = true;
            cmbMaterialCoti.Location = new Point(13, 146);
            cmbMaterialCoti.Name = "cmbMaterialCoti";
            cmbMaterialCoti.Size = new Size(255, 25);
            cmbMaterialCoti.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 124);
            label3.Name = "label3";
            label3.Size = new Size(59, 19);
            label3.TabIndex = 4;
            label3.Text = "Material";
            // 
            // cmbTerrenoCoti
            // 
            cmbTerrenoCoti.FormattingEnabled = true;
            cmbTerrenoCoti.Location = new Point(13, 96);
            cmbTerrenoCoti.Name = "cmbTerrenoCoti";
            cmbTerrenoCoti.Size = new Size(255, 25);
            cmbTerrenoCoti.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 74);
            label2.Name = "label2";
            label2.Size = new Size(55, 19);
            label2.TabIndex = 2;
            label2.Text = "Terreno";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(13, 46);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(255, 25);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 24);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(cmbClientesFiltrarCoti);
            groupBox2.Controls.Add(label9);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.Location = new Point(13, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(476, 499);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Historial de Cotizaciones";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 28);
            label9.Name = "label9";
            label9.Size = new Size(58, 19);
            label9.TabIndex = 0;
            label9.Text = "Cliente: ";
            // 
            // cmbClientesFiltrarCoti
            // 
            cmbClientesFiltrarCoti.FormattingEnabled = true;
            cmbClientesFiltrarCoti.Location = new Point(67, 25);
            cmbClientesFiltrarCoti.Name = "cmbClientesFiltrarCoti";
            cmbClientesFiltrarCoti.Size = new Size(121, 25);
            cmbClientesFiltrarCoti.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(194, 28);
            label10.Name = "label10";
            label10.Size = new Size(53, 19);
            label10.TabIndex = 2;
            label10.Text = "Estado:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(253, 25);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 25);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(380, 23);
            button1.Name = "button1";
            button1.Size = new Size(69, 30);
            button1.TabIndex = 4;
            button1.Text = "Filtrar";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(456, 434);
            dataGridView1.TabIndex = 5;
            // 
            // Cotizaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 523);
            Controls.Add(splitContainer1);
            Name = "Cotizaciones";
            Text = "Cotizaciones";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Label label1;
        private ComboBox cmbMaterialCoti;
        private Label label3;
        private ComboBox cmbTerrenoCoti;
        private Label label2;
        private TextBox txtCostoCoti;
        private Label label6;
        private DateTimePicker dtpFechaCoti;
        private Label label5;
        private TextBox txtVolumenCoti;
        private Label label4;
        private Button btnLimpiarCoti;
        private Button btnImprimirCoti;
        private Button btnGuardaeCoti;
        private ComboBox cmbEstadoCoti;
        private Label label8;
        private TextBox txtCostoTotalCoti;
        private Label label7;
        private GroupBox groupBox2;
        private ComboBox cmbClientesFiltrarCoti;
        private Label label9;
        private ComboBox comboBox2;
        private Label label10;
        private DataGridView dataGridView1;
        private Button button1;
    }
}
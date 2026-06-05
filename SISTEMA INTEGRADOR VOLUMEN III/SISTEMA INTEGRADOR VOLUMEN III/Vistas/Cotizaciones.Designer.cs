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
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            cmbTerrenoCoti = new ComboBox();
            label3 = new Label();
            cmbMaterialCoti = new ComboBox();
            label4 = new Label();
            txtVolumenCoti = new TextBox();
            label5 = new Label();
            dtpFechaCoti = new DateTimePicker();
            label6 = new Label();
            txtCostoCoti = new TextBox();
            label7 = new Label();
            txtCostoTotalCoti = new TextBox();
            label8 = new Label();
            cmbEstadoCoti = new ComboBox();
            btnGuardaeCoti = new Button();
            btnImprimirCoti = new Button();
            btnLimpiarCoti = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 24);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(13, 46);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(255, 25);
            comboBox1.TabIndex = 1;
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
            // cmbTerrenoCoti
            // 
            cmbTerrenoCoti.FormattingEnabled = true;
            cmbTerrenoCoti.Location = new Point(13, 96);
            cmbTerrenoCoti.Name = "cmbTerrenoCoti";
            cmbTerrenoCoti.Size = new Size(255, 25);
            cmbTerrenoCoti.TabIndex = 3;
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
            // cmbMaterialCoti
            // 
            cmbMaterialCoti.FormattingEnabled = true;
            cmbMaterialCoti.Location = new Point(13, 146);
            cmbMaterialCoti.Name = "cmbMaterialCoti";
            cmbMaterialCoti.Size = new Size(255, 25);
            cmbMaterialCoti.TabIndex = 5;
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
            // txtVolumenCoti
            // 
            txtVolumenCoti.Location = new Point(13, 196);
            txtVolumenCoti.Name = "txtVolumenCoti";
            txtVolumenCoti.Size = new Size(255, 25);
            txtVolumenCoti.TabIndex = 7;
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
            // dtpFechaCoti
            // 
            dtpFechaCoti.Location = new Point(13, 246);
            dtpFechaCoti.Name = "dtpFechaCoti";
            dtpFechaCoti.Size = new Size(255, 25);
            dtpFechaCoti.TabIndex = 9;
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
            // txtCostoCoti
            // 
            txtCostoCoti.Location = new Point(13, 296);
            txtCostoCoti.Name = "txtCostoCoti";
            txtCostoCoti.Size = new Size(255, 25);
            txtCostoCoti.TabIndex = 11;
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
            // txtCostoTotalCoti
            // 
            txtCostoTotalCoti.Location = new Point(13, 346);
            txtCostoTotalCoti.Name = "txtCostoTotalCoti";
            txtCostoTotalCoti.Size = new Size(255, 25);
            txtCostoTotalCoti.TabIndex = 13;
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
            // cmbEstadoCoti
            // 
            cmbEstadoCoti.FormattingEnabled = true;
            cmbEstadoCoti.Location = new Point(14, 396);
            cmbEstadoCoti.Name = "cmbEstadoCoti";
            cmbEstadoCoti.Size = new Size(255, 25);
            cmbEstadoCoti.TabIndex = 15;
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
            // btnImprimirCoti
            // 
            btnImprimirCoti.Location = new Point(172, 437);
            btnImprimirCoti.Name = "btnImprimirCoti";
            btnImprimirCoti.Size = new Size(96, 30);
            btnImprimirCoti.TabIndex = 17;
            btnImprimirCoti.Text = "Imprimir";
            btnImprimirCoti.UseVisualStyleBackColor = true;
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
            // Cotizaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 523);
            Controls.Add(splitContainer1);
            Name = "Cotizaciones";
            Text = "Cotizaciones";
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}
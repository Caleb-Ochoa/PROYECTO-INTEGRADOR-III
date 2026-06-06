namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class Terreno_y_Calculo
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
            groupBox4 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            button1 = new Button();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            btnLimpiarCoordenada = new Button();
            btnQuitarCoordenada = new Button();
            btnAgragarCoordenada = new Button();
            numeriZ = new NumericUpDown();
            numeriY = new NumericUpDown();
            numeriX = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            txtValorTerreno = new TextBox();
            cbmMaterialTerreno = new ComboBox();
            cmbClienteTerreno = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numeriZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeriY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeriX).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(groupBox4);
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(800, 524);
            splitContainer1.SplitterDistance = 335;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(button1);
            groupBox4.Font = new Font("Segoe UI", 10F);
            groupBox4.Location = new Point(12, 407);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(320, 114);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Calculo Volumen";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 48);
            label8.Name = "label8";
            label8.Size = new Size(38, 19);
            label8.TabIndex = 2;
            label8.Text = "Total";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 21);
            label7.Name = "label7";
            label7.Size = new Size(63, 19);
            label7.TabIndex = 1;
            label7.Text = "Volumen";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(6, 70);
            button1.Name = "button1";
            button1.Size = new Size(308, 30);
            button1.TabIndex = 0;
            button1.Text = "Calcular";
            button1.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Font = new Font("Segoe UI", 10F);
            groupBox3.Location = new Point(12, 272);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(320, 129);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Coordenadas del Terreno";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(308, 99);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnLimpiarCoordenada);
            groupBox2.Controls.Add(btnQuitarCoordenada);
            groupBox2.Controls.Add(btnAgragarCoordenada);
            groupBox2.Controls.Add(numeriZ);
            groupBox2.Controls.Add(numeriY);
            groupBox2.Controls.Add(numeriX);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.Location = new Point(12, 140);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(320, 126);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Agreagar Coordenadas";
            // 
            // btnLimpiarCoordenada
            // 
            btnLimpiarCoordenada.Location = new Point(213, 89);
            btnLimpiarCoordenada.Name = "btnLimpiarCoordenada";
            btnLimpiarCoordenada.Size = new Size(75, 26);
            btnLimpiarCoordenada.TabIndex = 8;
            btnLimpiarCoordenada.Text = "Limpiar";
            btnLimpiarCoordenada.UseVisualStyleBackColor = true;
            // 
            // btnQuitarCoordenada
            // 
            btnQuitarCoordenada.Location = new Point(132, 90);
            btnQuitarCoordenada.Name = "btnQuitarCoordenada";
            btnQuitarCoordenada.Size = new Size(75, 25);
            btnQuitarCoordenada.TabIndex = 7;
            btnQuitarCoordenada.Text = "Quitar";
            btnQuitarCoordenada.UseVisualStyleBackColor = true;
            // 
            // btnAgragarCoordenada
            // 
            btnAgragarCoordenada.Location = new Point(6, 89);
            btnAgragarCoordenada.Name = "btnAgragarCoordenada";
            btnAgragarCoordenada.Size = new Size(120, 26);
            btnAgragarCoordenada.TabIndex = 6;
            btnAgragarCoordenada.Text = "Agregar Punto";
            btnAgragarCoordenada.UseVisualStyleBackColor = true;
            // 
            // numeriZ
            // 
            numeriZ.Location = new Point(213, 43);
            numeriZ.Name = "numeriZ";
            numeriZ.Size = new Size(72, 25);
            numeriZ.TabIndex = 5;
            // 
            // numeriY
            // 
            numeriY.Location = new Point(109, 43);
            numeriY.Name = "numeriY";
            numeriY.Size = new Size(72, 25);
            numeriY.TabIndex = 4;
            // 
            // numeriX
            // 
            numeriX.Location = new Point(6, 43);
            numeriX.Name = "numeriX";
            numeriX.Size = new Size(74, 25);
            numeriX.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(213, 21);
            label6.Name = "label6";
            label6.Size = new Size(82, 19);
            label6.TabIndex = 2;
            label6.Text = "Z (Altura m)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(109, 21);
            label5.Name = "label5";
            label5.Size = new Size(72, 19);
            label5.TabIndex = 1;
            label5.Text = "Y (Latitud)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 21);
            label4.Name = "label4";
            label4.Size = new Size(84, 19);
            label4.TabIndex = 0;
            label4.Text = "X (Longitud)";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtValorTerreno);
            groupBox1.Controls.Add(cbmMaterialTerreno);
            groupBox1.Controls.Add(cmbClienteTerreno);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(320, 122);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Generales";
            // 
            // txtValorTerreno
            // 
            txtValorTerreno.Location = new Point(91, 91);
            txtValorTerreno.Name = "txtValorTerreno";
            txtValorTerreno.Size = new Size(204, 25);
            txtValorTerreno.TabIndex = 5;
            // 
            // cbmMaterialTerreno
            // 
            cbmMaterialTerreno.FormattingEnabled = true;
            cbmMaterialTerreno.Location = new Point(91, 59);
            cbmMaterialTerreno.Name = "cbmMaterialTerreno";
            cbmMaterialTerreno.Size = new Size(204, 25);
            cbmMaterialTerreno.TabIndex = 4;
            // 
            // cmbClienteTerreno
            // 
            cmbClienteTerreno.FormattingEnabled = true;
            cmbClienteTerreno.Location = new Point(91, 24);
            cmbClienteTerreno.Name = "cmbClienteTerreno";
            cmbClienteTerreno.Size = new Size(204, 25);
            cmbClienteTerreno.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 97);
            label3.Name = "label3";
            label3.Size = new Size(74, 19);
            label3.TabIndex = 2;
            label3.Text = "Valor m^3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 65);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 1;
            label2.Text = "Material";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // Terreno_y_Calculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 524);
            Controls.Add(splitContainer1);
            Name = "Terreno_y_Calculo";
            Text = "Terreno_y_Calculo";
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numeriZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeriY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeriX).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private TextBox txtValorTerreno;
        private ComboBox cbmMaterialTerreno;
        private ComboBox cmbClienteTerreno;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private NumericUpDown numeriX;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnLimpiarCoordenada;
        private Button btnQuitarCoordenada;
        private Button btnAgragarCoordenada;
        private NumericUpDown numeriZ;
        private NumericUpDown numeriY;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private GroupBox groupBox4;
        private Button button1;
        private Label label8;
        private Label label7;
    }
}
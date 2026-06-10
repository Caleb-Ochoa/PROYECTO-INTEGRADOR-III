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
            groupBoxDatos = new GroupBox();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            lblMaterial = new Label();
            cmbMaterial = new ComboBox();
            labelCostoMaterial = new Label();
            lblCostoMaterial = new Label();
            groupBoxCoordenadas = new GroupBox();
            lblX = new Label();
            txtXLatitud = new TextBox();
            lblYLongitud = new Label();
            txtYLongitud = new TextBox();
            lblElevacion = new Label();
            txtZElevacion = new TextBox();
            btnAgregarCoordenada = new Button();
            btnQuitarCoordenada = new Button();
            btnLimpiarCoordenada = new Button();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            lblTotalPuntos = new Label();
            groupBoxResultados = new GroupBox();
            lblVolumenTexto = new Label();
            lblVolumen = new Label();
            lblTotalTexto = new Label();
            lblTotal = new Label();
            btnCalcular = new Button();
            lblTituloGrafica = new Label();
            panelOpenGL = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxDatos.SuspendLayout();
            groupBoxCoordenadas.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBoxResultados.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(groupBoxResultados);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(groupBoxCoordenadas);
            splitContainer1.Panel1.Controls.Add(groupBoxDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelOpenGL);
            splitContainer1.Panel2.Controls.Add(lblTituloGrafica);
            splitContainer1.Size = new Size(800, 524);
            splitContainer1.SplitterDistance = 320;
            splitContainer1.TabIndex = 0;
            // 
            // groupBoxDatos
            // 
            groupBoxDatos.Controls.Add(lblCostoMaterial);
            groupBoxDatos.Controls.Add(labelCostoMaterial);
            groupBoxDatos.Controls.Add(cmbMaterial);
            groupBoxDatos.Controls.Add(lblMaterial);
            groupBoxDatos.Controls.Add(cmbCliente);
            groupBoxDatos.Controls.Add(lblCliente);
            groupBoxDatos.Location = new Point(10, 10);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new Size(300, 140);
            groupBoxDatos.TabIndex = 0;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "DATOS GENERALES";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(15, 25);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(15, 42);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(260, 23);
            cmbCliente.TabIndex = 1;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(15, 72);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(50, 15);
            lblMaterial.TabIndex = 2;
            lblMaterial.Text = "Material";
            // 
            // cmbMaterial
            // 
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(15, 89);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(260, 23);
            cmbMaterial.TabIndex = 3;
            // 
            // labelCostoMaterial
            // 
            labelCostoMaterial.AutoSize = true;
            labelCostoMaterial.Location = new Point(15, 118);
            labelCostoMaterial.Name = "labelCostoMaterial";
            labelCostoMaterial.Size = new Size(87, 15);
            labelCostoMaterial.TabIndex = 4;
            labelCostoMaterial.Text = "Costo material:";
            // 
            // lblCostoMaterial
            // 
            lblCostoMaterial.AutoSize = true;
            lblCostoMaterial.Location = new Point(110, 118);
            lblCostoMaterial.Name = "lblCostoMaterial";
            lblCostoMaterial.Size = new Size(54, 15);
            lblCostoMaterial.TabIndex = 5;
            lblCostoMaterial.Text = "$0.00/m³";
            // 
            // groupBoxCoordenadas
            // 
            groupBoxCoordenadas.Controls.Add(btnLimpiarCoordenada);
            groupBoxCoordenadas.Controls.Add(btnQuitarCoordenada);
            groupBoxCoordenadas.Controls.Add(btnAgregarCoordenada);
            groupBoxCoordenadas.Controls.Add(txtZElevacion);
            groupBoxCoordenadas.Controls.Add(lblElevacion);
            groupBoxCoordenadas.Controls.Add(txtYLongitud);
            groupBoxCoordenadas.Controls.Add(lblYLongitud);
            groupBoxCoordenadas.Controls.Add(txtXLatitud);
            groupBoxCoordenadas.Controls.Add(lblX);
            groupBoxCoordenadas.Location = new Point(10, 160);
            groupBoxCoordenadas.Name = "groupBoxCoordenadas";
            groupBoxCoordenadas.Size = new Size(300, 120);
            groupBoxCoordenadas.TabIndex = 1;
            groupBoxCoordenadas.TabStop = false;
            groupBoxCoordenadas.Text = "AGREGAR COORDENADAS";
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Location = new Point(15, 25);
            lblX.Name = "lblX";
            lblX.Size = new Size(44, 15);
            lblX.TabIndex = 0;
            lblX.Text = "Latitud";
            // 
            // txtXLatitud
            // 
            txtXLatitud.Location = new Point(15, 45);
            txtXLatitud.Name = "txtXLatitud";
            txtXLatitud.Size = new Size(75, 23);
            txtXLatitud.TabIndex = 1;
            // 
            // lblYLongitud
            // 
            lblYLongitud.AutoSize = true;
            lblYLongitud.Location = new Point(105, 25);
            lblYLongitud.Name = "lblYLongitud";
            lblYLongitud.Size = new Size(55, 15);
            lblYLongitud.TabIndex = 2;
            lblYLongitud.Text = "Longitud";
            // 
            // txtYLongitud
            // 
            txtYLongitud.Location = new Point(105, 45);
            txtYLongitud.Name = "txtYLongitud";
            txtYLongitud.Size = new Size(75, 23);
            txtYLongitud.TabIndex = 3;
            // 
            // lblElevacion
            // 
            lblElevacion.AutoSize = true;
            lblElevacion.Location = new Point(195, 25);
            lblElevacion.Name = "lblElevacion";
            lblElevacion.Size = new Size(79, 15);
            lblElevacion.TabIndex = 4;
            lblElevacion.Text = "Elevación (m)";
            // 
            // txtZElevacion
            // 
            txtZElevacion.Location = new Point(195, 45);
            txtZElevacion.Name = "txtZElevacion";
            txtZElevacion.Size = new Size(75, 23);
            txtZElevacion.TabIndex = 5;
            // 
            // btnAgregarCoordenada
            // 
            btnAgregarCoordenada.FlatStyle = FlatStyle.Flat;
            btnAgregarCoordenada.Location = new Point(10, 80);
            btnAgregarCoordenada.Name = "btnAgregarCoordenada";
            btnAgregarCoordenada.Size = new Size(92, 34);
            btnAgregarCoordenada.TabIndex = 6;
            btnAgregarCoordenada.Text = "Agregar Punto";
            btnAgregarCoordenada.UseVisualStyleBackColor = true;
            // 
            // btnQuitarCoordenada
            // 
            btnQuitarCoordenada.FlatStyle = FlatStyle.Flat;
            btnQuitarCoordenada.Location = new Point(108, 80);
            btnQuitarCoordenada.Name = "btnQuitarCoordenada";
            btnQuitarCoordenada.Size = new Size(92, 34);
            btnQuitarCoordenada.TabIndex = 7;
            btnQuitarCoordenada.Text = "Quitar Punto";
            btnQuitarCoordenada.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarCoordenada
            // 
            btnLimpiarCoordenada.FlatStyle = FlatStyle.Flat;
            btnLimpiarCoordenada.Location = new Point(206, 80);
            btnLimpiarCoordenada.Name = "btnLimpiarCoordenada";
            btnLimpiarCoordenada.Size = new Size(92, 34);
            btnLimpiarCoordenada.TabIndex = 8;
            btnLimpiarCoordenada.Text = "Limpiar Todo";
            btnLimpiarCoordenada.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTotalPuntos);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(10, 290);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 150);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "COORDENADAS DEL TERRENO";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(280, 90);
            dataGridView1.TabIndex = 0;
            // 
            // lblTotalPuntos
            // 
            lblTotalPuntos.Location = new Point(10, 120);
            lblTotalPuntos.Name = "lblTotalPuntos";
            lblTotalPuntos.Size = new Size(150, 20);
            lblTotalPuntos.TabIndex = 1;
            lblTotalPuntos.Text = "Total puntos: 0";
            // 
            // groupBoxResultados
            // 
            groupBoxResultados.Controls.Add(btnCalcular);
            groupBoxResultados.Controls.Add(lblTotal);
            groupBoxResultados.Controls.Add(lblTotalTexto);
            groupBoxResultados.Controls.Add(lblVolumen);
            groupBoxResultados.Controls.Add(lblVolumenTexto);
            groupBoxResultados.Location = new Point(10, 450);
            groupBoxResultados.Name = "groupBoxResultados";
            groupBoxResultados.Size = new Size(300, 70);
            groupBoxResultados.TabIndex = 3;
            groupBoxResultados.TabStop = false;
            groupBoxResultados.Text = "RESULTADOS";
            // 
            // lblVolumenTexto
            // 
            lblVolumenTexto.AutoSize = true;
            lblVolumenTexto.Location = new Point(15, 25);
            lblVolumenTexto.Name = "lblVolumenTexto";
            lblVolumenTexto.Size = new Size(57, 15);
            lblVolumenTexto.TabIndex = 0;
            lblVolumenTexto.Text = "Volumen:";
            // 
            // lblVolumen
            // 
            lblVolumen.Location = new Point(80, 25);
            lblVolumen.Name = "lblVolumen";
            lblVolumen.Size = new Size(80, 20);
            lblVolumen.TabIndex = 1;
            lblVolumen.Text = "0.00 m³";
            // 
            // lblTotalTexto
            // 
            lblTotalTexto.AutoSize = true;
            lblTotalTexto.Location = new Point(15, 45);
            lblTotalTexto.Name = "lblTotalTexto";
            lblTotalTexto.Size = new Size(35, 15);
            lblTotalTexto.TabIndex = 2;
            lblTotalTexto.Text = "Total:";
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(80, 45);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 20);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "$0.00";
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(190, 18);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(95, 40);
            btnCalcular.TabIndex = 4;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            // 
            // lblTituloGrafica
            // 
            lblTituloGrafica.Location = new Point(10, 10);
            lblTituloGrafica.Name = "lblTituloGrafica";
            lblTituloGrafica.Size = new Size(250, 20);
            lblTituloGrafica.TabIndex = 0;
            lblTituloGrafica.Text = "Visualización 3D del Terreno";
            // 
            // panelOpenGL
            // 
            panelOpenGL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelOpenGL.Location = new Point(10, 40);
            panelOpenGL.Name = "panelOpenGL";
            panelOpenGL.Size = new Size(455, 470);
            panelOpenGL.TabIndex = 1;
            // 
            // Terreno_y_Calculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(800, 524);
            Controls.Add(splitContainer1);
            Name = "Terreno_y_Calculo";
            Text = "Terreno_y_Calculo";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxDatos.ResumeLayout(false);
            groupBoxDatos.PerformLayout();
            groupBoxCoordenadas.ResumeLayout(false);
            groupBoxCoordenadas.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBoxResultados.ResumeLayout(false);
            groupBoxResultados.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBoxDatos;
        private Label labelCostoMaterial;
        private ComboBox cmbMaterial;
        private Label lblMaterial;
        private ComboBox cmbCliente;
        private Label lblCliente;
        private Label lblCostoMaterial;
        private GroupBox groupBoxCoordenadas;
        private TextBox txtXLatitud;
        private Label lblX;
        private TextBox txtZElevacion;
        private Label lblElevacion;
        private TextBox txtYLongitud;
        private Label lblYLongitud;
        private Button btnLimpiarCoordenada;
        private Button btnQuitarCoordenada;
        private Button btnAgregarCoordenada;
        private GroupBox groupBox1;
        private Label lblTotalPuntos;
        private DataGridView dataGridView1;
        private GroupBox groupBoxResultados;
        private Label lblVolumenTexto;
        private Button btnCalcular;
        private Label lblTotal;
        private Label lblTotalTexto;
        private Label lblVolumen;
        private Panel panelOpenGL;
        private Label lblTituloGrafica;
    }
}
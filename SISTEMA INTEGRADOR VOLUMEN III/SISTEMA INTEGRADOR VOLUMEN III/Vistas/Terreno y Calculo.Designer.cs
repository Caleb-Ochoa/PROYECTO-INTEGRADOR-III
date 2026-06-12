namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class Terreno_y_Calculo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            groupBoxResultados = new GroupBox();
            btnGuardarTerreno = new Button();
            btnCalcular = new Button();
            lblTotal = new Label();
            lblTotalTexto = new Label();
            lblVolumen = new Label();
            lblVolumenTexto = new Label();
            groupBox1 = new GroupBox();
            lblTotalPuntos = new Label();
            dataGridView1 = new DataGridView();
            groupBoxCoordenadas = new GroupBox();
            btnLimpiarCoordenada = new Button();
            btnQuitarCoordenada = new Button();
            btnAgregarCoordenada = new Button();
            txtZElevacion = new TextBox();
            lblElevacion = new Label();
            txtYLongitud = new TextBox();
            lblYLongitud = new Label();
            txtXLatitud = new TextBox();
            lblX = new Label();
            groupBoxDatos = new GroupBox();
            txtNombreTerreno = new TextBox();
            lblNombreTerreno = new Label();
            lblCostoMaterial = new Label();
            labelCostoMaterial = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            cmbCliente = new ComboBox();
            lblCliente = new Label();
            lblTituloGrafica = new Label();
            panelOpenGL = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxResultados.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBoxCoordenadas.SuspendLayout();
            groupBoxDatos.SuspendLayout();
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
            splitContainer1.Panel2.Controls.Add(lblTituloGrafica);
            splitContainer1.Panel2.Controls.Add(panelOpenGL);
            splitContainer1.Size = new Size(800, 532);
            splitContainer1.SplitterDistance = 320;
            splitContainer1.TabIndex = 0;
            // 
            // groupBoxResultados
            // 
            groupBoxResultados.Controls.Add(btnGuardarTerreno);
            groupBoxResultados.Controls.Add(btnCalcular);
            groupBoxResultados.Controls.Add(lblTotal);
            groupBoxResultados.Controls.Add(lblTotalTexto);
            groupBoxResultados.Controls.Add(lblVolumen);
            groupBoxResultados.Controls.Add(lblVolumenTexto);
            groupBoxResultados.Location = new Point(10, 431);
            groupBoxResultados.Name = "groupBoxResultados";
            groupBoxResultados.Size = new Size(300, 98);
            groupBoxResultados.TabIndex = 3;
            groupBoxResultados.TabStop = false;
            groupBoxResultados.Text = "RESULTADOS";
            // 
            // btnGuardarTerreno
            // 
            btnGuardarTerreno.BackColor = SystemColors.ActiveCaption;
            btnGuardarTerreno.FlatStyle = FlatStyle.Flat;
            btnGuardarTerreno.Location = new Point(122, 63);
            btnGuardarTerreno.Name = "btnGuardarTerreno";
            btnGuardarTerreno.Size = new Size(119, 27);
            btnGuardarTerreno.TabIndex = 9;
            btnGuardarTerreno.Text = "Guardar Terreno";
            btnGuardarTerreno.UseVisualStyleBackColor = false;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = SystemColors.ActiveCaption;
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Location = new Point(6, 63);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(95, 27);
            btnCalcular.TabIndex = 4;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(80, 45);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(80, 20);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "$0.00";
            // 
            // lblTotalTexto
            // 
            lblTotalTexto.AutoSize = true;
            lblTotalTexto.Location = new Point(15, 45);
            lblTotalTexto.Name = "lblTotalTexto";
            lblTotalTexto.Size = new Size(35, 15);
            lblTotalTexto.TabIndex = 6;
            lblTotalTexto.Text = "Total:";
            // 
            // lblVolumen
            // 
            lblVolumen.Location = new Point(80, 25);
            lblVolumen.Name = "lblVolumen";
            lblVolumen.Size = new Size(100, 20);
            lblVolumen.TabIndex = 7;
            lblVolumen.Text = "0.00 m³";
            // 
            // lblVolumenTexto
            // 
            lblVolumenTexto.AutoSize = true;
            lblVolumenTexto.Location = new Point(15, 25);
            lblVolumenTexto.Name = "lblVolumenTexto";
            lblVolumenTexto.Size = new Size(57, 15);
            lblVolumenTexto.TabIndex = 8;
            lblVolumenTexto.Text = "Volumen:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTotalPuntos);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(10, 275);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 150);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "COORDENADAS DEL TERRENO";
            // 
            // lblTotalPuntos
            // 
            lblTotalPuntos.Location = new Point(10, 128);
            lblTotalPuntos.Name = "lblTotalPuntos";
            lblTotalPuntos.Size = new Size(150, 20);
            lblTotalPuntos.TabIndex = 0;
            lblTotalPuntos.Text = "Total puntos: 0";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(280, 100);
            dataGridView1.TabIndex = 0;
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
            groupBoxCoordenadas.Location = new Point(10, 149);
            groupBoxCoordenadas.Name = "groupBoxCoordenadas";
            groupBoxCoordenadas.Size = new Size(300, 120);
            groupBoxCoordenadas.TabIndex = 1;
            groupBoxCoordenadas.TabStop = false;
            groupBoxCoordenadas.Text = "AGREGAR COORDENADAS";
            // 
            // btnLimpiarCoordenada
            // 
            btnLimpiarCoordenada.BackColor = SystemColors.ActiveCaption;
            btnLimpiarCoordenada.FlatStyle = FlatStyle.Flat;
            btnLimpiarCoordenada.Location = new Point(198, 78);
            btnLimpiarCoordenada.Name = "btnLimpiarCoordenada";
            btnLimpiarCoordenada.Size = new Size(88, 30);
            btnLimpiarCoordenada.TabIndex = 5;
            btnLimpiarCoordenada.Text = "Limpiar";
            btnLimpiarCoordenada.UseVisualStyleBackColor = false;
            // 
            // btnQuitarCoordenada
            // 
            btnQuitarCoordenada.BackColor = SystemColors.ActiveCaption;
            btnQuitarCoordenada.FlatStyle = FlatStyle.Flat;
            btnQuitarCoordenada.Location = new Point(104, 78);
            btnQuitarCoordenada.Name = "btnQuitarCoordenada";
            btnQuitarCoordenada.Size = new Size(88, 30);
            btnQuitarCoordenada.TabIndex = 4;
            btnQuitarCoordenada.Text = "Quitar";
            btnQuitarCoordenada.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCoordenada
            // 
            btnAgregarCoordenada.BackColor = SystemColors.ActiveCaption;
            btnAgregarCoordenada.FlatStyle = FlatStyle.Flat;
            btnAgregarCoordenada.Location = new Point(10, 78);
            btnAgregarCoordenada.Name = "btnAgregarCoordenada";
            btnAgregarCoordenada.Size = new Size(88, 30);
            btnAgregarCoordenada.TabIndex = 3;
            btnAgregarCoordenada.Text = "Agregar";
            btnAgregarCoordenada.UseVisualStyleBackColor = false;
            // 
            // txtZElevacion
            // 
            txtZElevacion.Location = new Point(190, 42);
            txtZElevacion.Name = "txtZElevacion";
            txtZElevacion.Size = new Size(80, 23);
            txtZElevacion.TabIndex = 2;
            // 
            // lblElevacion
            // 
            lblElevacion.AutoSize = true;
            lblElevacion.Location = new Point(190, 25);
            lblElevacion.Name = "lblElevacion";
            lblElevacion.Size = new Size(71, 15);
            lblElevacion.TabIndex = 6;
            lblElevacion.Text = "Z (Altura m)";
            // 
            // txtYLongitud
            // 
            txtYLongitud.Location = new Point(100, 42);
            txtYLongitud.Name = "txtYLongitud";
            txtYLongitud.Size = new Size(80, 23);
            txtYLongitud.TabIndex = 1;
            // 
            // lblYLongitud
            // 
            lblYLongitud.AutoSize = true;
            lblYLongitud.Location = new Point(100, 25);
            lblYLongitud.Name = "lblYLongitud";
            lblYLongitud.Size = new Size(62, 15);
            lblYLongitud.TabIndex = 7;
            lblYLongitud.Text = "Y (Latitud)";
            // 
            // txtXLatitud
            // 
            txtXLatitud.Location = new Point(10, 42);
            txtXLatitud.Name = "txtXLatitud";
            txtXLatitud.Size = new Size(80, 23);
            txtXLatitud.TabIndex = 0;
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Location = new Point(10, 25);
            lblX.Name = "lblX";
            lblX.Size = new Size(73, 15);
            lblX.TabIndex = 8;
            lblX.Text = "X (Longitud)";
            // 
            // groupBoxDatos
            // 
            groupBoxDatos.Controls.Add(txtNombreTerreno);
            groupBoxDatos.Controls.Add(lblNombreTerreno);
            groupBoxDatos.Controls.Add(lblCostoMaterial);
            groupBoxDatos.Controls.Add(labelCostoMaterial);
            groupBoxDatos.Controls.Add(cmbMaterial);
            groupBoxDatos.Controls.Add(lblMaterial);
            groupBoxDatos.Controls.Add(cmbCliente);
            groupBoxDatos.Controls.Add(lblCliente);
            groupBoxDatos.Location = new Point(10, 10);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new Size(300, 133);
            groupBoxDatos.TabIndex = 0;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "DATOS GENERALES";
            // 
            // txtNombreTerreno
            // 
            txtNombreTerreno.Location = new Point(130, 78);
            txtNombreTerreno.Name = "txtNombreTerreno";
            txtNombreTerreno.Size = new Size(155, 23);
            txtNombreTerreno.TabIndex = 6;
            // 
            // lblNombreTerreno
            // 
            lblNombreTerreno.AutoSize = true;
            lblNombreTerreno.Location = new Point(15, 82);
            lblNombreTerreno.Name = "lblNombreTerreno";
            lblNombreTerreno.Size = new Size(96, 15);
            lblNombreTerreno.TabIndex = 5;
            lblNombreTerreno.Text = "Nombre Terreno:";
            // 
            // lblCostoMaterial
            // 
            lblCostoMaterial.AutoSize = true;
            lblCostoMaterial.Location = new Point(108, 112);
            lblCostoMaterial.Name = "lblCostoMaterial";
            lblCostoMaterial.Size = new Size(54, 15);
            lblCostoMaterial.TabIndex = 0;
            lblCostoMaterial.Text = "$0.00/m³";
            // 
            // labelCostoMaterial
            // 
            labelCostoMaterial.AutoSize = true;
            labelCostoMaterial.Location = new Point(15, 112);
            labelCostoMaterial.Name = "labelCostoMaterial";
            labelCostoMaterial.Size = new Size(87, 15);
            labelCostoMaterial.TabIndex = 1;
            labelCostoMaterial.Text = "Costo material:";
            // 
            // cmbMaterial
            // 
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(150, 42);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(135, 23);
            cmbMaterial.TabIndex = 2;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(150, 25);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(50, 15);
            lblMaterial.TabIndex = 3;
            lblMaterial.Text = "Material";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(15, 42);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(125, 23);
            cmbCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(15, 25);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 4;
            lblCliente.Text = "Cliente";
            // 
            // lblTituloGrafica
            // 
            lblTituloGrafica.Location = new Point(3, 9);
            lblTituloGrafica.Name = "lblTituloGrafica";
            lblTituloGrafica.Size = new Size(250, 20);
            lblTituloGrafica.TabIndex = 2;
            lblTituloGrafica.Text = "Visualización 3D del Terreno";
            // 
            // panelOpenGL
            // 
            panelOpenGL.Location = new Point(3, 32);
            panelOpenGL.Name = "panelOpenGL";
            panelOpenGL.Size = new Size(470, 488);
            panelOpenGL.TabIndex = 1;
            // 
            // Terreno_y_Calculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 532);
            Controls.Add(splitContainer1);
            Name = "Terreno_y_Calculo";
            Text = "Terreno y Cálculo";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxResultados.ResumeLayout(false);
            groupBoxResultados.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBoxCoordenadas.ResumeLayout(false);
            groupBoxCoordenadas.PerformLayout();
            groupBoxDatos.ResumeLayout(false);
            groupBoxDatos.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label labelCostoMaterial;
        private System.Windows.Forms.Label lblCostoMaterial;
        private System.Windows.Forms.GroupBox groupBoxCoordenadas;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TextBox txtXLatitud;
        private System.Windows.Forms.Label lblYLongitud;
        private System.Windows.Forms.TextBox txtYLongitud;
        private System.Windows.Forms.Label lblElevacion;
        private System.Windows.Forms.TextBox txtZElevacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalPuntos;
        private System.Windows.Forms.GroupBox groupBoxResultados;
        private System.Windows.Forms.Label lblVolumenTexto;
        private System.Windows.Forms.Label lblVolumen;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTituloGrafica;
        private System.Windows.Forms.Panel panelOpenGL;
        public System.Windows.Forms.Button btnAgregarCoordenada;
        public System.Windows.Forms.Button btnQuitarCoordenada;
        public System.Windows.Forms.Button btnLimpiarCoordenada;
        public System.Windows.Forms.Button btnCalcular;
        private Label lblNombreTerreno;
        public Button btnGuardarTerreno;
        public TextBox txtNombreTerreno;
    }
}
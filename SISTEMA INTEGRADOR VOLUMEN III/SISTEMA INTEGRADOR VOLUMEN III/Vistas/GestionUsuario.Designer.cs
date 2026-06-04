namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class GestionUsuario
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            button1 = new Button();
            btnGuardarUsuario = new Button();
            btnLimpiar = new Button();
            cmbEstado = new ComboBox();
            cmbRol = new ComboBox();
            txtCorreo = new TextBox();
            txtNombreUsuario = new TextBox();
            groupBox2 = new GroupBox();
            dgvUsuarios = new DataGridView();
            btnBuscar = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(18, 29);
            label1.Name = "label1";
            label1.Size = new Size(141, 19);
            label1.TabIndex = 0;
            label1.Text = "Nombre de Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(18, 92);
            label2.Name = "label2";
            label2.Size = new Size(31, 19);
            label2.TabIndex = 1;
            label2.Text = "Rol";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(405, 29);
            label3.Name = "label3";
            label3.Size = new Size(56, 19);
            label3.TabIndex = 2;
            label3.Text = "Correo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(405, 92);
            label4.Name = "label4";
            label4.Size = new Size(53, 19);
            label4.TabIndex = 3;
            label4.Text = "Estado";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(btnGuardarUsuario);
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(cmbEstado);
            groupBox1.Controls.Add(cmbRol);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(txtNombreUsuario);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 200);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Usuario";
            // 
            // button1
            // 
            button1.Location = new Point(429, 160);
            button1.Name = "button1";
            button1.Size = new Size(193, 31);
            button1.TabIndex = 10;
            button1.Text = "Reestablecer Contraseña";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.Location = new Point(269, 161);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(138, 30);
            btnGuardarUsuario.TabIndex = 9;
            btnGuardarUsuario.Text = "Guardar Usuario";
            btnGuardarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(160, 160);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(83, 30);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(405, 114);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(342, 25);
            cmbEstado.TabIndex = 7;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(18, 114);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(306, 25);
            cmbRol.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(405, 51);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(342, 25);
            txtCorreo.TabIndex = 5;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(18, 51);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(306, 25);
            txtNombreUsuario.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvUsuarios);
            groupBox2.Controls.Add(btnBuscar);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 232);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 284);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Usuarios Registrados";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(18, 71);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(729, 207);
            dgvUsuarios.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscar.Location = new Point(364, 30);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 25);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(82, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(276, 25);
            textBox1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 33);
            label5.Name = "label5";
            label5.Size = new Size(58, 19);
            label5.TabIndex = 0;
            label5.Text = "Buscar:";
            // 
            // GestionUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 528);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "GestionUsuario";
            Text = "GestionUsuario";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private ComboBox cmbEstado;
        private ComboBox cmbRol;
        private TextBox txtCorreo;
        private TextBox txtNombreUsuario;
        private Button btnGuardarUsuario;
        private Button btnLimpiar;
        private Button button1;
        private GroupBox groupBox2;
        private Button btnBuscar;
        private TextBox textBox1;
        private Label label5;
        private DataGridView dgvUsuarios;
    }
}
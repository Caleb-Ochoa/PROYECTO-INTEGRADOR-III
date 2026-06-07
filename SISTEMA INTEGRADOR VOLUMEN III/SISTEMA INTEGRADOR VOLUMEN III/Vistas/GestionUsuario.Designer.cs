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
            label3 = new Label();
            groupBox1 = new GroupBox();
            btnGuardarUsuario = new Button();
            txtCorreo = new TextBox();
            txtNombreUsuario = new TextBox();
            groupBox2 = new GroupBox();
            dgvUsuarios = new DataGridView();
            btnBuscar = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBox3 = new TextBox();
            label8 = new Label();
            textBox4 = new TextBox();
            label2 = new Label();
            txtUsuarioAdmin = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(123, 19);
            label1.TabIndex = 0;
            label1.Text = "Nombre Completo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(6, 129);
            label3.Name = "label3";
            label3.Size = new Size(121, 19);
            label3.TabIndex = 2;
            label3.Text = "Correo electronico";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtUsuarioAdmin);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(btnGuardarUsuario);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(txtNombreUsuario);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(303, 518);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Usuario";
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.BackColor = SystemColors.ActiveCaption;
            btnGuardarUsuario.Location = new Point(6, 474);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(138, 30);
            btnGuardarUsuario.TabIndex = 9;
            btnGuardarUsuario.Text = "Guardar";
            btnGuardarUsuario.UseVisualStyleBackColor = false;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(6, 151);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(290, 25);
            txtCorreo.TabIndex = 5;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(6, 51);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(290, 25);
            txtNombreUsuario.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvUsuarios);
            groupBox2.Controls.Add(btnBuscar);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.Location = new Point(321, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(477, 518);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Usuarios Registrados";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(18, 71);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(453, 207);
            dgvUsuarios.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.ActiveCaption;
            btnBuscar.Font = new Font("Segoe UI", 10F);
            btnBuscar.Location = new Point(364, 30);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 30);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
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
            label5.Size = new Size(52, 19);
            label5.TabIndex = 0;
            label5.Text = "Buscar:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 101);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(290, 25);
            textBox2.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 79);
            label6.Name = "label6";
            label6.Size = new Size(81, 19);
            label6.TabIndex = 12;
            label6.Text = "Documento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 179);
            label7.Name = "label7";
            label7.Size = new Size(60, 19);
            label7.TabIndex = 13;
            label7.Text = "Telefono";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 201);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(290, 25);
            textBox3.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 231);
            label8.Name = "label8";
            label8.Size = new Size(65, 19);
            label8.TabIndex = 15;
            label8.Text = "Direccion";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 253);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(290, 25);
            textBox4.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 281);
            label2.Name = "label2";
            label2.Size = new Size(56, 19);
            label2.TabIndex = 17;
            label2.Text = "Usuario";
            // 
            // txtUsuarioAdmin
            // 
            txtUsuarioAdmin.Location = new Point(6, 303);
            txtUsuarioAdmin.Name = "txtUsuarioAdmin";
            txtUsuarioAdmin.Size = new Size(290, 25);
            txtUsuarioAdmin.TabIndex = 18;
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
        private Label label3;
        private GroupBox groupBox1;
        private TextBox txtCorreo;
        private TextBox txtNombreUsuario;
        private Button btnGuardarUsuario;
        private GroupBox groupBox2;
        private Button btnBuscar;
        private TextBox textBox1;
        private Label label5;
        private DataGridView dgvUsuarios;
        private Label label6;
        private TextBox textBox2;
        private Label label7;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label8;
        private TextBox txtUsuarioAdmin;
        private Label label2;
    }
}
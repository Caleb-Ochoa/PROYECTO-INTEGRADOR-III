
namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    partial class MenuPrincipal
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
            btnGUsuarios = new Button();
            btnCotizacion = new Button();
            btnTerreno = new Button();
            btnFactura = new Button();
            btnCerrarSesion = new Button();
            btnCambiarContraseña = new Button();
            btnMateriales = new Button();
            btnClientes = new Button();
            splitContainer1 = new SplitContainer();
            ptbMostrarMenu = new PictureBox();
            pnlEncabezado = new Panel();
            btnConfiguracion = new Button();
            lblFecha = new Label();
            lblRol = new Label();
            lblNombre = new Label();
            lblAvatar = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbMostrarMenu).BeginInit();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // btnGUsuarios
            // 
            btnGUsuarios.BackColor = SystemColors.Control;
            btnGUsuarios.Font = new Font("Segoe UI", 10F);
            btnGUsuarios.Location = new Point(10, 60);
            btnGUsuarios.Name = "btnGUsuarios";
            btnGUsuarios.Size = new Size(166, 30);
            btnGUsuarios.TabIndex = 10;
            btnGUsuarios.Text = "👤 Gestion Usuario";
            btnGUsuarios.TextAlign = ContentAlignment.TopLeft;
            btnGUsuarios.UseVisualStyleBackColor = false;
            btnGUsuarios.Click += btnGUsuario_Click;
            // 
            // btnCotizacion
            // 
            btnCotizacion.Font = new Font("Segoe UI", 10F);
            btnCotizacion.Location = new Point(10, 302);
            btnCotizacion.Name = "btnCotizacion";
            btnCotizacion.Size = new Size(166, 30);
            btnCotizacion.TabIndex = 2;
            btnCotizacion.Text = "🗃️ Cotizaciones";
            btnCotizacion.TextAlign = ContentAlignment.TopLeft;
            btnCotizacion.UseVisualStyleBackColor = true;
            btnCotizacion.Click += btnCotizacion_Click;
            // 
            // btnTerreno
            // 
            btnTerreno.Font = new Font("Segoe UI", 10F);
            btnTerreno.Location = new Point(10, 239);
            btnTerreno.Name = "btnTerreno";
            btnTerreno.Size = new Size(166, 30);
            btnTerreno.TabIndex = 3;
            btnTerreno.Text = "🏔️ Terreno y Cálculo";
            btnTerreno.TextAlign = ContentAlignment.TopLeft;
            btnTerreno.UseVisualStyleBackColor = true;
            btnTerreno.Click += btnTerreno_Click;
            // 
            // btnFactura
            // 
            btnFactura.Font = new Font("Segoe UI", 10F);
            btnFactura.Location = new Point(10, 357);
            btnFactura.Name = "btnFactura";
            btnFactura.Size = new Size(166, 30);
            btnFactura.TabIndex = 4;
            btnFactura.Text = "\U0001f9fe  Facturas";
            btnFactura.TextAlign = ContentAlignment.TopLeft;
            btnFactura.UseVisualStyleBackColor = true;
            btnFactura.Click += btnFactura_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.AutoSize = true;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F);
            btnCerrarSesion.Location = new Point(821, 52);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(123, 30);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = " 🚪 CERRAR SESIÓN";
            btnCerrarSesion.TextAlign = ContentAlignment.TopLeft;
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnCambiarContraseña
            // 
            btnCambiarContraseña.Font = new Font("Segoe UI", 10F);
            btnCambiarContraseña.Location = new Point(10, 411);
            btnCambiarContraseña.Name = "btnCambiarContraseña";
            btnCambiarContraseña.Size = new Size(166, 27);
            btnCambiarContraseña.TabIndex = 9;
            btnCambiarContraseña.Text = "🔑Cambiar Contraseña";
            btnCambiarContraseña.TextAlign = ContentAlignment.TopLeft;
            btnCambiarContraseña.UseVisualStyleBackColor = true;
            btnCambiarContraseña.Click += btnCambiarContraseña_Click;
            // 
            // btnMateriales
            // 
            btnMateriales.Font = new Font("Segoe UI", 10F);
            btnMateriales.Location = new Point(10, 179);
            btnMateriales.Name = "btnMateriales";
            btnMateriales.Size = new Size(166, 30);
            btnMateriales.TabIndex = 7;
            btnMateriales.Text = "📦 Materiales";
            btnMateriales.TextAlign = ContentAlignment.TopLeft;
            btnMateriales.UseVisualStyleBackColor = true;
            btnMateriales.Click += btnMateriales_Click;
            // 
            // btnClientes
            // 
            btnClientes.Font = new Font("Segoe UI", 10F);
            btnClientes.Location = new Point(10, 118);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(166, 30);
            btnClientes.TabIndex = 6;
            btnClientes.Text = "👥 Clientes";
            btnClientes.TextAlign = ContentAlignment.TopLeft;
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 93);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ActiveCaption;
            splitContainer1.Panel1.Controls.Add(ptbMostrarMenu);
            splitContainer1.Panel1.Controls.Add(btnTerreno);
            splitContainer1.Panel1.Controls.Add(btnFactura);
            splitContainer1.Panel1.Controls.Add(btnCambiarContraseña);
            splitContainer1.Panel1.Controls.Add(btnCotizacion);
            splitContainer1.Panel1.Controls.Add(btnGUsuarios);
            splitContainer1.Panel1.Controls.Add(btnClientes);
            splitContainer1.Panel1.Controls.Add(btnMateriales);
            splitContainer1.Size = new Size(956, 441);
            splitContainer1.SplitterDistance = 191;
            splitContainer1.TabIndex = 10;
            // 
            // ptbMostrarMenu
            // 
            ptbMostrarMenu.BackColor = SystemColors.ActiveCaption;
            ptbMostrarMenu.Image = Properties.Resources.FlechaIzquierda;
            ptbMostrarMenu.Location = new Point(3, 3);
            ptbMostrarMenu.Name = "ptbMostrarMenu";
            ptbMostrarMenu.Size = new Size(38, 35);
            ptbMostrarMenu.SizeMode = PictureBoxSizeMode.Zoom;
            ptbMostrarMenu.TabIndex = 11;
            ptbMostrarMenu.TabStop = false;
            ptbMostrarMenu.Click += pbToggle_Click;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = SystemColors.ActiveCaption;
            pnlEncabezado.Controls.Add(btnConfiguracion);
            pnlEncabezado.Controls.Add(lblFecha);
            pnlEncabezado.Controls.Add(lblRol);
            pnlEncabezado.Controls.Add(btnCerrarSesion);
            pnlEncabezado.Controls.Add(lblNombre);
            pnlEncabezado.Controls.Add(lblAvatar);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(956, 93);
            pnlEncabezado.TabIndex = 11;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfiguracion.BackColor = SystemColors.ActiveCaption;
            btnConfiguracion.BackgroundImage = Properties.Resources.settings_configuration_icon_solid_style_icon_design_element_icon_template_background_free_vector_removebg_preview;
            btnConfiguracion.BackgroundImageLayout = ImageLayout.Zoom;
            btnConfiguracion.FlatAppearance.BorderSize = 0;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Segoe UI", 24F);
            btnConfiguracion.Location = new Point(881, 10);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Size = new Size(63, 36);
            btnConfiguracion.TabIndex = 6;
            btnConfiguracion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfiguracion.UseVisualStyleBackColor = false;
            btnConfiguracion.Click += btnConfiguracion_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 10F);
            lblFecha.Location = new Point(66, 60);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(185, 19);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Sábado, 06 de junio de 2026";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 10F);
            lblRol.Location = new Point(66, 39);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(100, 19);
            lblRol.TabIndex = 2;
            lblRol.Text = " Administrador";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14F);
            lblNombre.Location = new Point(66, 14);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(106, 25);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Bienvenido";
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Font = new Font("Segoe UI", 28F);
            lblAvatar.Location = new Point(0, 13);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(74, 51);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "👑";
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 534);
            Controls.Add(splitContainer1);
            Controls.Add(pnlEncabezado);
            Name = "MenuPrincipal";
            WindowState = FormWindowState.Maximized;
            Load += MenuPrincipal_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbMostrarMenu).EndInit();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCerrarSesion;
        private Button btnClientes;
        private SplitContainer splitContainer1;
        private Panel pnlEncabezado;
        private Label lblRol;
        private Label lblNombre;
        private Label lblAvatar;
        private Label lblFecha;
        private Button btnConfiguracion;
        public Button btnGUsuarios;
        public Button btnCotizacion;
        public Button btnTerreno;
        public Button btnFactura;
        public Button btnMateriales;
        public Button btnCambiarContraseña;
        private PictureBox ptbMostrarMenu;
    }
}
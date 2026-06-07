
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
            panel1 = new Panel();
            pnlContenido = new Panel();
            pnlEncabezado = new Panel();
            lblFecha = new Label();
            lblRol = new Label();
            lblNombre = new Label();
            lblAvatar = new Label();
            btnConfiguracion = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // btnGUsuarios
            // 
            btnGUsuarios.Font = new Font("Segoe UI", 10F);
            btnGUsuarios.Location = new Point(13, 14);
            btnGUsuarios.Name = "btnGUsuarios";
            btnGUsuarios.Size = new Size(155, 30);
            btnGUsuarios.TabIndex = 10;
            btnGUsuarios.Text = " 👤 Gestion Usuario";
            // 
            // btnCotizacion
            // 
            btnCotizacion.Font = new Font("Segoe UI", 10F);
            btnCotizacion.Location = new Point(13, 217);
            btnCotizacion.Name = "btnCotizacion";
            btnCotizacion.Size = new Size(155, 30);
            btnCotizacion.TabIndex = 2;
            btnCotizacion.Text = "🗃️ Cotizaciones";
            btnCotizacion.UseVisualStyleBackColor = true;
            // 
            // btnTerreno
            // 
            btnTerreno.Font = new Font("Segoe UI", 10F);
            btnTerreno.Location = new Point(13, 165);
            btnTerreno.Name = "btnTerreno";
            btnTerreno.Size = new Size(155, 30);
            btnTerreno.TabIndex = 3;
            btnTerreno.Text = "🏔️ Terreno y Cálculo";
            btnTerreno.UseVisualStyleBackColor = true;
            // 
            // btnFactura
            // 
            btnFactura.Font = new Font("Segoe UI", 10F);
            btnFactura.Location = new Point(13, 265);
            btnFactura.Name = "btnFactura";
            btnFactura.Size = new Size(155, 30);
            btnFactura.TabIndex = 4;
            btnFactura.Text = " \U0001f9fe  Facturas";
            btnFactura.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Font = new Font("Segoe UI", 9F);
            btnCerrarSesion.Location = new Point(609, 48);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(140, 30);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = " 🚪 CERRAR SESIÓN";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // btnCambiarContraseña
            // 
            btnCambiarContraseña.Font = new Font("Segoe UI", 10F);
            btnCambiarContraseña.Location = new Point(7, 315);
            btnCambiarContraseña.Name = "btnCambiarContraseña";
            btnCambiarContraseña.Size = new Size(174, 30);
            btnCambiarContraseña.TabIndex = 9;
            btnCambiarContraseña.Text = " 🔑  Cambiar Contraseña";
            btnCambiarContraseña.UseVisualStyleBackColor = true;
            btnCambiarContraseña.Click += button3_Click;
            // 
            // btnMateriales
            // 
            btnMateriales.Font = new Font("Segoe UI", 10F);
            btnMateriales.Location = new Point(13, 113);
            btnMateriales.Name = "btnMateriales";
            btnMateriales.Size = new Size(155, 30);
            btnMateriales.TabIndex = 7;
            btnMateriales.Text = "📦 Materiales";
            btnMateriales.UseVisualStyleBackColor = true;
            // 
            // btnClientes
            // 
            btnClientes.Font = new Font("Segoe UI", 10F);
            btnClientes.Location = new Point(13, 65);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(155, 30);
            btnClientes.TabIndex = 6;
            btnClientes.Text = "👥 Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 99);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pnlContenido);
            splitContainer1.Size = new Size(719, 423);
            splitContainer1.SplitterDistance = 190;
            splitContainer1.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnGUsuarios);
            panel1.Controls.Add(btnCambiarContraseña);
            panel1.Controls.Add(btnClientes);
            panel1.Controls.Add(btnFactura);
            panel1.Controls.Add(btnMateriales);
            panel1.Controls.Add(btnCotizacion);
            panel1.Controls.Add(btnTerreno);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(184, 423);
            panel1.TabIndex = 0;
            // 
            // pnlContenido
            // 
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(525, 423);
            pnlContenido.TabIndex = 11;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.Controls.Add(btnConfiguracion);
            pnlEncabezado.Controls.Add(btnCerrarSesion);
            pnlEncabezado.Controls.Add(lblFecha);
            pnlEncabezado.Controls.Add(lblRol);
            pnlEncabezado.Controls.Add(lblNombre);
            pnlEncabezado.Controls.Add(lblAvatar);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(761, 93);
            pnlEncabezado.TabIndex = 11;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(66, 60);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(153, 15);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Sábado, 06 de junio de 2026";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(66, 36);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(86, 15);
            lblRol.TabIndex = 2;
            lblRol.Text = " Administrador";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(66, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(140, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Bienvenido, Admin";
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Font = new Font("Segoe UI", 24F);
            lblAvatar.Location = new Point(10, 15);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(64, 45);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "👑";
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.BackColor = SystemColors.Menu;
            btnConfiguracion.BackgroundImage = Properties.Resources.settings_configuration_icon_solid_style_icon_design_element_icon_template_background_free_vector_removebg_preview;
            btnConfiguracion.BackgroundImageLayout = ImageLayout.Zoom;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Segoe UI", 14F);
            btnConfiguracion.Location = new Point(697, 3);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Size = new Size(52, 36);
            btnConfiguracion.TabIndex = 6;
            btnConfiguracion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfiguracion.UseVisualStyleBackColor = false;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 534);
            Controls.Add(pnlEncabezado);
            Controls.Add(splitContainer1);
            Name = "MenuPrincipal";
            Text = "e";
            WindowState = FormWindowState.Maximized;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnGUsuarios;
        private Button btnCotizacion;
        private Button btnTerreno;
        private Button btnFactura;
        private Button btnCerrarSesion;
        private Button btnClientes;
        private Button btnMateriales;
        private Button btnCambiarContraseña;
        private SplitContainer splitContainer1;
        private Panel pnlContenido;
        private Panel pnlEncabezado;
        private Label lblRol;
        private Label lblNombre;
        private Label lblAvatar;
        private Label lblFecha;
        private Panel panel1;
        private Button btnConfiguracion;
    }
}
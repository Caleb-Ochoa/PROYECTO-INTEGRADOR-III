
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
            btnAdministrador = new Button();
            btnGUsuarios = new Button();
            btnCotizacion = new Button();
            btnTerreno = new Button();
            btnFactura = new Button();
            btnCerrarSesion = new Button();
            btnCambiarContraseña = new Button();
            btnMateriales = new Button();
            btnClientes = new Button();
            splitContainer1 = new SplitContainer();
            PanelContenedor = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdministrador
            // 
            btnAdministrador.Font = new Font("Segoe UI", 10F);
            btnAdministrador.Location = new Point(14, 15);
            btnAdministrador.Name = "btnAdministrador";
            btnAdministrador.Size = new Size(134, 30);
            btnAdministrador.TabIndex = 0;
            btnAdministrador.Text = "👨‍💼 Administrador";
            btnAdministrador.UseVisualStyleBackColor = true;
            // 
            // btnGUsuarios
            // 
            btnGUsuarios.Font = new Font("Segoe UI", 10F);
            btnGUsuarios.Location = new Point(10, 76);
            btnGUsuarios.Name = "btnGUsuarios";
            btnGUsuarios.Size = new Size(155, 30);
            btnGUsuarios.TabIndex = 10;
            btnGUsuarios.Text = " 👤 Gestion Usuario";
            // 
            // btnCotizacion
            // 
            btnCotizacion.Font = new Font("Segoe UI", 10F);
            btnCotizacion.Location = new Point(14, 232);
            btnCotizacion.Name = "btnCotizacion";
            btnCotizacion.Size = new Size(155, 30);
            btnCotizacion.TabIndex = 2;
            btnCotizacion.Text = "🗃️ Cotizaciones";
            btnCotizacion.UseVisualStyleBackColor = true;
            // 
            // btnTerreno
            // 
            btnTerreno.Font = new Font("Segoe UI", 10F);
            btnTerreno.Location = new Point(10, 196);
            btnTerreno.Name = "btnTerreno";
            btnTerreno.Size = new Size(155, 30);
            btnTerreno.TabIndex = 3;
            btnTerreno.Text = "🏔️ Terreno y Cálculo";
            btnTerreno.UseVisualStyleBackColor = true;
            // 
            // btnFactura
            // 
            btnFactura.Font = new Font("Segoe UI", 10F);
            btnFactura.Location = new Point(10, 268);
            btnFactura.Name = "btnFactura";
            btnFactura.Size = new Size(155, 30);
            btnFactura.TabIndex = 4;
            btnFactura.Text = " \U0001f9fe  Facturas";
            btnFactura.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Font = new Font("Segoe UI", 9F);
            btnCerrarSesion.Location = new Point(26, 396);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(122, 30);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = " 🚪 CERRAR SESIÓN";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // btnCambiarContraseña
            // 
            btnCambiarContraseña.Font = new Font("Segoe UI", 10F);
            btnCambiarContraseña.Location = new Point(10, 317);
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
            btnMateriales.Location = new Point(14, 160);
            btnMateriales.Name = "btnMateriales";
            btnMateriales.Size = new Size(155, 30);
            btnMateriales.TabIndex = 7;
            btnMateriales.Text = "📦 Materiales";
            btnMateriales.UseVisualStyleBackColor = true;
            // 
            // btnClientes
            // 
            btnClientes.Font = new Font("Segoe UI", 10F);
            btnClientes.Location = new Point(10, 112);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(155, 30);
            btnClientes.TabIndex = 6;
            btnClientes.Text = "👥 Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 76);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnAdministrador);
            splitContainer1.Panel1.Controls.Add(btnCerrarSesion);
            splitContainer1.Panel1.Controls.Add(btnCambiarContraseña);
            splitContainer1.Panel1.Controls.Add(btnFactura);
            splitContainer1.Panel1.Controls.Add(btnCotizacion);
            splitContainer1.Panel1.Controls.Add(btnGUsuarios);
            splitContainer1.Panel1.Controls.Add(btnClientes);
            splitContainer1.Panel1.Controls.Add(btnMateriales);
            splitContainer1.Panel1.Controls.Add(btnTerreno);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(PanelContenedor);
            splitContainer1.Size = new Size(719, 446);
            splitContainer1.SplitterDistance = 190;
            splitContainer1.TabIndex = 10;
            // 
            // PanelContenedor
            // 
            PanelContenedor.Location = new Point(3, 3);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(548, 440);
            PanelContenedor.TabIndex = 11;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 534);
            Controls.Add(splitContainer1);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdministrador;
        private Button btnGUsuarios;
        private Button btnCotizacion;
        private Button btnTerreno;
        private Button btnFactura;
        private Button btnCerrarSesion;
        private Button btnClientes;
        private Button btnMateriales;
        private Button btnCambiarContraseña;
        private SplitContainer splitContainer1;
        private Panel PanelContenedor;
    }
}
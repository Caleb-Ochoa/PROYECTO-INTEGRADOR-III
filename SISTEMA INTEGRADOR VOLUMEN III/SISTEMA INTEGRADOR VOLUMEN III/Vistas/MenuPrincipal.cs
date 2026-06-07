using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    internal partial class MenuPrincipal : Form
    {
        private readonly Usuario _usuario;

        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (_usuario.Rol == Rol.Administrador)
            {
                lblAvatar.Text = "👑";
                lblRol.Text = "Administrador";
            }
            else
            {
                lblAvatar.Text = "👤";
                lblRol.Text = "Usuario";
            }

            lblNombre.Text = $"Bienvenido, {_usuario.Nombre}";
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Ocultar botones admin si es usuario normal
            btnGUsuarios.Visible = _usuario.Rol == Rol.Administrador;
            btnCambiarContraseña.Visible = _usuario.Rol == Rol.Administrador;

            this.WindowState = FormWindowState.Maximized;
        }
        public void AbrirFormulario(Form formulario)
        {
            if (pnlContenido.Controls.Count > 0)pnlContenido.Controls[0].Dispose();

            formulario.TopLevel = false;  // que no abra como ventana nueva
            formulario.FormBorderStyle = FormBorderStyle.None; // sin bordes
            formulario.Dock = DockStyle.Fill; // ocupa todo el panel

            pnlContenido.Controls.Add(formulario);
            pnlContenido.Tag = formulario;
            formulario.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Este es tu botón de "Cambiar Contraseña" según tu Designer.
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //lblRol.Text = usuario.Rol == Rol.Administrador ? "👑 Administrador" : "👤 Usuario";
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Clientes());
        }

        private void btnMateriales_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Materiales());
        }

        private void btnTerreno_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Terreno_y_Calculo());
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Cotizaciones());
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Facturas());
        }

        private void btnGUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new GestionUsuario());
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CambioContraseña());
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}

using SISTEMA_INTEGRADOR_VOLUMEN_III.Controller;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    internal partial class MenuPrincipal : Form
    {
        private Usuario usuario;
        private Form? formularioActivo = null;

        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el menú principal
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            // Este es tu botón de "Cambiar Contraseña" según tu Designer.
        }
        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            GestionUsuario usuario = new GestionUsuario();

            AbrirFormulario(usuario);
        }
        public void AbrirFormulario(Form formulario)
        {
            PanelContenedor.Controls.Clear();

            formulario.TopLevel = false;

            formulario.Dock = DockStyle.Fill;

            PanelContenedor.Controls.Add(formulario);

            formulario.Show();
        }

    }
}

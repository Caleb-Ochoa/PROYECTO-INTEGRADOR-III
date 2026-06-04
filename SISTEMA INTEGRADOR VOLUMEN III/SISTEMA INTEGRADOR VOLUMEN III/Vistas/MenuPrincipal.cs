using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;

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

        /// <summary>
        /// Método para meter cualquier formulario dentro de tu contenedor principal
        /// </summary>
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // 1. Si ya había un formulario abierto, lo cerramos para liberar memoria
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            // 2. Guardamos el nuevo formulario como el activo
            formularioActivo = formularioHijo;

            // 3. Configuración para que se comporte como un control hijo
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None; // Quita los bordes de la ventana
            formularioHijo.Dock = DockStyle.Fill;                  // Rellena todo el espacio disponible

            // 4. Limpiamos el contenedor e introducimos el nuevo formulario
            this.flowLayoutPanel1.Controls.Clear(); // <-- Limpia residuos visuales previos
            this.flowLayoutPanel1.Controls.Add(formularioHijo);
            this.flowLayoutPanel1.Tag = formularioHijo;

            // 5. Lo traemos al frente y lo mostramos
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // ── EVENTOS DE LOS BOTONES DEL MENÚ ─────────────────────────────────

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            // Abre la pantalla de Gestión de Usuarios dentro del contenedor
            AbrirFormularioHijo(new GestionUsuario());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el menú principal
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Este es tu botón de "Cambiar Contraseña" según tu Designer.
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class CambioContraseña : Form
    {
        public CambioContraseña()
        {
            InitializeComponent();

            // Ocultar caracteres en los campos de contraseña
            txtContraseñaActual.PasswordChar = '●';
            txtContraseñaNueva.PasswordChar = '●';
            txtConfirNuevaContraseña.PasswordChar = '●';
        }
        public string GetContraseñaActual() => txtContraseñaActual.Text;
        public string GetContraseñaNueva() => txtContraseñaNueva.Text;
        public string GetContraseñaConfirmar() => txtConfirNuevaContraseña.Text;

        public void LimpiarFormulario()
        {
            txtContraseñaActual.Clear();
            txtContraseñaNueva.Clear();
            txtConfirNuevaContraseña.Clear();
            txtContraseñaActual.Focus();
        }

        public void MostrarMensaje(string mensaje, bool esError = false)
        {
            MessageBox.Show(mensaje,esError ? "Error" : "Éxito",
                MessageBoxButtons.OK,esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

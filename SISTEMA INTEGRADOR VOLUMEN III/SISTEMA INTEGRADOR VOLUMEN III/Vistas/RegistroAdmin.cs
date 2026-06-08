using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class RegistroAdmin : Form
    {
        public RegistroAdmin()
        {
            InitializeComponent();
            Idioma.Aplicar(this);
        }

        public string[] GetInput()
        {
            return new string[]
            {
                txtNombreCompleto.Text.Trim(),// line[0]
                txtDocumentoAdmin.Text.Trim(),           // line[1]
                txtCorreoAdmin.Text.Trim(),     // line[1] (En tu captura se ve "txtUsuarioAdmin" arriba a la derecha)
                txtTelefonoAdmin.Text.Trim(),
                txtDireccion.Text.Trim(),
                txtUsuarioAdmin.Text.Trim(),
                txtContraseñaAdmin.Text,                // line[3]
                txtConfirmarContraseña.Text        // line[4]
            };
        }

        /// Muestra un mensaje de advertencia en pantalla si algo falla.
        /// </summary>
        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnIdioma_Click(object sender, EventArgs e)
        {
            Idioma.MostrarSelector(this);
        }
    }
}

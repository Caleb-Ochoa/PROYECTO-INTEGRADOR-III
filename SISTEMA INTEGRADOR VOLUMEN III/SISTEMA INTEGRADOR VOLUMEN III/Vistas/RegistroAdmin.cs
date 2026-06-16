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
        }

        public string[] GetInput()
        {
            return new string[]
            {
                txtNombreCompleto.Text.Trim(),
                txtDocumentoAdmin.Text.Trim(),           
                txtCorreoAdmin.Text.Trim(),     
                txtTelefonoAdmin.Text.Trim(),
                txtDireccion.Text.Trim(),
                txtUsuarioAdmin.Text.Trim(),
                txtContraseñaAdmin.Text,                
                txtConfirmarContraseña.Text        
            };
        }

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

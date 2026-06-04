using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class GestionUsuario : Form
    {
        public GestionUsuario()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
        private void CargarUsuarios()
        {
            List<Usuario> usuarios = _repositorio.ObtenerTodos(); // o como lo tengas

            dgvUsuarios.Rows.Clear();

            foreach (Usuario u in usuarios)
            {
                dgvUsuarios.Rows.Add(
                    u.NombreUsuario,
                    u.Correo,
                    u.Rol.ToString(),       // el enum Rol que ya tienes
                    u.Estado.ToString()     // el enum EstadoUsuario que ya tienes
                );
            }
        }
    }
}

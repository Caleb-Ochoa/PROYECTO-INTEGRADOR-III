using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class Clientes : Form
    {
        // Id del cliente seleccionado en el grid (0 = ninguno = nuevo)
        private int _idSeleccionado = 0;
        public Clientes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Devuelve los valores del formulario en orden:
        /// [0] Nombre, [1] Documento, [2] Correo, [3] Telefono, [4] Direccion
        /// </summary>
        public string[] GetInput() => new[]
        {
            txtNombreClientec.Text.Trim(),   // [0] Nombre
            txtDocumentoCliente.Text.Trim(), // [1] Documento
            txtCCliente.Text.Trim(),         // [2] Correo
            txtTelefonoCliente.Text.Trim(),  // [3] Telefono
            txtDireccionCliente.Text.Trim()  // [4] Direccion
        };

        public int GetIdSeleccionado() => _idSeleccionado;

        public void SetIdSeleccionado(int id) => _idSeleccionado = id;
    }
}

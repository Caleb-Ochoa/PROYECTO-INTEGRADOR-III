using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class Materiales : Form
    {
        private int _idEditando = 0;
        public Materiales()
        {
            InitializeComponent();
            Idioma.Aplicar(this);
        }

        // ── Métodos que usa CtlMaterial ───────────────────────────────────

        /// <summary>Devuelve [0]Nombre [1]CostoMetroCubico como string.</summary>
        public string[] GetInput() => new[]
        {
            txtNombreMaterial.Text.Trim(),
            txtCostoMaterial.Text.Trim()
        };

        public void LimpiarFormulario()
        {
            txtNombreMaterial.Clear();
            txtCostoMaterial.Clear();
            _idEditando = 0;
            btnGuardarMaterial.Text = "Guardar";
            txtNombreMaterial.Focus();
        }

        public int GetIdEditando() => _idEditando;

        public bool EstaEditando() => _idEditando > 0;

        /// <summary>Pre-rellena el formulario para editar un material.</summary>
        public void CargarEnFormulario(int id, string nombre, string costo)
        {
            _idEditando = id;
            txtNombreMaterial.Text = nombre;
            txtCostoMaterial.Text = costo;
            btnGuardarMaterial.Text = "Actualizar";
            txtNombreMaterial.Focus();
        }
        /// <summary>Carga la lista de materiales en el grid.</summary>
        public void CargarGrid(object datos)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = datos;
        }

        public DataGridView GetGrid() => dataGridView1;

        public string GetTextoBusqueda() => txtBuscarMateriales.Text.Trim();

        public void MostrarMensaje(string mensaje, bool esError = false)
        {
            MessageBox.Show(mensaje,
                esError ? "Error" : "Éxito",
                MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

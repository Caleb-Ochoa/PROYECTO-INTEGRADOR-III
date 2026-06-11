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
    public partial class Cotizaciones : Form
    {
        public Cotizaciones()
        {
            InitializeComponent();
            Idioma.Aplicar(this);
        }

        // ── Popup Nueva Cotización ────────────────────────────────────────
        /// <summary>
        /// Muestra el popup para crear una cotización.
        /// Devuelve (clienteId, terrenoId, materialId) o null si canceló.
        /// </summary>
        public (int clienteId, int terrenoId, int materialId)? MostrarPopupNuevaCotizacion(
            List<Cliente> clientes,
            List<Terreno> terrenos,
            List<Material> materiales)
        {
            (int, int, int)? resultado = null;

            using Form popup = new Form
            {
                Text = "Nueva Cotización",
                Size = new Size(440, 360),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            // Título
            var lblTitulo = new Label
            {
                Text = "Nueva Cotización",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };
            var lblSub = new Label
            {
                Text = "Registrar información de la cotización",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(20, 42),
                AutoSize = true
            };

            // ── Combo Cliente ─────────────────────────────────────────────
            var lblCliente = new Label { Text = "Cliente", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(20, 72), AutoSize = true };
            var cboCliente = new ComboBox
            {
                Location = new Point(20, 92),
                Size = new Size(390, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            cboCliente.DataSource = clientes;
            cboCliente.DisplayMember = "Nombre";
            cboCliente.ValueMember = "Id";

            // ── Combo Terreno (se filtra por cliente) ─────────────────────
            var lblTerreno = new Label { Text = "Terreno", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(20, 128), AutoSize = true };
            var cboTerreno = new ComboBox
            {
                Location = new Point(20, 148),
                Size = new Size(390, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };

            // Filtrar terrenos cuando cambia el cliente
            void FiltrarTerrenos()
            {
                if (cboCliente.SelectedItem is not Cliente cli) return;
                var filtrados = terrenos.Where(t => t.ClienteId == cli.Id).ToList();
                cboTerreno.DataSource = filtrados;
                cboTerreno.DisplayMember = "Nombre";
                cboTerreno.ValueMember = "Id";
            }
            cboCliente.SelectedIndexChanged += (s, e) => FiltrarTerrenos();
            FiltrarTerrenos();

            // ── Combo Material ────────────────────────────────────────────
            var lblMaterial = new Label { Text = "Material", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(20, 184), AutoSize = true };
            var cboMaterial = new ComboBox
            {
                Location = new Point(20, 204),
                Size = new Size(390, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            cboMaterial.DataSource = materiales;
            cboMaterial.DisplayMember = "Nombre";
            cboMaterial.ValueMember = "Id";

            // ── Botones ───────────────────────────────────────────────────
            var btnCancelar = new Button
            {
                Text = "Cancelar",
                Size = new Size(100, 35),
                Location = new Point(195, 260),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(80, 80, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => popup.Close();

            var btnGuardar = new Button
            {
                Text = "Guardar cotización",
                Size = new Size(150, 35),
                Location = new Point(255, 260),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += (s, e) =>
            {
                if (cboCliente.SelectedItem == null ||
                    cboTerreno.SelectedItem == null ||
                    cboMaterial.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar Cliente, Terreno y Material.","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cliId = (int)cboCliente.SelectedValue!;
                int terId = (int)cboTerreno.SelectedValue!;
                int matId = (int)cboMaterial.SelectedValue!;
                resultado = (cliId, terId, matId);
                popup.Close();
            };

            popup.Controls.AddRange(new Control[]
            {
                lblTitulo, lblSub,
                lblCliente, cboCliente,
                lblTerreno, cboTerreno,
                lblMaterial, cboMaterial,
                btnCancelar, btnGuardar
            });

            popup.Shown += (s, e) => cboCliente.Focus();
            popup.ShowDialog(this);
            return resultado;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cotizaciones_Load(object sender, EventArgs e)
        {

        }
    }
}